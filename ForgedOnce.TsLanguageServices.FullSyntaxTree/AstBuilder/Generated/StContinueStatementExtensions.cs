using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StContinueStatementExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StContinueStatement WithLabel(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StContinueStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier label)
        {
            subject.label = label;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StContinueStatement WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StContinueStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StContinueStatement WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StContinueStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StContinueStatement WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StContinueStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}