using Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class TsEnum : INamed, IHaveModifiers
    {
        public Modifier[] Modifiers { get; set; }

        public string Name { get; set; }

        public Dictionary<string, TsEnumMember> Members { get; private set; }

        public TsEnum()
        {
            this.Members = new Dictionary<string, TsEnumMember>();
        }

        public string GetName()
        {
            return this.Name;
        }
    }
}
