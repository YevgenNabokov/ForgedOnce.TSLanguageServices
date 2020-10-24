using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StTaggedTemplateExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTaggedTemplateExpression WithTag(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTaggedTemplateExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression tag)
        {
            subject.tag = tag;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTaggedTemplateExpression WithTypeArgument(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTaggedTemplateExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode typeArgument)
        {
            subject.typeArguments.Add(typeArgument);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTaggedTemplateExpression WithTemplate(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTaggedTemplateExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTemplateLiteral template)
        {
            subject.template = template;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTaggedTemplateExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTaggedTemplateExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTaggedTemplateExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTaggedTemplateExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTaggedTemplateExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTaggedTemplateExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}