using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StForStatement : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIterationStatement
    {
        public StForStatement(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement statement, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStForInitializer initializer, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression condition, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression incrementor): base(flags, decorators, modifiers, statement)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ForStatement;
            this.initializer = initializer;
            this.condition = condition;
            this.incrementor = incrementor;
        }

        public StForStatement()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ForStatement;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStForInitializer _initializer;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression _condition;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression _incrementor;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStForInitializer initializer
        {
            get
            {
                return this._initializer;
            }

            set
            {
                this.SetAsParentFor(this._initializer, value);
                this._initializer = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression condition
        {
            get
            {
                return this._condition;
            }

            set
            {
                this.SetAsParentFor(this._condition, value);
                this._condition = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression incrementor
        {
            get
            {
                return this._incrementor;
            }

            set
            {
                this.SetAsParentFor(this._incrementor, value);
                this._incrementor = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ForStatement()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), statement = this.statement != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IStatement)this.statement.GetTransportModelNode() : null, initializer = this.initializer != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IForInitializer)this.initializer.GetTransportModelNode() : null, condition = this.condition != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.condition.GetTransportModelNode() : null, incrementor = this.incrementor != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.incrementor.GetTransportModelNode() : null};
        }
    }
}