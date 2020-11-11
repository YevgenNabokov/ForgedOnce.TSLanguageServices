using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class JSDocNullableType : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJSDocType
    {
        public JSDocNullableType()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocNullableType;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode type
        {
            get;
            set;
        }
    }
}