using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class StatementFor : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementNode
    {
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementLocalDeclaration initializer;
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode condition;
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode increment;
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementNode statement;
        public StatementFor()
        {
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementLocalDeclaration Initializer
        {
            get
            {
                return this.initializer;
            }

            set
            {
                this.SetAsParentFor(this.initializer, value);
                this.initializer = value;
            }
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode Condition
        {
            get
            {
                return this.condition;
            }

            set
            {
                this.SetAsParentFor(this.condition, value);
                this.condition = value;
            }
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode Increment
        {
            get
            {
                return this.increment;
            }

            set
            {
                this.SetAsParentFor(this.increment, value);
                this.increment = value;
            }
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementNode Statement
        {
            get
            {
                return this.statement;
            }

            set
            {
                this.SetAsParentFor(this.statement, value);
                this.statement = value;
            }
        }

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.StatementFor();
            result.Initializer = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.StatementLocalDeclaration)this.Initializer?.ToLtsModelNode();
            result.Condition = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionNode)this.Condition?.ToLtsModelNode();
            result.Increment = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionNode)this.Increment?.ToLtsModelNode();
            result.Statement = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.StatementNode)this.Statement?.ToLtsModelNode();
            return result;
        }
    }
}