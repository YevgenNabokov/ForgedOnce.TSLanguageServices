using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class JsonMinusNumericLiteral : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PrefixUnaryExpression
    {
        public JsonMinusNumericLiteral()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PrefixUnaryExpression;
        }
    }
}