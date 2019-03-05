using Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Parser
{
    public class TsParser
    {


        public TsModel Parse(string tsFileContent, HashSet<string> skipDefinitions)
        {
            ParserState state = new ParserState();
            state.SkipDefinitions = skipDefinitions;
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
