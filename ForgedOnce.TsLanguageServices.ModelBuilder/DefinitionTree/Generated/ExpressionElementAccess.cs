using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class ExpressionElementAccess : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode
    {
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode expression;
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode index;
        public ExpressionElementAccess()
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

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode Index
        {
            get
            {
                return this.index;
            }

            set
            {
                this.SetAsParentFor(this.index, value);
                this.index = value;
            }
        }

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionElementAccess();
            result.Expression = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionNode)this.Expression?.ToLtsModelNode();
            result.Index = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionNode)this.Index?.ToLtsModelNode();
            return result;
        }
    }
}