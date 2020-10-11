using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class NoSubstitutionTemplateLiteral : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.LiteralExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITemplateLiteralLikeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IStringLiteralLike, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITemplateLiteral
    {
        public NoSubstitutionTemplateLiteral()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NoSubstitutionTemplateLiteral;
        }

        public System.String rawText
        {
            get;
            set;
        }
    }
}