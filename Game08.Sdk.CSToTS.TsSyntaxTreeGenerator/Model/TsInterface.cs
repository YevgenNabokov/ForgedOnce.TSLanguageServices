using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class TsInterface
    {
        public TypeNameDeclaration Name { get; set; }

        public List<TypeReference> Extends { get; set; }

        public List<TsInterfaceMember> Members { get; set; }
    }
}
