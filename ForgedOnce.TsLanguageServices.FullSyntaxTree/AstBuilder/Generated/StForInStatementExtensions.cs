using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StForInStatementExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForInStatement WithInitializer(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForInStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStForInitializer initializer)
        {
            subject.initializer = initializer;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForInStatement WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForInStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForInStatement WithStatement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForInStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement statement)
        {
            subject.statement = statement;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForInStatement WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForInStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForInStatement WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForInStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForInStatement WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForInStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}