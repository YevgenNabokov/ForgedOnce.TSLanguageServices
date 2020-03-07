using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class ExpressionIdentifierReference : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode
    {
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier name;
        public ExpressionIdentifierReference()
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

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionIdentifierReference();
            result.Name = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.Identifier)this.Name?.ToLtsModelNode();
            return result;
        }
    }
}