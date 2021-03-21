using ForgedOnce.TsLanguageServices.Host.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Host.Interfaces
{
    public interface ITsHostLogger
    {
        void WriteLog(LogMessageSeverity severity, string message);
    }
}
