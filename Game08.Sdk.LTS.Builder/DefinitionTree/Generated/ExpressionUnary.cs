using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class ExpressionUnary : Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode
    {
        Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode left;
        string @operator;
        public ExpressionUnary()
        {
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode Left
        {
            get
            {
                return this.left;
            }

            set
            {
                this.SetAsParentFor(this.left, value);
                this.left = value;
            }
        }

        public string Operator
        {
            get
            {
                return this.@operator;
            }

            set
            {
                this.@operator = value;
            }
        }

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.ExpressionUnary();
            result.Left = (Game08.Sdk.LTS.Model.DefinitionTree.ExpressionNode)this.Left?.ToLtsModelNode();
            result.Operator = this.Operator;
            return result;
        }
    }
}