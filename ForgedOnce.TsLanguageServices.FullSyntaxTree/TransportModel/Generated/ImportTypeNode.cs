using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ImportTypeNode : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeWithTypeArguments
    {
        public System.Nullable<System.Boolean> isTypeOf
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode argument
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IEntityName qualifier
        {
            get;
            set;
        }
    }
}