using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class TypeConstraintExactType : TypeConstraint
    {
        public TypeReference TypeName { get; set; }
    }
}
