using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StAsteriskEqualsTokenTokenExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskEqualsTokenToken WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskEqualsTokenToken subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskEqualsTokenToken WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskEqualsTokenToken subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskEqualsTokenToken WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskEqualsTokenToken subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}