using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class ExpressionLiteral : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode
    {
        bool isNumeric;
        string text;
        public ExpressionLiteral()
        {
        }

        public bool IsNumeric
        {
            get
            {
                return this.isNumeric;
            }

            set
            {
                this.EnsureIsEditable();
                this.isNumeric = value;
            }
        }

        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                this.EnsureIsEditable();
                this.text = value;
            }
        }

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionLiteral();
            result.IsNumeric = this.IsNumeric;
            result.Text = this.Text;
            return result;
        }
    }
}