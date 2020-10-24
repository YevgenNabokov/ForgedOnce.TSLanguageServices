using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StTryStatementExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement WithTryBlock(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock tryBlock)
        {
            subject.tryBlock = tryBlock;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement WithCatchClause(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause catchClause)
        {
            subject.catchClause = catchClause;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement WithFinallyBlock(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock finallyBlock)
        {
            subject.finallyBlock = finallyBlock;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}