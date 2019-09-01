using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
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
