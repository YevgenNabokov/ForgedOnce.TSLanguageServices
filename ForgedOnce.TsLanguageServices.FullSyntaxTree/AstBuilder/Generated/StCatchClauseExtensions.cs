using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StCatchClauseExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause WithVariableDeclaration(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclaration> variableDeclarationBuilder)
        {
            subject.variableDeclaration = variableDeclarationBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclaration());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause WithBlock(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock> blockBuilder)
        {
            subject.block = blockBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}