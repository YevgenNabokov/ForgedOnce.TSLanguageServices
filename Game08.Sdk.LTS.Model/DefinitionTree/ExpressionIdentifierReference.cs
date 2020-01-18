using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
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
