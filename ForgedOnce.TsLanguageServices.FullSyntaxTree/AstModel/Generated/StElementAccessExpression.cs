using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StElementAccessExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStMemberExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName
    {
        public StElementAccessExpression(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression expression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionDotTokenToken questionDotToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression argumentExpression): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ElementAccessExpression;
            this.expression = expression;
            this.questionDotToken = questionDotToken;
            this.argumentExpression = argumentExpression;
        }

        public StElementAccessExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ElementAccessExpression;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression _expression;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionDotTokenToken _questionDotToken;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression _argumentExpression;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression expression
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

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionDotTokenToken questionDotToken
        {
            get
            {
                return this._questionDotToken;
            }

            set
            {
                this.SetAsParentFor(this._questionDotToken, value);
                this._questionDotToken = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression argumentExpression
        {
            get
            {
                return this._argumentExpression;
            }

            set
            {
                this.SetAsParentFor(this._argumentExpression, value);
                this._argumentExpression = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ElementAccessExpression()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), expression = this.expression != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ILeftHandSideExpression)this.expression.GetTransportModelNode() : null, questionDotToken = this.questionDotToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.QuestionDotTokenToken)this.questionDotToken.GetTransportModelNode() : null, argumentExpression = this.argumentExpression != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.argumentExpression.GetTransportModelNode() : null};
        }
    }
}