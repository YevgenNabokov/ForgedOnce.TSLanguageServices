using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class GetAccessorDeclaration : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.FunctionLikeDeclarationBase, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJSDocContainer, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IClassElement, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IObjectLiteralElement, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IAccessorDeclaration
    {
        public System.Object _classElementBrand
        {
            get;
            set;
        }

        public System.Object _objectLiteralBrand
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Block body
        {
            get;
            set;
        }
    }
}