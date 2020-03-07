using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class ExpressionTypeReference : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode
    {
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId typeId;
        public ExpressionTypeReference()
        {
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId TypeId
        {
            get
            {
                return this.typeId;
            }

            set
            {
                this.SetAsParentFor(this.typeId, value);
                this.typeId = value;
            }
        }

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionTypeReference();
            result.TypeId = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.TypeReferenceId)this.TypeId?.ToLtsModelNode();
            return result;
        }
    }
}