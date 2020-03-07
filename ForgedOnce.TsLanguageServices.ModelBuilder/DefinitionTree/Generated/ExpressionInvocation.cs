using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class ExpressionInvocation : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode
    {
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode expression;
        public ExpressionInvocation()
        {
            this.Arguments = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode>(this);
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode> Arguments
        {
            get;
            private set;
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
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionInvocation();
            result.Arguments = this.Arguments.Select((i) => (ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionNode)i.ToLtsModelNode()).ToList();
            result.Expression = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionNode)this.Expression?.ToLtsModelNode();
            return result;
        }
    }
}