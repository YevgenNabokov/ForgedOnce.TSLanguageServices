using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class TsInterfaceMemberProperty : TsInterfaceMember
    {
        public Expression TypeConstraint { get; set; }
    }
}
