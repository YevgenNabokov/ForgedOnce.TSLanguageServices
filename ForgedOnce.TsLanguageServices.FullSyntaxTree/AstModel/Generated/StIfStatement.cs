using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StIfStatement : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement
    {
        public StIfStatement(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement thenStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement elseStatement): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.IfStatement;
            this.expression = expression;
            this.thenStatement = thenStatement;
            this.elseStatement = elseStatement;
        }

        public StIfStatement()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.IfStatement;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression _expression;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement _thenStatement;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement _elseStatement;
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

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement thenStatement
        {
            get
            {
                return this._thenStatement;
            }

            set
            {
                this.SetAsParentFor(this._thenStatement, value);
                this._thenStatement = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement elseStatement
        {
            get
            {
                return this._elseStatement;
            }

            set
            {
                this.SetAsParentFor(this._elseStatement, value);
                this._elseStatement = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IfStatement()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), expression = this.expression != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.expression.GetTransportModelNode() : null, thenStatement = this.thenStatement != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IStatement)this.thenStatement.GetTransportModelNode() : null, elseStatement = this.elseStatement != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IStatement)this.elseStatement.GetTransportModelNode() : null};
        }
    }
}