using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class FunctionDeclaration : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.FunctionLikeDeclarationBase, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclarationStatement
    {
        public FunctionDeclaration()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.FunctionDeclaration;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Block body
        {
            get;
            set;
        }
    }
}