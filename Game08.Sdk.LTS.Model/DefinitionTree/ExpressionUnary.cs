using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
{
    public class ExpressionUnary : ExpressionNode
    {
        public ExpressionUnary()
        {
            this.NodeType = NodeType.ExpressionBinary;
        }

        public ExpressionNode Left;        

        public string Operator;
    }
}
