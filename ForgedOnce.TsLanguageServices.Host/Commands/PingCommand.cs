using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Host.Commands
{
    public class PingCommand : Command
    {
        public PingCommand()
        {
            this.CommandType = CommandType.Ping;
        }
    }
}
