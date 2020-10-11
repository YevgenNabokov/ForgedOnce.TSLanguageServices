using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ConstructorDeclaration : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.FunctionLikeDeclarationBase, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJSDocContainer, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IClassElement
    {
        public System.Object _classElementBrand
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