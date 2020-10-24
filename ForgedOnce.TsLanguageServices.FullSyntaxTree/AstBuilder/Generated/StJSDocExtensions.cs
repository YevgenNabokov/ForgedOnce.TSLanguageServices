using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJSDocExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDoc WithTag(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDoc subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJSDocTag tag)
        {
            subject.tags.Add(tag);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDoc WithComment(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDoc subject, string comment)
        {
            subject.comment = comment;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDoc WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDoc subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDoc WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDoc subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDoc WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDoc subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}