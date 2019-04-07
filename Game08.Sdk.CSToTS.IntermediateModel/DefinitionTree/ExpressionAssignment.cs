using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel.DefinitionTree
{
    public class ExpressionAssignment : ExpressionNode
    {
        public ExpressionAssignment()
        {
            this.NodeType = NodeType.ExpressionAssignment;
        }

        public ExpressionNode Left;

        public ExpressionNode Right;
    }
}
