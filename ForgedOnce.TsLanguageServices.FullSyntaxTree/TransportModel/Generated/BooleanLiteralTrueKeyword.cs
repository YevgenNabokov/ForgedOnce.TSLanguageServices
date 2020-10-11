using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class BooleanLiteralTrueKeyword : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BooleanLiteral
    {
        public BooleanLiteralTrueKeyword()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TrueKeyword;
        }
    }
}