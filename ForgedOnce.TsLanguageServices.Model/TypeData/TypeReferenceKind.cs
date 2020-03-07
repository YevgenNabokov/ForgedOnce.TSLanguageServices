using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.TypeData
{
    public enum TypeReferenceKind
    {
        Builtin,
        Defined,
        External,
        LocalGeneric,
        Inline,
        Union
    }
}
