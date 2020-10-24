using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StArrowFunctionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithEqualsGreaterThanToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsGreaterThanTokenToken equalsGreaterThanToken)
        {
            subject.equalsGreaterThanToken = equalsGreaterThanToken;
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

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithAsteriskToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken asteriskToken)
        {
            subject.asteriskToken = asteriskToken;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithQuestionToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken questionToken)
        {
            subject.questionToken = questionToken;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithExclamationToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken exclamationToken)
        {
            subject.exclamationToken = exclamationToken;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithTypeParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration typeParameter)
        {
            subject.typeParameters.Add(typeParameter);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration parameter)
        {
            subject.parameters.Add(parameter);
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

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}