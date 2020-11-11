using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class JSDocCallbackTag : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJSDocTag, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INamedDeclaration
    {
        public JSDocCallbackTag()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocCallbackTag;
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

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclarationName name
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INode fullName
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocSignature typeExpression
        {
            get;
            set;
        }
    }
}