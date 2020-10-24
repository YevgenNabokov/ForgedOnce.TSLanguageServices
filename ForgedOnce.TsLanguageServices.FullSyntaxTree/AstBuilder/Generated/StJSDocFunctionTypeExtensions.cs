using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJSDocFunctionTypeExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocFunctionType WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocFunctionType subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocFunctionType WithTypeParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocFunctionType subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration typeParameter)
        {
            subject.typeParameters.Add(typeParameter);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocFunctionType WithParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocFunctionType subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration parameter)
        {
            subject.parameters.Add(parameter);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocFunctionType WithType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocFunctionType subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type)
        {
            subject.type = type;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocFunctionType WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocFunctionType subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocFunctionType WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocFunctionType subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocFunctionType WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocFunctionType subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}