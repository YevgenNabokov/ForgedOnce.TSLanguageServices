using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class MethodDeclaration : Game08.Sdk.LTS.Builder.DefinitionTree.Node
    {
        Game08.Sdk.LTS.Builder.DefinitionTree.Identifier name;
        Game08.Sdk.LTS.Builder.DefinitionTree.StatementBlock body;
        Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId returnType;
        public MethodDeclaration()
        {
            this.Modifiers = new System.Collections.Generic.List<Game08.Sdk.LTS.Model.DefinitionTree.Modifier>();
            this.Parameters = new Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.MethodParameter>(this);
        }

        public System.Collections.Generic.List<Game08.Sdk.LTS.Model.DefinitionTree.Modifier> Modifiers
        {
            get;
            private set;
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

        public Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.MethodParameter> Parameters
        {
            get;
            private set;
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.StatementBlock Body
        {
            get
            {
                return this.body;
            }

            set
            {
                this.SetAsParentFor(this.body, value);
                this.body = value;
            }
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId ReturnType
        {
            get
            {
                return this.returnType;
            }

            set
            {
                this.SetAsParentFor(this.returnType, value);
                this.returnType = value;
            }
        }

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.MethodDeclaration();
            result.Modifiers = new System.Collections.Generic.List<Game08.Sdk.LTS.Model.DefinitionTree.Modifier>(this.Modifiers);
            result.Name = (Game08.Sdk.LTS.Model.DefinitionTree.Identifier)this.Name?.ToLtsModelNode();
            result.Parameters = this.Parameters.Select((i) => (Game08.Sdk.LTS.Model.DefinitionTree.MethodParameter)i.ToLtsModelNode()).ToList();
            result.Body = (Game08.Sdk.LTS.Model.DefinitionTree.StatementBlock)this.Body?.ToLtsModelNode();
            result.ReturnType = (Game08.Sdk.LTS.Model.DefinitionTree.TypeReferenceId)this.ReturnType?.ToLtsModelNode();
            return result;
        }
    }
}