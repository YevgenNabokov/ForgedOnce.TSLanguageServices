using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ExportKeywordToken : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier
    {
        public ExportKeywordToken()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ExportKeyword;
        }
    }
}