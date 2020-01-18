using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class ExpressionIdentifierReference : Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode
    {
        Game08.Sdk.LTS.Builder.DefinitionTree.Identifier name;
        public ExpressionIdentifierReference()
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

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.ExpressionIdentifierReference();
            result.Name = (Game08.Sdk.LTS.Model.DefinitionTree.Identifier)this.Name?.ToLtsModelNode();
            return result;
        }
    }
}