using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class RegularExpressionLiteral : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.LiteralExpression
    {
        public RegularExpressionLiteral()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.RegularExpressionLiteral;
        }
    }
}