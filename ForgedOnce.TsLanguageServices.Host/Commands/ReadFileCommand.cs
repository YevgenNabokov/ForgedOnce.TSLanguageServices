using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Host.Commands
{
    public class ReadFileCommand : Command
    {
        public ReadFileCommand()
        {
            this.CommandType = CommandType.ReadFile;
        }

        public string FilePath { get; set; }
    }
}
