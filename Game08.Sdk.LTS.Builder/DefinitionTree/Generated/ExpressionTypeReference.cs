using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class ExpressionTypeReference : Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode
    {
        Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId typeId;
        public ExpressionTypeReference()
        {
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId TypeId
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

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.ExpressionTypeReference();
            result.TypeId = (Game08.Sdk.LTS.Model.DefinitionTree.TypeReferenceId)this.TypeId?.ToLtsModelNode();
            return result;
        }
    }
}