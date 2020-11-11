using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJsxElementExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement WithOpeningElement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement> openingElementBuilder)
        {
            subject.openingElement = openingElementBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement WithChild(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxChild child)
        {
            subject.children.Add(child);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement WithClosingElement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxClosingElement, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxClosingElement> closingElementBuilder)
        {
            subject.closingElement = closingElementBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxClosingElement());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}