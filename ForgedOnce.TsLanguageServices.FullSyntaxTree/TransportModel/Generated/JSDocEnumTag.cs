using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class JSDocEnumTag : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJSDocTag
    {
        public JSDocEnumTag()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocEnumTag;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier tagName
        {
            get;
            set;
        }

        public System.String comment
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocTypeExpression typeExpression
        {
            get;
            set;
        }
    }
}