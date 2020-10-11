using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ConstructSignatureDeclaration : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SignatureDeclarationBase, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeElement
    {
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