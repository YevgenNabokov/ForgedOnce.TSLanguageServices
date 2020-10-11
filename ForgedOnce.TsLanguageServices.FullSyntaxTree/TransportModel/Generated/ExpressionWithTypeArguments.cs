using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ExpressionWithTypeArguments : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeWithTypeArguments
    {
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ILeftHandSideExpression expression
        {
            get;
            set;
        }
    }
}