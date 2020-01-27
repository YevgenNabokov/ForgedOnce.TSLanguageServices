using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class ExpressionLiteral : Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode
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

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.ExpressionLiteral();
            result.IsNumeric = this.IsNumeric;
            result.Text = this.Text;
            return result;
        }
    }
}