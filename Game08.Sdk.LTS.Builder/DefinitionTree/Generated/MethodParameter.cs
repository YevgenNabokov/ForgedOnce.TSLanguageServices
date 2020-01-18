using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class MethodParameter : Game08.Sdk.LTS.Builder.DefinitionTree.Node
    {
        Game08.Sdk.LTS.Builder.DefinitionTree.Identifier name;
        Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId typeReference;
        Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionLiteral defaultValue;
        public MethodParameter()
        {
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.Identifier Name
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

        public Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId TypeReference
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

        public Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionLiteral DefaultValue
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

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.MethodParameter();
            result.Name = (Game08.Sdk.LTS.Model.DefinitionTree.Identifier)this.Name?.ToLtsModelNode();
            result.TypeReference = (Game08.Sdk.LTS.Model.DefinitionTree.TypeReferenceId)this.TypeReference?.ToLtsModelNode();
            result.DefaultValue = (Game08.Sdk.LTS.Model.DefinitionTree.ExpressionLiteral)this.DefaultValue?.ToLtsModelNode();
            return result;
        }
    }
}