using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class StatementReturn : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementNode
    {
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode expression;
        public StatementReturn()
        {
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode Expression
        {
            get
            {
                return this.expression;
            }

            set
            {
                this.SetAsParentFor(this.expression, value);
                this.expression = value;
            }
        }

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.StatementReturn();
            result.Expression = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionNode)this.Expression?.ToLtsModelNode();
            return result;
        }
    }
}