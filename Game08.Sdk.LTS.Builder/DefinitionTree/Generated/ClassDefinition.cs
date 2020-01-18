using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class ClassDefinition : Game08.Sdk.LTS.Builder.DefinitionTree.NamedTypeDefinition
    {
        Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId baseType;
        Game08.Sdk.LTS.Builder.DefinitionTree.ConstructorDeclaration constructor;
        public ClassDefinition()
        {
            this.Modifiers = new System.Collections.Generic.List<Game08.Sdk.LTS.Model.DefinitionTree.Modifier>();
            this.Implements = new Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId>(this);
            this.Fields = new Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.FieldDeclaration>(this);
            this.Methods = new Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration>(this);
            this.Properties = new Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.PropertyDeclaration>(this);
        }

        public System.Collections.Generic.List<Game08.Sdk.LTS.Model.DefinitionTree.Modifier> Modifiers
        {
            get;
            private set;
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId BaseType
        {
            get
            {
                return this.baseType;
            }

            set
            {
                this.SetAsParentFor(this.baseType, value);
                this.baseType = value;
            }
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId> Implements
        {
            get;
            private set;
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.FieldDeclaration> Fields
        {
            get;
            private set;
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration> Methods
        {
            get;
            private set;
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.PropertyDeclaration> Properties
        {
            get;
            private set;
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.ConstructorDeclaration Constructor
        {
            get
            {
                return this.constructor;
            }

            set
            {
                this.SetAsParentFor(this.constructor, value);
                this.constructor = value;
            }
        }

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.ClassDefinition();
            result.Modifiers = new System.Collections.Generic.List<Game08.Sdk.LTS.Model.DefinitionTree.Modifier>(this.Modifiers);
            result.BaseType = (Game08.Sdk.LTS.Model.DefinitionTree.TypeReferenceId)this.BaseType?.ToLtsModelNode();
            result.Implements = this.Implements.Select((i) => (Game08.Sdk.LTS.Model.DefinitionTree.TypeReferenceId)i.ToLtsModelNode()).ToList();
            result.Fields = this.Fields.Select((i) => (Game08.Sdk.LTS.Model.DefinitionTree.FieldDeclaration)i.ToLtsModelNode()).ToList();
            result.Methods = this.Methods.Select((i) => (Game08.Sdk.LTS.Model.DefinitionTree.MethodDeclaration)i.ToLtsModelNode()).ToList();
            result.Properties = this.Properties.Select((i) => (Game08.Sdk.LTS.Model.DefinitionTree.PropertyDeclaration)i.ToLtsModelNode()).ToList();
            result.Constructor = (Game08.Sdk.LTS.Model.DefinitionTree.ConstructorDeclaration)this.Constructor?.ToLtsModelNode();
            result.Name = (Game08.Sdk.LTS.Model.DefinitionTree.Identifier)this.Name?.ToLtsModelNode();
            result.TypeKey = this.TypeKey;
            return result;
        }
    }
}