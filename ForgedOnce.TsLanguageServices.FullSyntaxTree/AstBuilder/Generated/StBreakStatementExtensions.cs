using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StBreakStatementExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBreakStatement WithLabel(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBreakStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier label)
        {
            subject.label = label;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBreakStatement WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBreakStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBreakStatement WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBreakStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBreakStatement WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBreakStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}