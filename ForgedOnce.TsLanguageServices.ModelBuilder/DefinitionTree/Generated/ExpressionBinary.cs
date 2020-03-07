using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class ExpressionBinary : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode
    {
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode left;
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode right;
        string @operator;
        public ExpressionBinary()
        {
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode Left
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

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode Right
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

        public string Operator
        {
            get
            {
                return this.@operator;
            }

            set
            {
                this.EnsureIsEditable();
                this.@operator = value;
            }
        }

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionBinary();
            result.Left = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionNode)this.Left?.ToLtsModelNode();
            result.Right = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionNode)this.Right?.ToLtsModelNode();
            result.Operator = this.Operator;
            return result;
        }
    }
}