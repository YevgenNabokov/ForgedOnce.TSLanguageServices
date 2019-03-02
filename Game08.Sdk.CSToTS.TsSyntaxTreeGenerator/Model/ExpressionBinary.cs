using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class ExpressionBinary : Expression
    {
        public Expression Left { get; set; }

        public string Operator { get; set; }

        public Expression Right { get; set; }
    }
}
