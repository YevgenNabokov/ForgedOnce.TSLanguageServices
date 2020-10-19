using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public abstract class StPropertyAccessEntityNameExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAccessExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityNameExpression
    {
        public StPropertyAccessEntityNameExpression(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression expression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionDotTokenToken questionDotToken, System.Object _propertyAccessExpressionLikeQualifiedNameBrand): base(flags, decorators, modifiers, name, expression, questionDotToken)
        {
            this._propertyAccessExpressionLikeQualifiedNameBrand = _propertyAccessExpressionLikeQualifiedNameBrand;
        }

        public System.Object _propertyAccessExpressionLikeQualifiedNameBrand
        {
            get;
            set;
        }
    }
}