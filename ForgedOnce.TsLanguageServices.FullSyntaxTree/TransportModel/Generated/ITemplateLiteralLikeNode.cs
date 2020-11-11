using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public interface ITemplateLiteralLikeNode : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ILiteralLikeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INode
    {
        System.String rawText
        {
            get;
            set;
        }
    }
}