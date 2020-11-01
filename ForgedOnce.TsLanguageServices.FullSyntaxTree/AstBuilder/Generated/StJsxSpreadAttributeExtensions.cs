using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJsxSpreadAttributeExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSpreadAttribute WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSpreadAttribute subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSpreadAttribute With_objectLiteralBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSpreadAttribute subject, object _objectLiteralBrand)
        {
            subject._objectLiteralBrand = _objectLiteralBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSpreadAttribute WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSpreadAttribute subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSpreadAttribute WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSpreadAttribute subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSpreadAttribute WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSpreadAttribute subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSpreadAttribute WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSpreadAttribute subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}