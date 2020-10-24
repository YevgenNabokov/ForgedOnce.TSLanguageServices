using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StCaseBlockExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseBlock WithClaus(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseBlock subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStCaseOrDefaultClause claus)
        {
            subject.clauses.Add(claus);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseBlock WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseBlock subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseBlock WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseBlock subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseBlock WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseBlock subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}