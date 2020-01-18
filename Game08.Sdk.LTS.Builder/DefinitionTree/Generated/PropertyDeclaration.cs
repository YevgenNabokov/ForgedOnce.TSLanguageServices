using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class PropertyDeclaration : Game08.Sdk.LTS.Builder.DefinitionTree.Node
    {
        Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId typeReference;
        Game08.Sdk.LTS.Builder.DefinitionTree.Identifier name;
        Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration getter;
        Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration setter;
        public PropertyDeclaration()
        {
            this.Modifiers = new System.Collections.Generic.List<Game08.Sdk.LTS.Model.DefinitionTree.Modifier>();
        }

        public System.Collections.Generic.List<Game08.Sdk.LTS.Model.DefinitionTree.Modifier> Modifiers
        {
            get;
            private set;
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

        public Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration Getter
        {
            get
            {
                return this.getter;
            }

            set
            {
                this.SetAsParentFor(this.getter, value);
                this.getter = value;
            }
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration Setter
        {
            get
            {
                return this.setter;
            }

            set
            {
                this.SetAsParentFor(this.setter, value);
                this.setter = value;
            }
        }

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.PropertyDeclaration();
            result.Modifiers = new System.Collections.Generic.List<Game08.Sdk.LTS.Model.DefinitionTree.Modifier>(this.Modifiers);
            result.TypeReference = (Game08.Sdk.LTS.Model.DefinitionTree.TypeReferenceId)this.TypeReference?.ToLtsModelNode();
            result.Name = (Game08.Sdk.LTS.Model.DefinitionTree.Identifier)this.Name?.ToLtsModelNode();
            result.Getter = (Game08.Sdk.LTS.Model.DefinitionTree.MethodDeclaration)this.Getter?.ToLtsModelNode();
            result.Setter = (Game08.Sdk.LTS.Model.DefinitionTree.MethodDeclaration)this.Setter?.ToLtsModelNode();
            return result;
        }
    }
}