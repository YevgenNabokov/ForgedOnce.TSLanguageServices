using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StDeclareKeywordTokenExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDeclareKeywordToken WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDeclareKeywordToken subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDeclareKeywordToken WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDeclareKeywordToken subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDeclareKeywordToken WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDeclareKeywordToken subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}