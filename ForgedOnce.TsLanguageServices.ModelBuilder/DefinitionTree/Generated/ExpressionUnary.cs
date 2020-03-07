using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class ExpressionUnary : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode
    {
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode left;
        string @operator;
        public ExpressionUnary()
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
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionUnary();
            result.Left = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionNode)this.Left?.ToLtsModelNode();
            result.Operator = this.Operator;
            return result;
        }
    }
}