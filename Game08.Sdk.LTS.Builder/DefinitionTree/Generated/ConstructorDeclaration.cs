using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class ConstructorDeclaration : Game08.Sdk.LTS.Builder.DefinitionTree.Node
    {
        Game08.Sdk.LTS.Builder.DefinitionTree.StatementBlock body;
        public ConstructorDeclaration()
        {
            this.Modifiers = new System.Collections.Generic.List<Game08.Sdk.LTS.Model.DefinitionTree.Modifier>();
            this.Parameters = new Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.MethodParameter>(this);
        }

        public System.Collections.Generic.List<Game08.Sdk.LTS.Model.DefinitionTree.Modifier> Modifiers
        {
            get;
            private set;
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

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.ConstructorDeclaration();
            result.Modifiers = new System.Collections.Generic.List<Game08.Sdk.LTS.Model.DefinitionTree.Modifier>(this.Modifiers);
            result.Parameters = this.Parameters.Select((i) => (Game08.Sdk.LTS.Model.DefinitionTree.MethodParameter)i.ToLtsModelNode()).ToList();
            result.Body = (Game08.Sdk.LTS.Model.DefinitionTree.StatementBlock)this.Body?.ToLtsModelNode();
            return result;
        }
    }
}