using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class PropertyAssignment : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJSDocContainer, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IObjectLiteralElement, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IObjectLiteralElementLike
    {
        public PropertyAssignment()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PropertyAssignment;
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

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.QuestionTokenToken questionToken
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression initializer
        {
            get;
            set;
        }
    }
}