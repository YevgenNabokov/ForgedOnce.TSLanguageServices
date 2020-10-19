using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StTemplateExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPrimaryExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTemplateLiteral
    {
        public StTemplateExpression(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead head, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateSpan> templateSpans): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TemplateExpression;
            this.head = head;
            this.templateSpans = templateSpans;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead head
        {
            get;
            set;
        }

        public System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateSpan> templateSpans
        {
            get;
            set;
        }
    }
}