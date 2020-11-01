using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StCallSignatureDeclarationExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallSignatureDeclaration With_typeElementBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallSignatureDeclaration subject, object _typeElementBrand)
        {
            subject._typeElementBrand = _typeElementBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallSignatureDeclaration WithQuestionToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallSignatureDeclaration subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken> questionTokenBuilder)
        {
            subject.questionToken = questionTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallSignatureDeclaration WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallSignatureDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallSignatureDeclaration WithTypeParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallSignatureDeclaration subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration> typeParameterBuilder)
        {
            subject.typeParameters.Add(typeParameterBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallSignatureDeclaration WithParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallSignatureDeclaration subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration> parameterBuilder)
        {
            subject.parameters.Add(parameterBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallSignatureDeclaration WithType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallSignatureDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type)
        {
            subject.type = type;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallSignatureDeclaration WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallSignatureDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallSignatureDeclaration WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallSignatureDeclaration subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallSignatureDeclaration WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallSignatureDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}