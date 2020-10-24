using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJsxAttributeExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttribute WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttribute subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttribute With_objectLiteralBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttribute subject, object _objectLiteralBrand)
        {
            subject._objectLiteralBrand = _objectLiteralBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttribute WithInitializer(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttribute subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode initializer)
        {
            subject.initializer = initializer;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttribute WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttribute subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttribute WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttribute subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttribute WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttribute subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}