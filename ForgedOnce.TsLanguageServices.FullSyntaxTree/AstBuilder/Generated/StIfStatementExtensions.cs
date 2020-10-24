using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StIfStatementExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIfStatement WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIfStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIfStatement WithThenStatement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIfStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement thenStatement)
        {
            subject.thenStatement = thenStatement;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIfStatement WithElseStatement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIfStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement elseStatement)
        {
            subject.elseStatement = elseStatement;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIfStatement WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIfStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIfStatement WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIfStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIfStatement WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIfStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}