using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
{
    public class ExpressionBinary : ExpressionNode
    {
        public ExpressionBinary()
        {
            this.NodeType = NodeType.ExpressionBinary;
        }

        public ExpressionNode Left;

        public ExpressionNode Right;

        public string Operator;
    }
}
