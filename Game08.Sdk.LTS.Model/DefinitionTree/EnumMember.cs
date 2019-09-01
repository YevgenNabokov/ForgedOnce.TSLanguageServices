using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
{
    public class EnumMember : Node
    {
        public EnumMember()
        {
            this.NodeType = NodeType.EnumMember;
        }

        public string Name;

        public ExpressionNode Value;
    }
}
