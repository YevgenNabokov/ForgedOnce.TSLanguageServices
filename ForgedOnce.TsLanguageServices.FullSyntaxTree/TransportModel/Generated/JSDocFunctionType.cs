using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class JSDocFunctionType : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SignatureDeclarationBase, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJSDocType
    {
        public JSDocFunctionType()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocFunctionType;
        }
    }
}