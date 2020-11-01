using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StTemplateExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression WithHead(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead> headBuilder)
        {
            subject.head = headBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression WithTemplateSpan(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateSpan, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateSpan> templateSpanBuilder)
        {
            subject.templateSpans.Add(templateSpanBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateSpan()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}