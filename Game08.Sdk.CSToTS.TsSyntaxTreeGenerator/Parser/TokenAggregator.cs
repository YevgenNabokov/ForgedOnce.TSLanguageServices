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

        private int lineNumber = 1;

        private int charPos = 1;

        private StringBuilder currentBuffer = new StringBuilder();        

        private List<string> candidates = new List<string>();

        private List<string> newCandidates = new List<string>();

        private List<string> results = new List<string>();

        private bool cRet = false;

        public string[] Add(char? c)
        {
            string[] result = null;

            if (c.HasValue)
            {
                this.currentBuffer.Append(c);
            }

            string m = string.Empty;

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
                this.AdvancePosition(c.Value);
            }

            return result;
        }

        private void AdvancePosition(char c)
        {
            if (c == '\r')
            {
                this.cRet = true;
            }
            else
            {
                if (c == '\n')
                {
                    if (cRet)
                    {
                        this.lineNumber++;
                        this.charPos = 1;
                    }

                    this.cRet = false;
                }
                else
                {
                    this.charPos++;
                }
            }
        }

        private bool Match(out string result)
        {
            if (candidates.Count > 0)
            {
                string bestMatch = null;
                foreach (var c in candidates)
                {
                    if (this.currentBuffer.StartsWith(c))
                    {
                        bestMatch = bestMatch == null ? c : c.Length > bestMatch.Length ? c : bestMatch;
                    }

                    if (c.StartsWith(this.currentBuffer) && c.Length > this.currentBuffer.Length)
                    {
                        newCandidates.Add(c);
                    }
                }

                this.newCandidates = Interlocked.Exchange<List<string>>(ref this.candidates, this.newCandidates);
                this.newCandidates.Clear();

                if (candidates.Count == 0)
                {
                    if (bestMatch != null)
                    {
                        this.currentBuffer.Remove(0, bestMatch.Length);
                        result = bestMatch;
                        return true;
                    }
                    else
                    {
                        if (this.candidates.Count == 0)
                        {
                            throw new InvalidOperationException($"Token not recognized in Line: {this.lineNumber}, Position: {this.charPos}, Char: {this.currentBuffer[0]}");
                        }
                    }
                }
            }
            else
            {
                bool bufferContainsWord = true;
                for (var i = 0; i < this.currentBuffer.Length; i++)
                {
                    if (Char.IsLetter(this.currentBuffer[i]))
                    {
                        continue;
                    }
                    else
                    {
                        if (i > 0)
                        {
                            result = this.currentBuffer.ToString().Substring(0, i);
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
                            this.candidates.Add(t);
                        }
                    }

                    if (this.candidates.Count == 1 && this.candidates[0].Length == this.currentBuffer.Length)
                    {
                        result = this.currentBuffer.ToString();
                        this.currentBuffer.Clear();
                        this.candidates.Clear();
                        return true;
                    }
                }
            }

            result = null;
            return false;
        }
    }
}
