using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StBooleanLiteralTrueKeywordExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBooleanLiteralTrueKeyword WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBooleanLiteralTrueKeyword subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBooleanLiteralTrueKeyword WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBooleanLiteralTrueKeyword subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBooleanLiteralTrueKeyword WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBooleanLiteralTrueKeyword subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}