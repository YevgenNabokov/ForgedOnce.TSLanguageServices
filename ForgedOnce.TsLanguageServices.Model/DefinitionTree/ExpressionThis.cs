using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
{
    public class ExpressionThis : ExpressionNode
    {
        public ExpressionThis()
        {
            this.NodeType = NodeType.ExpressionThis;
        }
    }
}
