using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
{
    public abstract class NamedTypeDefinition : Node
    {
        public Identifier Name;

        public string TypeKey;
    }
}
