using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public abstract partial class NamedTypeDefinition : Game08.Sdk.LTS.Builder.DefinitionTree.Node
    {
        Game08.Sdk.LTS.Builder.DefinitionTree.Identifier name;
        string typeKey;
        public NamedTypeDefinition()
        {
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.Identifier Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.SetAsParentFor(this.name, value);
                this.name = value;
            }
        }

        public string TypeKey
        {
            get
            {
                return this.typeKey;
            }

            set
            {
                this.typeKey = value;
            }
        }
    }
}