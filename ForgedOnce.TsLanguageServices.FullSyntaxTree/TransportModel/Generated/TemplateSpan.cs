using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class TemplateSpan : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node
    {
        public TemplateSpan()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TemplateSpan;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression expression
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITemplateLiteralLikeNode literal
        {
            get;
            set;
        }
    }
}