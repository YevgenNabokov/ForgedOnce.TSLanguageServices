using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
{
    public class ExpressionUnary : ExpressionNode
    {
        public ExpressionUnary()
        {
            this.NodeType = NodeType.ExpressionUnary;
        }

        public ExpressionNode Left;        

        public string Operator;
    }
}
