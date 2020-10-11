using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ShorthandPropertyAssignment : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJSDocContainer, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IObjectLiteralElement, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IObjectLiteralElementLike
    {
        public ShorthandPropertyAssignment()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ShorthandPropertyAssignment;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclarationName name
        {
            get;
            set;
        }

        public System.Object _objectLiteralBrand
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token questionToken
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token exclamationToken
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token equalsToken
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression objectAssignmentInitializer
        {
            get;
            set;
        }
    }
}