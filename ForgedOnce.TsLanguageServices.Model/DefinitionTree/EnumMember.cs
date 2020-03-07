using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
{
    public class EnumMember : Node
    {
        public EnumMember()
        {
            this.NodeType = NodeType.EnumMember;
        }

        public Identifier Name;

        public ExpressionNode Value;
    }
}
