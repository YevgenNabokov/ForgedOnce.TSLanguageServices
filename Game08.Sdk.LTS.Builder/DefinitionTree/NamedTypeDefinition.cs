using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public abstract class NamedTypeDefinition : Node
    {
        private Identifier name;

        public Identifier Name
        {
            get => name;
            set
            {
                this.SetAsParentFor(this.name, value);
                this.name = value;
            }
        }

        public string TypeKey;
    }
}
