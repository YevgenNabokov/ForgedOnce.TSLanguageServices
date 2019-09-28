using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class ExpressionThis : ExpressionNode
    {
        public override LTSModel.Node ToLtsModelNode()
        {
            return new LTSModel.ExpressionThis();
        }
    }
}
