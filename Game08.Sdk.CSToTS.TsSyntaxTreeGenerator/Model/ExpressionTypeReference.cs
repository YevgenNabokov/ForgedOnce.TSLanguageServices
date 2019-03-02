using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class ExpressionTypeReference : Expression
    {
        public TypeReference Reference { get; set; }
    }
}
