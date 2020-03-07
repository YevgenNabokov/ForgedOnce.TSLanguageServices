using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
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
