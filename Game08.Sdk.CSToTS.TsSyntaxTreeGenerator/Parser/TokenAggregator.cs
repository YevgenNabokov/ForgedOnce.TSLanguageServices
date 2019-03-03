using Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Parser
{
    public class TokenAggregator
    {
        private readonly string[] knownTokens = new string[]
        {
            "{", "}", ";", ".", ",", "|", ":", "(", ")", "[", "]", "<<", ">>", "=", "/*", "*/", "//", "@", "?", "<", ">", "\"", "\r\n", " ", "*", "/"
        };

        private TextPositionTracker parsingPosition = new TextPositionTracker();

        private TextPositionTracker bufferPosition = new TextPositionTracker();

        private StringBuilder currentBuffer = new StringBuilder();        

        private List<Token> candidates = new List<Token>();

        private List<Token> newCandidates = new List<Token>();

        private List<Token> results = new List<Token>();

        public Token[] Add(char? c)
        {
            Token[] result = null;

            if (c.HasValue)
            {
                this.currentBuffer.Append(c);
            }

            Token m = null;

            while (this.Match(out m))
            {
                results.Add(m);
            }

            if (results.Count > 0)
            {
                result = results.ToArray();
                results.Clear();
            }

            if (c.HasValue)
            {
                this.parsingPosition.AdvancePosition(c.Value);
            }

            return result;
        }

        private bool Match(out Token result)
        {
            if (candidates.Count > 0)
            {
                Token bestMatch = null;
                foreach (var c in candidates)
                {
                    if (this.currentBuffer.StartsWith(c))
                    {
                        bestMatch = bestMatch == null ? c : c.Value.Length > bestMatch.Value.Length ? c : bestMatch;
                    }

                    if (c.Value.StartsWith(this.currentBuffer) && c.Value.Length > this.currentBuffer.Length)
                    {
                        newCandidates.Add(c);
                    }
                }

                this.newCandidates = Interlocked.Exchange<List<Token>>(ref this.candidates, this.newCandidates);
                this.newCandidates.Clear();

                if (candidates.Count == 0)
                {
                    if (bestMatch != null)
                    {
                        this.currentBuffer.Remove(0, bestMatch.Value.Length);
                        this.bufferPosition.AdvancePosition(bestMatch);
                        result = bestMatch;
                        return true;
                    }
                    else
                    {
                        if (this.candidates.Count == 0)
                        {
                            throw new InvalidOperationException($"Token not recognized in Line: {this.parsingPosition.LineNumber}, Position: {this.parsingPosition.CharPos}, Char: {this.currentBuffer[0]}");
                        }
                    }
                }
            }
            else
            {
                bool bufferContainsWord = true;
                for (var i = 0; i < this.currentBuffer.Length; i++)
                {
                    if (this.CharIsPartOfIdentifier(this.currentBuffer[i]))
                    {
                        continue;
                    }
                    else
                    {
                        if (i > 0)
                        {
                            result = new Token(this.currentBuffer.ToString().Substring(0, i), this.bufferPosition.LineNumber, this.bufferPosition.CharPos);
                            this.bufferPosition.AdvancePosition(result);
                            this.currentBuffer.Remove(0, i);
                            return true;
                        }

                        bufferContainsWord = false;
                    }
                }

                if (!bufferContainsWord)
                {
                    foreach (var t in this.knownTokens)
                    {
                        if (t.StartsWith(this.currentBuffer))
                        {
                            this.candidates.Add(new Token(t, this.bufferPosition.LineNumber, this.bufferPosition.CharPos));
                        }
                    }

                    if (this.candidates.Count == 1 && this.candidates[0].Value.Length == this.currentBuffer.Length)
                    {
                        result = new Token(this.currentBuffer.ToString(), this.bufferPosition.LineNumber, this.bufferPosition.CharPos);
                        this.bufferPosition.AdvancePosition(result);
                        this.currentBuffer.Clear();
                        this.candidates.Clear();
                        return true;
                    }
                }
            }

            result = null;
            return false;
        }

        public bool CharIsPartOfIdentifier(char c)
        {
            return char.IsLetterOrDigit(c) || c == '_';
        }
    }
}
