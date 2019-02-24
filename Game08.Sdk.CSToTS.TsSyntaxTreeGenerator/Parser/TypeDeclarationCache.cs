using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Parser
{
    public class TypeDeclarationCache
    {
        public Dictionary<string, TypeDeclaration> Declarations { get; set; }

        public Dictionary<string, Dictionary<string, TypeDeclaration>> TypeExtenders { get; set; }
    }    
}
