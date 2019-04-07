using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel.DefinitionTree
{
    public class ExpressionIdentifierReference : ExpressionNode
    {
        public ExpressionIdentifierReference()
        {
            this.NodeType = NodeType.ExpressionIdentifierReference;
        }

        public string Name;
    }
}
