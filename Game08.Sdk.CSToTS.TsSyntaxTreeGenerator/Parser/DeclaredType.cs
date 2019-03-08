using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Parser
{
    public class DeclaredType
    {
        public bool IsInternal { get; set; }

        public string Name { get; set; }

        public HashSet<string> Extends { get; set; }

        public HashSet<string> Refers { get; set; }
    }
}
