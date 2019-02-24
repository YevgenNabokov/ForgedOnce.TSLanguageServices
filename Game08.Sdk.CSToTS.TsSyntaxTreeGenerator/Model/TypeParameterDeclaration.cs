using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class TypeParameterDeclaration
    {
        public string Name { get; set; }

        public List<TypeReference> Extends { get; set; }
    }
}
