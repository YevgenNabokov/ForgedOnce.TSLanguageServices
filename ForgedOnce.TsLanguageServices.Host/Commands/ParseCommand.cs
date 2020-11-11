using ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Host.Commands
{
    public class ParseCommand : Command
    {
        public ParseCommand()
        {
            this.CommandType = CommandType.Parse;
        }

        public string Payload { get; set; }

        public ScriptKind ScriptKind { get; set; }
    }
}
