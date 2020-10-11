using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class FunctionLikeDeclarationBase : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SignatureDeclarationBase
    {
        public System.Object _functionLikeDeclarationBrand
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token asteriskToken
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token questionToken
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token exclamationToken
        {
            get;
            set;
        }
    }
}