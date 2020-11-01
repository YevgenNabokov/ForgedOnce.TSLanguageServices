using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StGetAccessorDeclarationExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration With_classElementBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration subject, object _classElementBrand)
        {
            subject._classElementBrand = _classElementBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration With_objectLiteralBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration subject, object _objectLiteralBrand)
        {
            subject._objectLiteralBrand = _objectLiteralBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration WithBody(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock> bodyBuilder)
        {
            subject.body = bodyBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration With_functionLikeDeclarationBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration subject, object _functionLikeDeclarationBrand)
        {
            subject._functionLikeDeclarationBrand = _functionLikeDeclarationBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration WithAsteriskToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken> asteriskTokenBuilder)
        {
            subject.asteriskToken = asteriskTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration WithQuestionToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken> questionTokenBuilder)
        {
            subject.questionToken = questionTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration WithExclamationToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken> exclamationTokenBuilder)
        {
            subject.exclamationToken = exclamationTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration WithTypeParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration> typeParameterBuilder)
        {
            subject.typeParameters.Add(typeParameterBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration WithParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration> parameterBuilder)
        {
            subject.parameters.Add(parameterBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration WithType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type)
        {
            subject.type = type;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}