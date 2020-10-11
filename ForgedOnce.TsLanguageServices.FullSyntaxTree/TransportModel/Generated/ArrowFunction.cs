using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ArrowFunction : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.FunctionLikeDeclarationBase, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IJSDocContainer
    {
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Token equalsGreaterThanToken
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IConciseBody body
        {
            get;
            set;
        }
    }
}