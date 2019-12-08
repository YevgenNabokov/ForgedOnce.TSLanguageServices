using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class ExpressionUnary : ExpressionNode
    {
        private ExpressionNode left;        

        public ExpressionNode Left
        {
            get => left;
            set
            {
                this.SetAsParentFor(this.left, value);
                this.left = value;
            }
        }

        public string Operator;

        public override LTSModel.Node ToLtsModelNode()
        {
            return new LTSModel.ExpressionUnary()
            {
                Left = this.Left != null ? (LTSModel.ExpressionNode)this.Left.ToLtsModelNode() : null,
                Operator = this.Operator
            };
        }
    }
}
