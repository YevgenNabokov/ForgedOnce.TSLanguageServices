using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class StatementBlock : Game08.Sdk.LTS.Builder.DefinitionTree.StatementNode
    {
        public StatementBlock()
        {
            this.Statements = new Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.StatementNode>(this);
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.StatementNode> Statements
        {
            get;
            private set;
        }

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.StatementBlock();
            result.Statements = this.Statements.Select((i) => (Game08.Sdk.LTS.Model.DefinitionTree.StatementNode)i.ToLtsModelNode()).ToList();
            return result;
        }
    }
}