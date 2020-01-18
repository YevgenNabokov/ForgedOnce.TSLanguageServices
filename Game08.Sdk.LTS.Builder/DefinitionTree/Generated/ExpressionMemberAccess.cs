using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class ExpressionMemberAccess : Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode
    {
        Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode expression;
        Game08.Sdk.LTS.Builder.DefinitionTree.Identifier name;
        public ExpressionMemberAccess()
        {
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode Expression
        {
            get
            {
                return this.expression;
            }

            set
            {
                this.SetAsParentFor(this.expression, value);
                this.expression = value;
            }
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
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.ExpressionMemberAccess();
            result.Expression = (Game08.Sdk.LTS.Model.DefinitionTree.ExpressionNode)this.Expression?.ToLtsModelNode();
            result.Name = (Game08.Sdk.LTS.Model.DefinitionTree.Identifier)this.Name?.ToLtsModelNode();
            return result;
        }
    }
}