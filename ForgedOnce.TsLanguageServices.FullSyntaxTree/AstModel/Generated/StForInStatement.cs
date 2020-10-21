using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StForInStatement : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIterationStatement
    {
        public StForInStatement(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement statement, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStForInitializer initializer, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression): base(flags, decorators, modifiers, statement)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ForInStatement;
            this.initializer = initializer;
            this.expression = expression;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStForInitializer _initializer;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression _expression;
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

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression
        {
            get
            {
                return this._expression;
            }

            set
            {
                this.SetAsParentFor(this._expression, value);
                this._expression = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ForInStatement()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), statement = this.statement != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IStatement)this.statement.GetTransportModelNode() : null, initializer = this.initializer != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IForInitializer)this.initializer.GetTransportModelNode() : null, expression = this.expression != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.expression.GetTransportModelNode() : null};
        }
    }
}