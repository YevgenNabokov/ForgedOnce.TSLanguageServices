using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ExportDeclaration : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJSDocContainer, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclarationStatement
    {
        public ExportDeclaration()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ExportDeclaration;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclarationName name
        {
            get;
            set;
        }

        public System.Boolean isTypeOnly
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INamedExportBindings exportClause
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression moduleSpecifier
        {
            get;
            set;
        }
    }
}