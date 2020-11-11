using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Host.Commands
{
    public class ShutdownCommand : Command
    {
        public ShutdownCommand()
        {
            this.CommandType = CommandType.Shutdown;
        }
    }
}
