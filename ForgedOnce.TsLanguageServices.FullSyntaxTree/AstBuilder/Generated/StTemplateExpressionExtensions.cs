using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StTemplateExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression WithHead(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead head)
        {
            subject.head = head;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression WithTemplateSpan(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateSpan templateSpan)
        {
            subject.templateSpans.Add(templateSpan);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}