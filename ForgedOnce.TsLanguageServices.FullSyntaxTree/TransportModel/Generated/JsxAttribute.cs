using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class JsxAttribute : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IObjectLiteralElement, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJsxAttributeLike
    {
        public JsxAttribute()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxAttribute;
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

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INode initializer
        {
            get;
            set;
        }
    }
}