using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class EnumDefinition : NamedTypeDefinition
    {
        public EnumDefinition()
        {
            this.Modifiers = new List<LTSModel.Modifier>();
            this.Members = new BuilderNodeCollection<EnumMember>(this);
        }

        public List<LTSModel.Modifier> Modifiers { get; private set; }

        public BuilderNodeCollection<EnumMember> Members { get; private set; }

        public override LTSModel.Node ToLtsModelNode()
        {
            return new LTSModel.EnumDefinition()
            {
                Modifiers = new List<LTSModel.Modifier>(this.Modifiers),
                Members = this.Members.Select(m => (LTSModel.EnumMember)m.ToLtsModelNode()).ToList(),
                Name = this.Name?.Name,
                TypeKey = this.TypeKey
            };
        }
    }
}
