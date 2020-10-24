using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJsxFragmentExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment WithOpeningFragment(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningFragment openingFragment)
        {
            subject.openingFragment = openingFragment;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment WithChild(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxChild child)
        {
            subject.children.Add(child);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment WithClosingFragment(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxClosingFragment closingFragment)
        {
            subject.closingFragment = closingFragment;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}