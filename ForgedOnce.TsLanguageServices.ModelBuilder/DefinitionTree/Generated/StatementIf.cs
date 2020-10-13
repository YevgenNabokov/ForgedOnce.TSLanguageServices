using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class StatementIf : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementNode
    {
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode expression;
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementNode then;
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementNode @else;
        public StatementIf()
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

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementNode Then
        {
            get
            {
                return this.then;
            }

            set
            {
                this.SetAsParentFor(this.then, value);
                this.then = value;
            }
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementNode Else
        {
            get
            {
                return this.@else;
            }

            set
            {
                this.SetAsParentFor(this.@else, value);
                this.@else = value;
            }
        }

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.StatementIf();
            result.Expression = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionNode)this.Expression?.ToLtsModelNode();
            result.Then = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.StatementNode)this.Then?.ToLtsModelNode();
            result.Else = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.StatementNode)this.Else?.ToLtsModelNode();
            return result;
        }
    }
}