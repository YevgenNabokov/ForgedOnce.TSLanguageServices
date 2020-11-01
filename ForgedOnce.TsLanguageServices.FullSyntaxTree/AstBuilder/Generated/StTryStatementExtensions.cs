using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StTryStatementExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement WithTryBlock(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock> tryBlockBuilder)
        {
            subject.tryBlock = tryBlockBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement WithCatchClause(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause> catchClauseBuilder)
        {
            subject.catchClause = catchClauseBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement WithFinallyBlock(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock> finallyBlockBuilder)
        {
            subject.finallyBlock = finallyBlockBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}