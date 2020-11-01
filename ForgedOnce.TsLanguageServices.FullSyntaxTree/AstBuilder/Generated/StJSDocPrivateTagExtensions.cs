using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJSDocPrivateTagExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocPrivateTag WithTagName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocPrivateTag subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier> tagNameBuilder)
        {
            subject.tagName = tagNameBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocPrivateTag WithComment(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocPrivateTag subject, string comment)
        {
            subject.comment = comment;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocPrivateTag WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocPrivateTag subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocPrivateTag WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocPrivateTag subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocPrivateTag WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocPrivateTag subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}