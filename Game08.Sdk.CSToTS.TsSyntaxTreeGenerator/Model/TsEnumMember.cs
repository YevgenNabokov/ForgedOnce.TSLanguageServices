using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class TsEnumMember
    {
        public Modifier[] Modifiers { get; set; }

        public string Name { get; set; }

        public Expression Value { get; set; }
    }
}
