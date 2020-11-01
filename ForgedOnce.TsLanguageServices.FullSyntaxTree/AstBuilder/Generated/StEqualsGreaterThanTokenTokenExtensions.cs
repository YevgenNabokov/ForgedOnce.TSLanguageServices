using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StEqualsGreaterThanTokenTokenExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsGreaterThanTokenToken WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsGreaterThanTokenToken subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsGreaterThanTokenToken WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsGreaterThanTokenToken subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsGreaterThanTokenToken WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsGreaterThanTokenToken subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}