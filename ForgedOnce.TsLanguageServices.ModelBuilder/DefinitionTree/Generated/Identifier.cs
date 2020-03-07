using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class Identifier : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Node
    {
        string name;
        public Identifier()
        {
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.EnsureIsEditable();
                this.name = value;
            }
        }

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.Identifier();
            result.Name = this.Name;
            return result;
        }
    }
}