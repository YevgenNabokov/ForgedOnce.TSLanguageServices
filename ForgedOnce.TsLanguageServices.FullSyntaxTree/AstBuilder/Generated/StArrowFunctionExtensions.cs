using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StArrowFunctionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithEqualsGreaterThanToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsGreaterThanTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsGreaterThanTokenToken> equalsGreaterThanTokenBuilder)
        {
            subject.equalsGreaterThanToken = equalsGreaterThanTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsGreaterThanTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithBody(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStConciseBody body)
        {
            subject.body = body;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction With_functionLikeDeclarationBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, object _functionLikeDeclarationBrand)
        {
            subject._functionLikeDeclarationBrand = _functionLikeDeclarationBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithAsteriskToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken> asteriskTokenBuilder)
        {
            subject.asteriskToken = asteriskTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithQuestionToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken> questionTokenBuilder)
        {
            subject.questionToken = questionTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithExclamationToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken> exclamationTokenBuilder)
        {
            subject.exclamationToken = exclamationTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithTypeParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration> typeParameterBuilder)
        {
            subject.typeParameters.Add(typeParameterBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration> parameterBuilder)
        {
            subject.parameters.Add(parameterBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type)
        {
            subject.type = type;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}