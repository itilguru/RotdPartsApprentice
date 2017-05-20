using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelnetHelper;
using RotdPartsApprentice.Models;
using RotdPartsApprentice.Commands;

namespace RotdPartsApprentice.Helpers
{
    public class OmronHelper
    {

        protected TelnetConnection telnet;
        private string _ipAddress;
        private int _port;
        private string _password;
        private bool _isRunning;
        private bool _isLoggedIn;
        PartRequest _request;

        public OmronHelper(PartRequest request)
        {
            ConnectionSettings connectionSettings = new ConnectionSettings();
            _ipAddress = connectionSettings.ipAddress;
            _port = connectionSettings.portNumber;
            _password = connectionSettings.omronPassword;
            _isRunning = false;
            _isLoggedIn = false;
            _request = request;
        }

        public void Start()
        {
            _isRunning = true;

            while (_isRunning)
            {
                EstablishConnection();
                if (!_isLoggedIn)
                {
                    Login();
                }
                else
                {
                    Process();
                }
            }
        }

        public void Stop()
        {
            _isRunning = false;
        }

        public string GetOmronMessage()
        {
            return telnet.Read();
        }

        private void Process()
        {
            ICommand moveDroid = new MoveCommand();
            ICommand requestPart = new RequestPartCommand();
            moveDroid.Start(telnet, OmronDictionary.PartsArea.Value);
            requestPart.Start(telnet, _request.PartNumber);
            moveDroid.Start(telnet, OmronDictionary.BayArea.Value);
            moveDroid.Start(telnet, OmronDictionary.BaseArea.Value);
        }

        private void EstablishConnection()
        {
            try
            {
                telnet = new TelnetConnection(_ipAddress, _port);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Login()
        {
            telnet.WriteLine(_password);
            if (GetOmronMessage() == OmronDictionary.Welcome.Value)
            {
                _isLoggedIn = true;
            }
        }

    }
}