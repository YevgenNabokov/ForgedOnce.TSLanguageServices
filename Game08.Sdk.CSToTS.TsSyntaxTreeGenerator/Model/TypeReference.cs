using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class TypeReference
    {
        public Identifier Name { get; set; }

        public bool IsArray { get; set; }

        public List<TypeReference> TypeParameters { get; set; }
    }
}
