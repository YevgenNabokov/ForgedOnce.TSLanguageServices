using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJSDocReturnTagExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag WithTagName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier> tagNameBuilder)
        {
            subject.tagName = tagNameBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag WithComment(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag subject, string comment)
        {
            subject.comment = comment;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag WithTypeExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression> typeExpressionBuilder)
        {
            subject.typeExpression = typeExpressionBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}