using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class TypeComposition : TypeConstraint
    {
        public List<TypeConstraint> Parts { get; private set; }

        public CompositionType CompositionType { get; set; }

        public TypeComposition()
        {
            this.Parts = new List<TypeConstraint>();
        }
    }

    public enum CompositionType
    {
        Or,
        And
    }
}
