using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class JSDocNamepathType : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJSDocType
    {
        public JSDocNamepathType()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocNamepathType;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode type
        {
            get;
            set;
        }
    }
}