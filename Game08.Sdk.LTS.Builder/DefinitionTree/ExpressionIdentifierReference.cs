using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class ExpressionIdentifierReference : ExpressionNode
    {
        private Identifier name;

        public Identifier Name
        {
            get => name;
            set
            {
                this.SetAsParentFor(this.name, value);
                this.name = value;
            }
        }

        public override LTSModel.Node ToLtsModelNode()
        {
            return new LTSModel.ExpressionIdentifierReference()
            {
                Name = this.Name?.Name
            };
        }
    }
}
