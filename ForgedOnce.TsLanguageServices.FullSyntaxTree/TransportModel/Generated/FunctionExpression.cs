using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class FunctionExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.FunctionLikeDeclarationBase, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IPrimaryExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJSDocContainer
    {
        public FunctionExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.FunctionExpression;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Block body
        {
            get;
            set;
        }
    }
}