using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class StatementBlock : StatementNode
    {
        public StatementBlock()
        {
            this.Statements = new BuilderNodeCollection<StatementNode>(this);
        }

        public BuilderNodeCollection<StatementNode> Statements { get; private set; }

        public override LTSModel.Node ToLtsModelNode()
        {
            return new LTSModel.StatementBlock()
            {
                Statements = this.Statements.Select(s => (LTSModel.StatementNode)s.ToLtsModelNode()).ToList()
            };
        }
    }
}
