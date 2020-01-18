using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class StatementExpression : Game08.Sdk.LTS.Builder.DefinitionTree.StatementNode
    {
        Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode expression;
        public StatementExpression()
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

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.StatementExpression();
            result.Expression = (Game08.Sdk.LTS.Model.DefinitionTree.ExpressionNode)this.Expression?.ToLtsModelNode();
            return result;
        }
    }
}