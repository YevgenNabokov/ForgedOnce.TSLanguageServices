using Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Parser
{
    public class ParserState
    {
        private int inlineTypeIndex = -1;

        public Stack<ParserContext> Context { get; private set; }

        public List<Token> Tokens { get; private set; }        

        public int CurrentToken { get; private set; }

        public PartParser Parsers { get; private set; }        

        public List<TsInterface> InlineInterfaces { get; private set; }

        public HashSet<string> SkipDefinitions { get; set; }

        public ParserState()
        {
            this.Parsers = new PartParser();
            this.Context = new Stack<ParserContext>();
            this.Tokens = new List<Token>();     
            this.InlineInterfaces = new List<TsInterface>();
            this.SkipDefinitions = new HashSet<string>();
            this.CurrentToken = 0;
        }

        public string GetNextInlineTypeName()
        {
            this.inlineTypeIndex++;
            return $"InlineType{inlineTypeIndex}";
        }

        public string PeekToken(int position = 0)
        {
            if ((this.CurrentToken + position) < this.Tokens.Count && (this.CurrentToken + position) >= 0)
            {
                return this.Tokens[this.CurrentToken + position];
            }

            return null;
        }

        public string TakeToken()
        {
            string result = null;

            if (this.CurrentToken < this.Tokens.Count)
            {
                result = this.Tokens[this.CurrentToken];
                this.CurrentToken++;
            }

            return result;
        }

        public Modifier? ProcessEmptyAndComments()
        {
            bool isInComment = false;
            Modifier? result = null;

            var nextToken = this.PeekToken();
            while (nextToken == " " || nextToken == "\r\n" || nextToken == "/*" || nextToken == "*/" || nextToken == "//" || isInComment)
            {
                this.TakeToken();
                if (isInComment)
                {
                    if (nextToken == "*/")
                    {
                        isInComment = false;
                    }

                    if (nextToken == "internal" && this.PeekToken(-2) == "@")
                    {
                        result = Modifier.Internal;
                    }
                }
                else
                {
                    if (nextToken == "//")
                    {
                        this.SkipUntilAny(false, "\r\n");
                        nextToken = this.PeekToken();
                        continue;
                    }

                    if (nextToken == "/*")
                    {
                        isInComment = true;
                    }
                }

                nextToken = this.PeekToken();
            }

            return result;
        }

        public string SkipUntilAny(bool outsideCommentSections = true, params string[] tokens)
        {
            if (outsideCommentSections)
            {
                this.ProcessEmptyAndComments();
            }

            var t = TakeToken();

            while (t != null)
            {
                for (var i = 0; i < tokens.Length; i++)
                {
                    if (t == tokens[i])
                    {
                        return t;
                    }
                }

                if (outsideCommentSections)
                {
                    this.ProcessEmptyAndComments();
                }
                t = TakeToken();
            }

            return t;
        }

        public string PeekUntilAny(params string[] tokens)
        {
            int it = 0;
            var t = PeekToken(it);

            while (t != null)
            {
                for (var i = 0; i < tokens.Length; i++)
                {
                    if (t == tokens[i])
                    {
                        return t;
                    }
                }

                it++;
                t = PeekToken(it);
            }

            return t;
        }

        public void RaiseParsingError(string message, int failedTokenOffset = 0, string unexpectedToken = null, params string[] expectedTokens)
        {
            var failedToken = this.Tokens[this.CurrentToken + failedTokenOffset];
            StringBuilder exceptionMessage = new StringBuilder($"Line: { failedToken.Line }, Char: { failedToken.Column } Parsing failed: { message }");

            if (unexpectedToken != null)
            {
                exceptionMessage.Append($"; Unexpected token: '{unexpectedToken}'");
            }

            if(expectedTokens.Length > 0)
            {
                for (var i = 0; i < expectedTokens.Length; i++)
                {
                    expectedTokens[i] = $"'{expectedTokens[i]}'";
                }

                string expected = string.Join(", ", expectedTokens);

                exceptionMessage.Append($"; Expected tokens: {expected}");
            }

            throw new InvalidOperationException(exceptionMessage.ToString());
        }
    }
}
