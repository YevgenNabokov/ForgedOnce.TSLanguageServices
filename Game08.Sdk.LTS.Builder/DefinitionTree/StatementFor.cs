using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class StatementFor : StatementNode
    {
        private StatementLocalDeclaration initializer;

        private ExpressionNode condition;

        private ExpressionNode increment;

        private StatementNode statement;

        public StatementLocalDeclaration Initializer
        {
            get => initializer;
            set
            {
                this.SetAsParentFor(this.initializer, value);
                this.initializer = value;
            }
        }

        public ExpressionNode Condition
        {
            get => condition;
            set
            {
                this.SetAsParentFor(this.condition, value);
                this.condition = value;
            }
        }

        public ExpressionNode Increment
        {
            get => increment;
            set
            {
                this.SetAsParentFor(this.increment, value);
                this.increment = value;
            }
        }

        public StatementNode Statement
        {
            get => statement;
            set
            {
                this.SetAsParentFor(this.statement, value);
                this.statement = value;
            }
        }

        public override LTSModel.Node ToLtsModelNode()
        {
            return new LTSModel.StatementFor()
            {
                Initializer = this.Initializer != null ? (LTSModel.StatementLocalDeclaration)this.Initializer.ToLtsModelNode() : null,
                Condition = this.Condition != null ? (LTSModel.ExpressionNode)this.Condition.ToLtsModelNode() : null,
                Increment = this.Increment != null ? (LTSModel.ExpressionNode)this.Increment.ToLtsModelNode() : null,
                Statement = this.Statement != null ? (LTSModel.StatementNode)this.Statement.ToLtsModelNode() : null
            };
        }
    }
}
