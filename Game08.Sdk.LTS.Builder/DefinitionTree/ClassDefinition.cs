using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class ClassDefinition : NamedTypeDefinition
    {
        private TypeReferenceId baseType;

        private ConstructorDeclaration constructor;

        public ClassDefinition()
        {
            this.Modifiers = new List<LTSModel.Modifier>();
            this.Implements = new BuilderNodeCollection<TypeReferenceId>(this);
            this.Fields = new BuilderNodeCollection<FieldDeclaration>(this);
            this.Methods = new BuilderNodeCollection<MethodDeclaration>(this);
            this.Properties = new BuilderNodeCollection<PropertyDeclaration>(this);
        }

        public List<LTSModel.Modifier> Modifiers { get; private set; }

        public TypeReferenceId BaseType
        {
            get => baseType;
            set
            {
                this.SetAsParentFor(this.baseType, value);
                this.baseType = value;
            }
        }

        public BuilderNodeCollection<TypeReferenceId> Implements { get; private set; }

        public BuilderNodeCollection<FieldDeclaration> Fields { get; private set; }

        public BuilderNodeCollection<MethodDeclaration> Methods { get; private set; }

        public BuilderNodeCollection<PropertyDeclaration> Properties { get; private set; }

        public ConstructorDeclaration Constructor
        {
            get => constructor;
            set
            {
                this.SetAsParentFor(this.constructor, value);
                this.constructor = value;
            }
        }

        public override LTSModel.Node ToLtsModelNode()
        {
            return new LTSModel.ClassDefinition()
            {
                Modifiers = new List<LTSModel.Modifier>(this.Modifiers),
                BaseType = this.BaseType != null ? (LTSModel.TypeReferenceId)this.BaseType.ToLtsModelNode() : null,
                Implements = this.Implements.Select(i => (LTSModel.TypeReferenceId)i.ToLtsModelNode()).ToList(),
                Fields = this.Fields.Select(i => (LTSModel.FieldDeclaration)i.ToLtsModelNode()).ToList(),
                Methods = this.Methods.Select(i => (LTSModel.MethodDeclaration)i.ToLtsModelNode()).ToList(),
                Properties = this.Properties.Select(i => (LTSModel.PropertyDeclaration)i.ToLtsModelNode()).ToList(),
                Constructor = this.Constructor != null ? (LTSModel.ConstructorDeclaration)this.Constructor.ToLtsModelNode() : null,
                Name = this.Name?.Name,
                TypeKey = this.TypeKey
            };
        }
    }
}
