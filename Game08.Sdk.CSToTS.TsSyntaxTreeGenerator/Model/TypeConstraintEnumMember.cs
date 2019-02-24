using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class TypeConstraintEnumMember : TypeConstraint
    {
        public string EnumName { get; set; }

        public string MemberName { get; set; }
    }
}
