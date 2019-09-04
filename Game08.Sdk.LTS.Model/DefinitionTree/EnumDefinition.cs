using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
{
    public class EnumDefinition : NamedTypeDefinition
    {
        public EnumDefinition()
        {
            this.NodeType = NodeType.EnumDefinition;
            this.Members = new List<EnumMember>();
        }

        public List<Modifier> Modifiers;

        public List<EnumMember> Members;
    }
}
