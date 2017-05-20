using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelnetHelper;

namespace RotdPartsApprentice.Commands
{
    public interface ICommand
    {
        void Start(TelnetConnection telnet, string end);
        void Stop(TelnetConnection telnet);
    }
}
