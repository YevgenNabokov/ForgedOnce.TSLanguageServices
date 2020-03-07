using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
{
    public class ExpressionMemberAccess : ExpressionNode
    {
        public ExpressionMemberAccess()
        {
            this.NodeType = NodeType.ExpressionMemberAccess;
        }

        public ExpressionNode Expression;

        public Identifier Name;
    }
}
