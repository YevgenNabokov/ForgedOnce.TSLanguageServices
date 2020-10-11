using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class IndexSignatureDeclaration : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SignatureDeclarationBase, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IClassElement, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeElement
    {
        public IndexSignatureDeclaration()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.IndexSignature;
        }

        public System.Object _classElementBrand
        {
            get;
            set;
        }

        public System.Object _typeElementBrand
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token questionToken
        {
            get;
            set;
        }
    }
}