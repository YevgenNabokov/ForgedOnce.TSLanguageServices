using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class TemplateExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IPrimaryExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITemplateLiteral
    {
        public TemplateExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TemplateExpression;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TemplateHead head
        {
            get;
            set;
        }

        public System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TemplateSpan> templateSpans
        {
            get;
            set;
        }
    }
}