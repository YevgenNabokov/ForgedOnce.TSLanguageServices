using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJsxSelfClosingElementExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSelfClosingElement WithTagName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSelfClosingElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxTagNameExpression tagName)
        {
            subject.tagName = tagName;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSelfClosingElement WithTypeArgument(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSelfClosingElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode typeArgument)
        {
            subject.typeArguments.Add(typeArgument);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSelfClosingElement WithAttributes(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSelfClosingElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttributes attributes)
        {
            subject.attributes = attributes;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSelfClosingElement WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSelfClosingElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSelfClosingElement WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSelfClosingElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSelfClosingElement WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSelfClosingElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}