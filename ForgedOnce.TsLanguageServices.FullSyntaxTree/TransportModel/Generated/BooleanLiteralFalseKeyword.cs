using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class BooleanLiteralFalseKeyword : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BooleanLiteral
    {
        public BooleanLiteralFalseKeyword()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.FalseKeyword;
        }
    }
}