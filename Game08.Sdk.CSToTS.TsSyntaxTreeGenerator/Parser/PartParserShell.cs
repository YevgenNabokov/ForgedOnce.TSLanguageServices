using Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Parser
{
    public class PartParserShell<T> : IPartParser<T>
    {
        public ParserContext Context { get; private set; }

        public PartParserShell(ParserContext context, Func<ParserState, T> implementation)
        {
            this.Context = context;
            this.Implementation = implementation;
        }

        public T Parse(ParserState state)
        {
            state.Context.Push(this.Context);

            var result = this.Implementation(state);

            var c = state.Context.Pop();

            if (c != this.Context)
            {
                throw new InvalidOperationException($"Inconsistent parser context, epected {this.Context}");
            }

            return result;
        }

        private Func<ParserState, T> Implementation { get; set; }
    }
}
