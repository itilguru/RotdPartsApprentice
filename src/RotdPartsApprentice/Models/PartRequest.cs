using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RotdPartsApprentice.Models
{
    public class PartRequest
    {
        public string TailNumber { get; set; }
        public string Station { get; set; }
        public string Gate { get; set; }
        public string PartNumber { get; set; }
    }
}
