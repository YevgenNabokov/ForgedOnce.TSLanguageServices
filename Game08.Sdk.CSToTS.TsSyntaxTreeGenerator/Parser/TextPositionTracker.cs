using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Parser
{
    public class TextPositionTracker
    {
        public int LineNumber { get; private set; } = 1;

        public int CharPos { get; private set; } = 1;

        private bool cRet = false;

        public void AdvancePosition(char c)
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
                        this.LineNumber++;
                        this.CharPos = 1;
                    }
                }
                else
                {
                    this.CharPos++;
                }

                this.cRet = false;
            }
        }

        public void AdvancePosition(string s)
        {
            foreach(var c in s)
            {
                this.AdvancePosition(c);
            }
        }
    }
}
