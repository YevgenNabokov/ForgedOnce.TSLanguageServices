using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StTypeQueryNodeExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeQueryNode WithExprName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeQueryNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName exprName)
        {
            subject.exprName = exprName;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeQueryNode WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeQueryNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeQueryNode WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeQueryNode subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeQueryNode WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeQueryNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}