using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.TypeData
{
    public class TypeCache
    {
        public Dictionary<string, TypeDefinition> Definitions;

        public Dictionary<string, TypeReference> References;
    }
}
