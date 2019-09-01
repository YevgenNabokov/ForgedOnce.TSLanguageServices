using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
{
    public class ExpressionInvocation : ExpressionNode
    {
        public ExpressionInvocation()
        {
            this.NodeType = NodeType.ExpressionInvocation;
            this.Arguments = new List<ExpressionNode>();
        }

        public List<ExpressionNode> Arguments;

        public ExpressionNode Expression;
    }
}
