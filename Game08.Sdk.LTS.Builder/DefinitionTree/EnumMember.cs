using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class EnumMember : Node
    {
        private Identifier name;

        private ExpressionNode value;

        public Identifier Name
        {
            get => name;
            set
            {
                this.SetAsParentFor(this.name, value);
                this.name = value;
            }
        }

        public ExpressionNode Value
        {
            get => value;
            set
            {
                this.SetAsParentFor(this.value, value);
                this.value = value;
            }
        }

        public override LTSModel.Node ToLtsModelNode()
        {
            return new LTSModel.EnumMember()
            {
                Name = this.Name?.Name,
                Value = this.Value != null ? (LTSModel.ExpressionNode)this.Value.ToLtsModelNode() : null
            };
        }
    }
}
