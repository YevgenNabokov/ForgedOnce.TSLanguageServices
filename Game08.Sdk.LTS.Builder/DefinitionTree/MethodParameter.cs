using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class MethodParameter : Node
    {
        private Identifier name;

        private TypeReferenceId typeReference;

        private ExpressionLiteral defaultValue;

        public Identifier Name
        {
            get => name;
            set
            {
                this.SetAsParentFor(this.name, value);
                this.name = value;
            }
        }

        public TypeReferenceId TypeReference
        {
            get => typeReference;
            set
            {
                this.SetAsParentFor(this.typeReference, value);
                this.typeReference = value;
            }
        }

        public ExpressionLiteral DefaultValue
        {
            get => defaultValue;
            set
            {
                this.SetAsParentFor(this.defaultValue, value);
                this.defaultValue = value;
            }
        }

        public override LTSModel.Node ToLtsModelNode()
        {
            return new LTSModel.MethodParameter()
            {
                Name = this.Name?.Name,
                TypeReference = this.TypeReference != null ? (LTSModel.TypeReferenceId)this.TypeReference.ToLtsModelNode() : null,
                DefaultValue = this.DefaultValue != null ? (LTSModel.ExpressionLiteral)this.DefaultValue.ToLtsModelNode() : null
            };
        }
    }
}
