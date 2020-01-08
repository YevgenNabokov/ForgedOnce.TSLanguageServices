using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class ExpressionLiteral : ExpressionNode
    {
        public bool IsNumeric { get; set; }

        public string Text { get; set; }

        public override LTSModel.Node ToLtsModelNode()
        {
            return new LTSModel.ExpressionLiteral()
            {
                IsNumeric = this.IsNumeric,
                Text = this.Text
            };
        }
    }
}
