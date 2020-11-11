using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public interface IJSDocTag : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INode
    {
        ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier tagName
        {
            get;
            set;
        }

        System.String comment
        {
            get;
            set;
        }
    }
}