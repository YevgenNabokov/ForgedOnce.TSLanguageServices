using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class JsxAttributes : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ObjectLiteralExpressionBase<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJsxAttributeLike>
    {
        public JsxAttributes()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxAttributes;
        }
    }
}