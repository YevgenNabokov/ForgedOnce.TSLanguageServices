using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
{
    public class ExpressionElementAccess : ExpressionNode
    {
        public ExpressionElementAccess()
        {
            this.NodeType = NodeType.ExpressionElementAccess;
        }

        public ExpressionNode Expression;

        public ExpressionNode Index;
    }
}
