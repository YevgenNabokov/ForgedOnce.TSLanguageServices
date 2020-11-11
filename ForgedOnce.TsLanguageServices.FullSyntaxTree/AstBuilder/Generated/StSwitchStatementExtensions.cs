using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StSwitchStatementExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSwitchStatement WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSwitchStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSwitchStatement WithCaseBlock(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSwitchStatement subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseBlock, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseBlock> caseBlockBuilder)
        {
            subject.caseBlock = caseBlockBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseBlock());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSwitchStatement WithPossiblyExhaustive(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSwitchStatement subject, bool? possiblyExhaustive)
        {
            subject.possiblyExhaustive = possiblyExhaustive;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSwitchStatement WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSwitchStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSwitchStatement WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSwitchStatement subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSwitchStatement WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSwitchStatement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}