using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
{
    public class StatementIf : StatementNode
    {
        public StatementIf()
        {
            this.NodeType = NodeType.StatementIf;
        }

        public ExpressionNode Expression;

        public StatementNode Then;

        public StatementNode Else;
    }
}
