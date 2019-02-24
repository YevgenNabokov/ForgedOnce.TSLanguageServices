using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class TsEnumMemberBitShiftExpression : TsEnumMember
    {
        public string Left { get; set; }

        public string Operator { get; set; }

        public string Right { get; set; }
    }
}
