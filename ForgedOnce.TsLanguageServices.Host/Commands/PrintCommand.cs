using ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Host.Commands
{
    public class PrintCommand : Command
    {
        public PrintCommand()
        {
            this.CommandType = CommandType.Print;
        }

        public string AstPayload { get; set; }

        public ScriptKind ScriptKind { get; set; }
    }
}
