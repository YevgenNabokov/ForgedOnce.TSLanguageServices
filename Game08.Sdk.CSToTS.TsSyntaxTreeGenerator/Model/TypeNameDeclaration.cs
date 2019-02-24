using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class TypeNameDeclaration
    {
        public string Name { get; set; }

        public List<TypeParameterDeclaration> Parameters { get; set; }
    }
}
