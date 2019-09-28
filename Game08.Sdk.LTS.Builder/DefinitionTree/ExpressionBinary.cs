using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class ExpressionBinary : ExpressionNode
    {
        private ExpressionNode left;

        private ExpressionNode right;

        public ExpressionNode Left
        {
            get => left;
            set
            {
                this.SetAsParentFor(this.left, value);
                this.left = value;
            }
        }

        public ExpressionNode Right
        {
            get => right;
            set
            {
                this.SetAsParentFor(this.right, value);
                this.right = value;
            }
        }

        public string Operator;

        public override LTSModel.Node ToLtsModelNode()
        {
            return new LTSModel.ExpressionBinary()
            {
                Left = this.Left != null ? (LTSModel.ExpressionNode)this.Left.ToLtsModelNode() : null,
                Right = this.Right != null ? (LTSModel.ExpressionNode)this.Right.ToLtsModelNode() : null,
                Operator = this.Operator
            };
        }
    }
}
