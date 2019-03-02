using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class TsEnum
    {
        public Modifier[] Modifiers { get; set; }

        public string Name { get; set; }

        public Dictionary<string, TsEnumMember> Members { get; private set; }

        public TsEnum()
        {
            this.Members = new Dictionary<string, TsEnumMember>();
        }
    }
}
