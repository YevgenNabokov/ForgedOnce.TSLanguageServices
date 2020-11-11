using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJsxFragmentExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment WithOpeningFragment(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningFragment, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningFragment> openingFragmentBuilder)
        {
            subject.openingFragment = openingFragmentBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningFragment());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment WithChild(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxChild child)
        {
            subject.children.Add(child);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment WithClosingFragment(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxClosingFragment, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxClosingFragment> closingFragmentBuilder)
        {
            subject.closingFragment = closingFragmentBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxClosingFragment());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}