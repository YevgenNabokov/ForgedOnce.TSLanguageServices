using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class StatementReturn : Game08.Sdk.LTS.Builder.DefinitionTree.StatementNode
    {
        Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode expression;
        public StatementReturn()
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
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.StatementReturn();
            result.Expression = (Game08.Sdk.LTS.Model.DefinitionTree.ExpressionNode)this.Expression?.ToLtsModelNode();
            return result;
        }
    }
}