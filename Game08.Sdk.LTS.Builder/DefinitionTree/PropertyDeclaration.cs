using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class PropertyDeclaration : Node
    {
        private Identifier name;

        private TypeReferenceId typeReference;

        private MethodDeclaration getter;

        private MethodDeclaration setter;

        public PropertyDeclaration()
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

        public MethodDeclaration Getter
        {
            get => getter;
            set
            {
                this.SetAsParentFor(this.getter, value);
                this.getter = value;
            }
        }

        public MethodDeclaration Setter
        {
            get => setter;
            set
            {
                this.SetAsParentFor(this.setter, value);
                this.setter = value;
            }
        }

        public override LTSModel.Node ToLtsModelNode()
        {
            return new LTSModel.PropertyDeclaration()
            {
                Modifiers = new List<LTSModel.Modifier>(this.Modifiers),
                TypeReference = this.TypeReference != null ? (LTSModel.TypeReferenceId)this.TypeReference.ToLtsModelNode() : null,
                Name = this.Name?.Name,
                Getter = this.Getter != null ? (LTSModel.MethodDeclaration)this.Getter.ToLtsModelNode() : null,
                Setter = this.Setter != null ? (LTSModel.MethodDeclaration)this.Setter.ToLtsModelNode() : null
            };
        }
    }
}
