using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StDefaultClauseExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDefaultClause WithStatement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDefaultClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement statement)
        {
            subject.statements.Add(statement);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDefaultClause WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDefaultClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDefaultClause WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDefaultClause subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDefaultClause WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDefaultClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}