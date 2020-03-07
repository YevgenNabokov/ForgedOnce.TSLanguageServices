using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class TypeReferenceId : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Node
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
                this.EnsureIsEditable();
                this.referenceKey = value;
            }
        }

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.TypeReferenceId();
            result.ReferenceKey = this.ReferenceKey;
            return result;
        }
    }
}