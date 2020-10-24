using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StKeywordTypeNodeBigIntKeywordExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StKeywordTypeNodeBigIntKeyword WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StKeywordTypeNodeBigIntKeyword subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StKeywordTypeNodeBigIntKeyword WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StKeywordTypeNodeBigIntKeyword subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StKeywordTypeNodeBigIntKeyword WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StKeywordTypeNodeBigIntKeyword subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}