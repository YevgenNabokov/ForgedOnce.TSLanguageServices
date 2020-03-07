using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
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
