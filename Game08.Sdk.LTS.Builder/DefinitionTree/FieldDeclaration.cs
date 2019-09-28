using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class FieldDeclaration : Node
    {
        private Identifier name;

        private TypeReferenceId typeReference;

        private ExpressionNode initializer;

        public FieldDeclaration()
        {
            this.Modifiers = new List<LTSModel.Modifier>();
        }

        public List<LTSModel.Modifier> Modifiers { get; private set; }

        public TypeReferenceId TypeReference
        {
            get => typeReference;
            set
            {
                this.SetAsParentFor(this.typeReference, value);
                this.typeReference = value;
            }
        }

        public Identifier Name
        {
            get => name;
            set
            {
                this.SetAsParentFor(this.name, value);
                this.name = value;
            }
        }

        public ExpressionNode Initializer
        {
            get => initializer;
            set
            {
                this.SetAsParentFor(this.initializer, value);
                this.initializer = value;
            }
        }

        public override LTSModel.Node ToLtsModelNode()
        {
            return new LTSModel.FieldDeclaration()
            {
                Modifiers = new List<LTSModel.Modifier>(this.Modifiers),
                TypeReference = this.TypeReference != null ? (LTSModel.TypeReferenceId)this.TypeReference.ToLtsModelNode() : null,
                Name = this.Name?.Name,
                Initializer = this.Initializer != null ? (LTSModel.ExpressionNode)this.Initializer.ToLtsModelNode() : null
            };
        }
    }
}
