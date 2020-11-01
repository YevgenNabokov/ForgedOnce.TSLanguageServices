using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StFunctionExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithBody(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock> bodyBuilder)
        {
            subject.body = bodyBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression With_functionLikeDeclarationBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, object _functionLikeDeclarationBrand)
        {
            subject._functionLikeDeclarationBrand = _functionLikeDeclarationBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithAsteriskToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken> asteriskTokenBuilder)
        {
            subject.asteriskToken = asteriskTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithQuestionToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken> questionTokenBuilder)
        {
            subject.questionToken = questionTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithExclamationToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken> exclamationTokenBuilder)
        {
            subject.exclamationToken = exclamationTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithTypeParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration> typeParameterBuilder)
        {
            subject.typeParameters.Add(typeParameterBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration> parameterBuilder)
        {
            subject.parameters.Add(parameterBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type)
        {
            subject.type = type;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}