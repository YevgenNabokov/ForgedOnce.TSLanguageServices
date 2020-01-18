using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class StatementFor : Game08.Sdk.LTS.Builder.DefinitionTree.StatementNode
    {
        Game08.Sdk.LTS.Builder.DefinitionTree.StatementLocalDeclaration initializer;
        Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode condition;
        Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode increment;
        Game08.Sdk.LTS.Builder.DefinitionTree.StatementNode statement;
        public StatementFor()
        {
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.StatementLocalDeclaration Initializer
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

        public Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode Condition
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

        public Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode Increment
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

        public Game08.Sdk.LTS.Builder.DefinitionTree.StatementNode Statement
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

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.StatementFor();
            result.Initializer = (Game08.Sdk.LTS.Model.DefinitionTree.StatementLocalDeclaration)this.Initializer?.ToLtsModelNode();
            result.Condition = (Game08.Sdk.LTS.Model.DefinitionTree.ExpressionNode)this.Condition?.ToLtsModelNode();
            result.Increment = (Game08.Sdk.LTS.Model.DefinitionTree.ExpressionNode)this.Increment?.ToLtsModelNode();
            result.Statement = (Game08.Sdk.LTS.Model.DefinitionTree.StatementNode)this.Statement?.ToLtsModelNode();
            return result;
        }
    }
}