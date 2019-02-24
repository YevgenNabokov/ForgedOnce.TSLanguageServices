using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Parser
{
    public class ParserState
    {
        public Stack<ParserContext> Context { get; private set; }

        public ParserState()
        {
            this.Context = new Stack<ParserContext>();            
        }
    }
}
