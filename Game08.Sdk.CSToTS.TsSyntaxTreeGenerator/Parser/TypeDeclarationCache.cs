using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Parser
{
    public class TypeDeclarationCache
    {
        public Dictionary<string, DeclaredType> Declarations { get; set; }

        public Dictionary<string, Dictionary<string, DeclaredType>> TypeExtenders { get; set; }

        public TypeDeclarationCache()
        {
            this.Declarations = new Dictionary<string, DeclaredType>();
            this.TypeExtenders = new Dictionary<string, Dictionary<string, DeclaredType>>();
        }
    }    
}
