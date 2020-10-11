using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public interface ITypeElement : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INamedDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INode
    {
        System.Object _typeElementBrand
        {
            get;
            set;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token questionToken
        {
            get;
            set;
        }
    }
}