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

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AsteriskTokenToken asteriskToken
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.QuestionTokenToken questionToken
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExclamationTokenToken exclamationToken
        {
            get;
            set;
        }
    }
}