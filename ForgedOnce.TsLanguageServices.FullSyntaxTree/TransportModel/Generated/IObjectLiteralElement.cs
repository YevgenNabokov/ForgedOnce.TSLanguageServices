using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public interface IObjectLiteralElement : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INamedDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INode
    {
        System.Object _objectLiteralBrand
        {
            get;
            set;
        }
    }
}