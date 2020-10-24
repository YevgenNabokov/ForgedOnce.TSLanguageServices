using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StMethodDeclarationExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration With_classElementBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration subject, object _classElementBrand)
        {
            subject._classElementBrand = _classElementBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration With_objectLiteralBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration subject, object _objectLiteralBrand)
        {
            subject._objectLiteralBrand = _objectLiteralBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration WithBody(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock body)
        {
            subject.body = body;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration With_functionLikeDeclarationBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration subject, object _functionLikeDeclarationBrand)
        {
            subject._functionLikeDeclarationBrand = _functionLikeDeclarationBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration WithAsteriskToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken asteriskToken)
        {
            subject.asteriskToken = asteriskToken;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration WithQuestionToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken questionToken)
        {
            subject.questionToken = questionToken;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration WithExclamationToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken exclamationToken)
        {
            subject.exclamationToken = exclamationToken;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration WithTypeParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration typeParameter)
        {
            subject.typeParameters.Add(typeParameter);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration WithParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration parameter)
        {
            subject.parameters.Add(parameter);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration WithType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type)
        {
            subject.type = type;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}