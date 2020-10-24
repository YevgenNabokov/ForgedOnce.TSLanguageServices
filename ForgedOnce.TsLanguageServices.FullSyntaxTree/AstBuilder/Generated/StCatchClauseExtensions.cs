using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StCatchClauseExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause WithVariableDeclaration(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclaration variableDeclaration)
        {
            subject.variableDeclaration = variableDeclaration;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause WithBlock(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock block)
        {
            subject.block = block;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}