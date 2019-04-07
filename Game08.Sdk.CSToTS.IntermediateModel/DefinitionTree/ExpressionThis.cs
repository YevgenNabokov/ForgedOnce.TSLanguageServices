using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel.DefinitionTree
{
    public class ExpressionThis : ExpressionNode
    {
        public ExpressionThis()
        {
            this.NodeType = NodeType.ExpressionThis;
        }
    }
}
