using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Parser
{
    public class TsParser
    {


        public TsModel Parse(string tsFileContent)
        {
            ParserState state = new ParserState();
            TokenAggregator tokenAggregator = new TokenAggregator();
            for (var i = 0; i < tsFileContent.Length; i++)
            {
                var tokens = tokenAggregator.Add(tsFileContent[i]);
                if (tokens != null)
                {
                    foreach (var t in tokens)
                    {
                        state.Tokens.Add(t);
                    }
                }
            }

            return state.Parsers.Root.Parse(state);
        }
    }
}
