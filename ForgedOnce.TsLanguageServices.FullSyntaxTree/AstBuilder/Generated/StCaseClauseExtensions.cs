using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StCaseClauseExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseClause WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseClause WithStatement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement statement)
        {
            subject.statements.Add(statement);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseClause WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseClause WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseClause WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}