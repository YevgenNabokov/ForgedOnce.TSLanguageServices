using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class EnumMember : Game08.Sdk.LTS.Builder.DefinitionTree.Node
    {
        Game08.Sdk.LTS.Builder.DefinitionTree.Identifier name;
        Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode value;
        public EnumMember()
        {
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.Identifier Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.SetAsParentFor(this.name, value);
                this.name = value;
            }
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.SetAsParentFor(this.value, value);
                this.value = value;
            }
        }

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.EnumMember();
            result.Name = (Game08.Sdk.LTS.Model.DefinitionTree.Identifier)this.Name?.ToLtsModelNode();
            result.Value = (Game08.Sdk.LTS.Model.DefinitionTree.ExpressionNode)this.Value?.ToLtsModelNode();
            return result;
        }
    }
}