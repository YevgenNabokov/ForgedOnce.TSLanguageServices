using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel.DefinitionTree
{
    public class ExpressionMemberAccess : ExpressionNode
    {
        public ExpressionMemberAccess()
        {
            this.NodeType = NodeType.ExpressionMemberAccess;
        }

        public ExpressionNode Expression;

        public string Name;
    }
}
