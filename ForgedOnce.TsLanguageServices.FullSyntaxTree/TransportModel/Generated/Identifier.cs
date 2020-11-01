using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class Identifier : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IPrimaryExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IEntityNameExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclarationName, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IPropertyName, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IEntityName, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IBindingName, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJSDocNamespaceBody, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModuleName, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJsxTagNameExpression
    {
        public Identifier()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.Identifier;
        }

        public System.String escapedText
        {
            get;
            set;
        }

        public System.Nullable<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind> originalKeywordKind
        {
            get;
            set;
        }

        public System.Nullable<System.Boolean> isInJSDocNamespace
        {
            get;
            set;
        }
    }
}