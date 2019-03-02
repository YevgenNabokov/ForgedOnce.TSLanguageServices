using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Parser
{
    public class Token
    {
        public Token(string value, int line, int column)
        {
            this.Value = value;
            this.Line = line;
            this.Column = column;
        }

        public string Value { get; set; }

        public int Line { get; set; }

        public int Column { get; set; }

        public static implicit operator string(Token t)
        {
            return t?.Value;
        }
    }
}
