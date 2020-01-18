using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class ExpressionAssignment : Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode
    {
        Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode left;
        Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode right;
        public ExpressionAssignment()
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

        public Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode Right
        {
            get
            {
                return this.right;
            }

            set
            {
                this.SetAsParentFor(this.right, value);
                this.right = value;
            }
        }

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.ExpressionAssignment();
            result.Left = (Game08.Sdk.LTS.Model.DefinitionTree.ExpressionNode)this.Left?.ToLtsModelNode();
            result.Right = (Game08.Sdk.LTS.Model.DefinitionTree.ExpressionNode)this.Right?.ToLtsModelNode();
            return result;
        }
    }
}