using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
{
    public class StatementBlock : StatementNode
    {
        public StatementBlock()
        {
            this.NodeType = NodeType.StatementBlock;
            this.Statements = new List<StatementNode>();
        }

        public List<StatementNode> Statements;
    }
}
