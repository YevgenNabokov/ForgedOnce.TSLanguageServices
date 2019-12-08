using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
{
    public class ExpressionNew : ExpressionNode
    {
        public ExpressionNew()
        {
            this.NodeType = NodeType.ExpressionNew;
            this.Arguments = new List<ExpressionNode>();
        }

        public List<ExpressionNode> Arguments;

        public TypeReferenceId SubjectType;
    }
}
