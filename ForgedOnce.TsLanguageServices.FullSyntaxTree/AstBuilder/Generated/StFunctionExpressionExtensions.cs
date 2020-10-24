using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StFunctionExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithBody(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock body)
        {
            subject.body = body;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression With_functionLikeDeclarationBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, object _functionLikeDeclarationBrand)
        {
            subject._functionLikeDeclarationBrand = _functionLikeDeclarationBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithAsteriskToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken asteriskToken)
        {
            subject.asteriskToken = asteriskToken;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithQuestionToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken questionToken)
        {
            subject.questionToken = questionToken;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithExclamationToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken exclamationToken)
        {
            subject.exclamationToken = exclamationToken;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithTypeParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration typeParameter)
        {
            subject.typeParameters.Add(typeParameter);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration parameter)
        {
            subject.parameters.Add(parameter);
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

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}