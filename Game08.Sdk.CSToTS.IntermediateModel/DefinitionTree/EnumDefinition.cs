using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel.DefinitionTree
{
    public class EnumDefinition : Node
    {
        public EnumDefinition()
        {
            this.NodeType = NodeType.EnumDefinition;
            this.Members = new List<EnumMember>();
        }

        public string Name;

        public string TypeKey;

        public List<Modifier> Modifiers;

        public List<EnumMember> Members;
    }
}
