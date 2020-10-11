using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class BigIntLiteral : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.LiteralExpression
    {
        public BigIntLiteral()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.BigIntLiteral;
        }
    }
}