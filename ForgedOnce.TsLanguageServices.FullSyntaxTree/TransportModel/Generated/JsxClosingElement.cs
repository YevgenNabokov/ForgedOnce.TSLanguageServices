using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class JsxClosingElement : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node
    {
        public JsxClosingElement()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxClosingElement;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJsxTagNameExpression tagName
        {
            get;
            set;
        }
    }
}