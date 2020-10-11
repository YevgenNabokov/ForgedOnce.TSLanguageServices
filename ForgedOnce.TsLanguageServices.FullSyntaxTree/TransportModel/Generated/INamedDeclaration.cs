using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public interface INamedDeclaration : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INode
    {
        ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclarationName name
        {
            get;
            set;
        }
    }
}