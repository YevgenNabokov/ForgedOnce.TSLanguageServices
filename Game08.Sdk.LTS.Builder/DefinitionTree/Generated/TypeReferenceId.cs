using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class TypeReferenceId : Game08.Sdk.LTS.Builder.DefinitionTree.Node
    {
        string referenceKey;
        public TypeReferenceId()
        {
        }

        public string ReferenceKey
        {
            get
            {
                return this.referenceKey;
            }

            set
            {
                this.referenceKey = value;
            }
        }

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.TypeReferenceId();
            result.ReferenceKey = this.ReferenceKey;
            return result;
        }
    }
}