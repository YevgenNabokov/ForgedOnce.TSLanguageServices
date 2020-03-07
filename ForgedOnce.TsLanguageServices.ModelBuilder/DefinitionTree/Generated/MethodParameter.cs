using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class MethodParameter : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Node
    {
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier name;
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId typeReference;
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionLiteral defaultValue;
        public MethodParameter()
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

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId TypeReference
        {
            get
            {
                return this.typeReference;
            }

            set
            {
                this.SetAsParentFor(this.typeReference, value);
                this.typeReference = value;
            }
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionLiteral DefaultValue
        {
            get
            {
                return this.defaultValue;
            }

            set
            {
                this.SetAsParentFor(this.defaultValue, value);
                this.defaultValue = value;
            }
        }

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.MethodParameter();
            result.Name = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.Identifier)this.Name?.ToLtsModelNode();
            result.TypeReference = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.TypeReferenceId)this.TypeReference?.ToLtsModelNode();
            result.DefaultValue = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionLiteral)this.DefaultValue?.ToLtsModelNode();
            return result;
        }
    }
}