using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class EnumDefinition : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.NamedTypeDefinition
    {
        public EnumDefinition()
        {
            this.Modifiers = new System.Collections.Generic.List<ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier>();
            this.Members = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.EnumMember>(this);
        }

        public System.Collections.Generic.List<ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier> Modifiers
        {
            get;
            private set;
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.EnumMember> Members
        {
            get;
            private set;
        }

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.EnumDefinition();
            result.Modifiers = new System.Collections.Generic.List<ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier>(this.Modifiers);
            result.Members = this.Members.Select((i) => (ForgedOnce.TsLanguageServices.Model.DefinitionTree.EnumMember)i.ToLtsModelNode()).ToList();
            result.Name = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.Identifier)this.Name?.ToLtsModelNode();
            result.TypeKey = this.TypeKey;
            return result;
        }
    }
}