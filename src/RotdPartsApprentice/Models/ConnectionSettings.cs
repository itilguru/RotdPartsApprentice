using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RotdPartsApprentice.Models
{
    public class ConnectionSettings
    {
        public string ipAddress { get { return "192.168.1.124"; } }
        public int portNumber { get { return 7171; } }
        public string omronPassword { get { return "adept"; } }
    }
}
