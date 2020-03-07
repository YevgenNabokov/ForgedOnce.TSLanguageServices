using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
{
    public class StatementReturn : StatementNode
    {
        public StatementReturn()
        {
            this.NodeType = NodeType.StatementReturn;            
        }

        public ExpressionNode Expression;
    }
}
