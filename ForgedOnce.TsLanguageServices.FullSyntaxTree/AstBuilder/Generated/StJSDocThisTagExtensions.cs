using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJSDocThisTagExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocThisTag WithTagName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocThisTag subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier> tagNameBuilder)
        {
            subject.tagName = tagNameBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocThisTag WithComment(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocThisTag subject, string comment)
        {
            subject.comment = comment;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocThisTag WithTypeExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocThisTag subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression> typeExpressionBuilder)
        {
            subject.typeExpression = typeExpressionBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocThisTag WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocThisTag subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocThisTag WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocThisTag subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocThisTag WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocThisTag subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}