using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StConditionalExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression
    {
        public StConditionalExpression(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression condition, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken questionToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression whenTrue, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StColonTokenToken colonToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression whenFalse): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ConditionalExpression;
            this.condition = condition;
            this.questionToken = questionToken;
            this.whenTrue = whenTrue;
            this.colonToken = colonToken;
            this.whenFalse = whenFalse;
        }

        public StConditionalExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ConditionalExpression;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression _condition;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken _questionToken;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression _whenTrue;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StColonTokenToken _colonToken;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression _whenFalse;
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

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken questionToken
        {
            get
            {
                return this._questionToken;
            }

            set
            {
                this.SetAsParentFor(this._questionToken, value);
                this._questionToken = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression whenTrue
        {
            get
            {
                return this._whenTrue;
            }

            set
            {
                this.SetAsParentFor(this._whenTrue, value);
                this._whenTrue = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StColonTokenToken colonToken
        {
            get
            {
                return this._colonToken;
            }

            set
            {
                this.SetAsParentFor(this._colonToken, value);
                this._colonToken = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression whenFalse
        {
            get
            {
                return this._whenFalse;
            }

            set
            {
                this.SetAsParentFor(this._whenFalse, value);
                this._whenFalse = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ConditionalExpression()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), condition = this.condition != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.condition.GetTransportModelNode() : null, questionToken = this.questionToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.QuestionTokenToken)this.questionToken.GetTransportModelNode() : null, whenTrue = this.whenTrue != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.whenTrue.GetTransportModelNode() : null, colonToken = this.colonToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ColonTokenToken)this.colonToken.GetTransportModelNode() : null, whenFalse = this.whenFalse != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.whenFalse.GetTransportModelNode() : null};
        }
    }
}