using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJsxOpeningElementExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement WithTagName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxTagNameExpression tagName)
        {
            subject.tagName = tagName;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement WithTypeArgument(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode typeArgument)
        {
            subject.typeArguments.Add(typeArgument);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement WithAttributes(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttributes, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttributes> attributesBuilder)
        {
            subject.attributes = attributesBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttributes());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}