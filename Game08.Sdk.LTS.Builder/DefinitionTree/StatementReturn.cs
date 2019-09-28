using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class StatementReturn : StatementNode
    {
        private ExpressionNode expression;

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
            return new LTSModel.StatementReturn()
            {
                Expression = this.Expression != null ? (LTSModel.ExpressionNode)this.Expression.ToLtsModelNode() : null
            };
        }
    }
}
