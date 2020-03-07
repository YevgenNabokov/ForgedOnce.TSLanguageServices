using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
{
    public class ExpressionIdentifierReference : ExpressionNode
    {
        public ExpressionIdentifierReference()
        {
            this.NodeType = NodeType.ExpressionIdentifierReference;
        }

        public Identifier Name;
    }
}
