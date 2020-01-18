using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class ExpressionThis : Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode
    {
        public ExpressionThis()
        {
        }

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.ExpressionThis();
            return result;
        }
    }
}