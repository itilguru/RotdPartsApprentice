using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelnetHelper;
using RotdPartsApprentice.Models;

namespace RotdPartsApprentice.Commands
{
    public class RequestPartCommand: ICommand
    {
        public void Start(TelnetConnection telnet, string partNumber)
        {
            bool isRunning = false;
            try
            {
                telnet.Write(OmronDictionary.Say.Value + " " + partNumber);
                isRunning = true;
                while (isRunning)
                {
                    string message = telnet.Read();
                    if (message.StartsWith("Arrived"))
                    {
                        isRunning = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Stop(TelnetConnection telnet)
        {
        }
    }
}
