using Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class TsInterface : INamed, IHaveModifiers
    {
        public Modifier[] Modifiers { get; set; }

        public TypeNameDeclaration Name { get; set; }

        public List<TypeReference> Extends { get; set; }

        public List<TsInterfaceMember> Members { get; set; }

        public bool IsInline { get; set; }

        public string GetName()
        {
            return this.Name?.Name;
        }
    }
}
