using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Host.Commands
{
    public class WriteFileCommand : Command
    {
        public WriteFileCommand()
        {
            this.CommandType = CommandType.WriteFile;
        }

        public string AstPayload { get; set; }

        public string FileName { get; set; }

        public string Path { get; set; }
    }
}
