using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
{
    public class ExpressionThis : ExpressionNode
    {
        public ExpressionThis()
        {
            this.NodeType = NodeType.ExpressionThis;
        }
    }
}
