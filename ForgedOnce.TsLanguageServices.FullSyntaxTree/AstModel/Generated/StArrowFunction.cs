using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StArrowFunction : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionLikeDeclarationBase, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJSDocContainer
    {
        public StArrowFunction(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName name, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration> typeParameters, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration> parameters, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsGreaterThanTokenToken equalsGreaterThanToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken asteriskToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken questionToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken exclamationToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStConciseBody body): base(flags, decorators, modifiers, name, typeParameters, parameters, type, asteriskToken, questionToken, exclamationToken)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ArrowFunction;
            this.equalsGreaterThanToken = equalsGreaterThanToken;
            this.body = body;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsGreaterThanTokenToken equalsGreaterThanToken
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStConciseBody body
        {
            get;
            set;
        }
    }
}