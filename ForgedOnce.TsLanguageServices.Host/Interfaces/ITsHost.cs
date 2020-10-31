using ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel;
using ForgedOnce.TsLanguageServices.Host.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Host.Interfaces
{
    public interface ITsHost
    {
        void Start();

        TsFile ReadFile(string filePath);

        IStatement[] Parse(string payload, ScriptKind scriptKind);

        void WriteFile(TsFile file);

        string Print(IStatement[] statements, ScriptKind scriptKind);

        void Ping();

        bool IsAlive();
    }
}
