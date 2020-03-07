using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
{
    public class StatementFor : StatementNode
    {
        public StatementFor()
        {
            this.NodeType = NodeType.StatementFor;
        }

        public StatementLocalDeclaration Initializer;

        public ExpressionNode Condition;

        public ExpressionNode Increment;

        public StatementNode Statement;
    }
}
