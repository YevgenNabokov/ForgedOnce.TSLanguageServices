using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
{
    public class ExpressionTypeReference : ExpressionNode
    {
        public ExpressionTypeReference()
        {
            this.NodeType = NodeType.ExpressionTypeReference;
        }

        public TypeReferenceId TypeId;
    }
}
