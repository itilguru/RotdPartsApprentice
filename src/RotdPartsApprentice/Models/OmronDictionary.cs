using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RotdPartsApprentice.Models
{
    public sealed class OmronDictionary
    {
        public string Value { get; private set; }
        private OmronDictionary(string value) { Value = value; }

        public static OmronDictionary Welcome => new OmronDictionary("Welcome to the server.");
        public static OmronDictionary Login => new OmronDictionary("Enter password:");
        public static OmronDictionary GoTo => new OmronDictionary("goto");
        public static OmronDictionary Say => new OmronDictionary("say");

        public static OmronDictionary BaseArea => new OmronDictionary("goal1");
        public static OmronDictionary PartsArea => new OmronDictionary("goal2");
        public static OmronDictionary BayArea => new OmronDictionary("goal3");
    }
}
