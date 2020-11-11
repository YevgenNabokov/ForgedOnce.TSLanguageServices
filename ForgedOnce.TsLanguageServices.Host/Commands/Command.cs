using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Host.Commands
{
    public abstract class Command
    {
        public CommandType CommandType { get; set; }
    }
}
