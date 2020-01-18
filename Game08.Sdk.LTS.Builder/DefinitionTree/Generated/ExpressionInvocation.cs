using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class ExpressionInvocation : Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode
    {
        Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode expression;
        public ExpressionInvocation()
        {
            this.Arguments = new Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode>(this);
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode> Arguments
        {
            get;
            private set;
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
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.ExpressionInvocation();
            result.Arguments = this.Arguments.Select((i) => (Game08.Sdk.LTS.Model.DefinitionTree.ExpressionNode)i.ToLtsModelNode()).ToList();
            result.Expression = (Game08.Sdk.LTS.Model.DefinitionTree.ExpressionNode)this.Expression?.ToLtsModelNode();
            return result;
        }
    }
}