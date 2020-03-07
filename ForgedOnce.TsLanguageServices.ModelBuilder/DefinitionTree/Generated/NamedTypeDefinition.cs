using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public abstract partial class NamedTypeDefinition : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Node
    {
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier name;
        string typeKey;
        public NamedTypeDefinition()
        {
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier Name
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
                this.EnsureIsEditable();
                this.typeKey = value;
            }
        }
    }
}