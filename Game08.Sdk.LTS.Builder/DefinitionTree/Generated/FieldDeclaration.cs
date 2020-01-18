using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class FieldDeclaration : Game08.Sdk.LTS.Builder.DefinitionTree.Node
    {
        Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId typeReference;
        Game08.Sdk.LTS.Builder.DefinitionTree.Identifier name;
        Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode initializer;
        public FieldDeclaration()
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

        public Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode Initializer
        {
            get
            {
                return this.initializer;
            }

            set
            {
                this.SetAsParentFor(this.initializer, value);
                this.initializer = value;
            }
        }

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.FieldDeclaration();
            result.Modifiers = new System.Collections.Generic.List<Game08.Sdk.LTS.Model.DefinitionTree.Modifier>(this.Modifiers);
            result.TypeReference = (Game08.Sdk.LTS.Model.DefinitionTree.TypeReferenceId)this.TypeReference?.ToLtsModelNode();
            result.Name = (Game08.Sdk.LTS.Model.DefinitionTree.Identifier)this.Name?.ToLtsModelNode();
            result.Initializer = (Game08.Sdk.LTS.Model.DefinitionTree.ExpressionNode)this.Initializer?.ToLtsModelNode();
            return result;
        }
    }
}