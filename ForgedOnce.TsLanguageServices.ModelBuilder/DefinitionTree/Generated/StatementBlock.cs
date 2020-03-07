using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class StatementBlock : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementNode
    {
        public StatementBlock()
        {
            this.Statements = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementNode>(this);
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementNode> Statements
        {
            get;
            private set;
        }

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.StatementBlock();
            result.Statements = this.Statements.Select((i) => (ForgedOnce.TsLanguageServices.Model.DefinitionTree.StatementNode)i.ToLtsModelNode()).ToList();
            return result;
        }
    }
}