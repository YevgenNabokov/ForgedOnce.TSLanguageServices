using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StMethodSignatureExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodSignature With_typeElementBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodSignature subject, object _typeElementBrand)
        {
            subject._typeElementBrand = _typeElementBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodSignature WithQuestionToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodSignature subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken questionToken)
        {
            subject.questionToken = questionToken;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodSignature WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodSignature subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodSignature WithTypeParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodSignature subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration typeParameter)
        {
            subject.typeParameters.Add(typeParameter);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodSignature WithParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodSignature subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration parameter)
        {
            subject.parameters.Add(parameter);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodSignature WithType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodSignature subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type)
        {
            subject.type = type;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodSignature WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodSignature subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodSignature WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodSignature subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodSignature WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodSignature subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}