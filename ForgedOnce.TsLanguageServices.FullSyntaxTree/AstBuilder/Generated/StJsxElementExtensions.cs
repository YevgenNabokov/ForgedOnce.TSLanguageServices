using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJsxElementExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement WithOpeningElement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement openingElement)
        {
            subject.openingElement = openingElement;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement WithChild(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxChild child)
        {
            subject.children.Add(child);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement WithClosingElement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxClosingElement closingElement)
        {
            subject.closingElement = closingElement;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}