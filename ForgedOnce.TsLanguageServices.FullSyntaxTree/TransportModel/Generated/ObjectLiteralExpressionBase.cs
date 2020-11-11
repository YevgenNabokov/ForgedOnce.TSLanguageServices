using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ObjectLiteralExpressionBase<T> : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IPrimaryExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclaration where T : IObjectLiteralElement
    {
        public System.Collections.Generic.List<T> properties
        {
            get;
            set;
        }
    }
}