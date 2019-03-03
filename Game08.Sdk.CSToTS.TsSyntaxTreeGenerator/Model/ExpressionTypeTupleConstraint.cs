using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class ExpressionTypeTupleConstraint : Expression
    {
        public List<Expression> Constraint { get; set; }
    }
}
