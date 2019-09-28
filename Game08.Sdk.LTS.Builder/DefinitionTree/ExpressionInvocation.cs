using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class ExpressionInvocation : ExpressionNode
    {
        private ExpressionNode expression;

        public ExpressionInvocation()
        {
            this.Arguments = new BuilderNodeCollection<ExpressionNode>(this);
        }

        public BuilderNodeCollection<ExpressionNode> Arguments { get; private set; }

        public ExpressionNode Expression
        {
            get => expression;
            set
            {
                this.SetAsParentFor(this.expression, value);
                this.expression = value;
            }
        }

        public override LTSModel.Node ToLtsModelNode()
        {
            return new LTSModel.ExpressionInvocation()
            {
                Arguments = this.Arguments.Select(a => (LTSModel.ExpressionNode)a.ToLtsModelNode()).ToList(),
                Expression = this.Expression != null ? (LTSModel.ExpressionNode)this.Expression.ToLtsModelNode() : null
            };
        }
    }
}
