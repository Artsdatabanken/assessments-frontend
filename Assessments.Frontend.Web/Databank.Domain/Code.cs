using System;
using System.Collections.Generic;
using System.Text;

namespace Databank.Domain
{
    public class Code
    {
        public string Id { get; set; } // identification of a code group. It should be the same as the key of "Children" in parent ( a loader may set this automatically); in root node it must have an unique id for db identification 
        public string Value { get; set; }
        public string Text { get; set; } // the display text, if null then the Value should be used
        public string Info { get; set; } // optional description text
        public Dictionary<string, IEnumerable<Code>> Children { get; set; } // collection of codegroups, each containing codes

    }
}
