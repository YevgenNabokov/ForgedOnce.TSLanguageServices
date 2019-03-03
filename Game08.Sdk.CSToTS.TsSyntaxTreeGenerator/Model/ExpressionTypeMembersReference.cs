using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class ExpressionTypeMembersReference : Expression
    {
        public Expression TypeReference { get; set; }

        public List<string> MemberNames { get; set; }
    }
}
