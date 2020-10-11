using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class NumericLiteral : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.LiteralExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclarationName, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IPropertyName
    {
        public NumericLiteral()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NumericLiteral;
        }
    }
}