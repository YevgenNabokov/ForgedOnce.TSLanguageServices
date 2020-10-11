using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class TypeReferenceNode : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeWithTypeArguments
    {
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IEntityName typeName
        {
            get;
            set;
        }
    }
}