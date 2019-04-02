using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel.DefinitionTree
{
    public class ExpressionLiteral : ExpressionNode
    {
        public ExpressionLiteral()
        {
            this.NodeType = NodeType.ExpressionLiteral;
        }

        public string Text;

        public bool IsQuoted;
    }
}
