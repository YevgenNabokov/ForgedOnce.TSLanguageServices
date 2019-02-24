using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class TsInterfaceMember
    {
        public string Name { get; set; }

        public bool IsOptional { get; set; }

        public TypeConstraint TypeConstraint { get; set; }
    }
}
