using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StWithStatementExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWithStatement WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWithStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWithStatement WithStatement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWithStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement statement)
        {
            subject.statement = statement;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWithStatement WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWithStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWithStatement WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWithStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWithStatement WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWithStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}