using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public interface IClassElement : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INamedDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INode
    {
        System.Object _classElementBrand
        {
            get;
            set;
        }
    }
}