using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class PrivateIdentifier : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclarationName, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IPropertyName
    {
        public PrivateIdentifier()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PrivateIdentifier;
        }

        public System.String escapedText
        {
            get;
            set;
        }
    }
}