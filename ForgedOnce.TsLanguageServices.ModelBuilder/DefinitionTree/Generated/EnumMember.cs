using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class EnumMember : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Node
    {
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier name;
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode value;
        public EnumMember()
        {
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.SetAsParentFor(this.name, value);
                this.name = value;
            }
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.SetAsParentFor(this.value, value);
                this.value = value;
            }
        }

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.EnumMember();
            result.Name = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.Identifier)this.Name?.ToLtsModelNode();
            result.Value = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionNode)this.Value?.ToLtsModelNode();
            return result;
        }
    }
}