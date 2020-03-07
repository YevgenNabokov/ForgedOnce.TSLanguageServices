using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
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
