using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class StatementLocalDeclaration : Game08.Sdk.LTS.Builder.DefinitionTree.StatementNode
    {
        Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId typeReference;
        Game08.Sdk.LTS.Builder.DefinitionTree.Identifier name;
        Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode initializer;
        public StatementLocalDeclaration()
        {
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
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.StatementLocalDeclaration();
            result.TypeReference = (Game08.Sdk.LTS.Model.DefinitionTree.TypeReferenceId)this.TypeReference?.ToLtsModelNode();
            result.Name = (Game08.Sdk.LTS.Model.DefinitionTree.Identifier)this.Name?.ToLtsModelNode();
            result.Initializer = (Game08.Sdk.LTS.Model.DefinitionTree.ExpressionNode)this.Initializer?.ToLtsModelNode();
            return result;
        }
    }
}