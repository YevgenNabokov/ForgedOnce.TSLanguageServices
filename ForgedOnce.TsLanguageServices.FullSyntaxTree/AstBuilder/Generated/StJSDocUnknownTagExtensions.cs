using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJSDocUnknownTagExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocUnknownTag WithTagName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocUnknownTag subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier> tagNameBuilder)
        {
            subject.tagName = tagNameBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocUnknownTag WithComment(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocUnknownTag subject, string comment)
        {
            subject.comment = comment;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocUnknownTag WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocUnknownTag subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocUnknownTag WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocUnknownTag subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocUnknownTag WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocUnknownTag subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}