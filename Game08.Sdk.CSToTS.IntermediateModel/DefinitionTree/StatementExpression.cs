using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel.DefinitionTree
{
    public class StatementExpression : StatementNode
    {
        public StatementExpression()
        {
            this.NodeType = NodeType.StatementExpression;
        }

        public ExpressionNode Expression;
    }
}
