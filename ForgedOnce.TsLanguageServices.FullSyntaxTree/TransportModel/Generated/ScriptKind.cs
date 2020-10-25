using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public enum ScriptKind
    {
        Unknown = 0,
        JS = 1,
        JSX = 2,
        TS = 3,
        TSX = 4,
        External = 5,
        JSON = 6,
        Deferred = 7
    }
}