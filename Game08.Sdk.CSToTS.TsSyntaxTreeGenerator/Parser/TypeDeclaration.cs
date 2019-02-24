using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Parser
{
    public class TypeDeclaration
    {
        public string Name { get; set; }

        public HashSet<string> Extends { get; set; }

        public HashSet<string> Refers { get; set; }
    }
}
