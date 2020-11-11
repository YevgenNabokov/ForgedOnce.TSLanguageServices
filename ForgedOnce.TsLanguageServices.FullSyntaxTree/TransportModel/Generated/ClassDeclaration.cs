using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ClassDeclaration : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ClassLikeDeclarationBase, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclarationStatement
    {
        public ClassDeclaration()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ClassDeclaration;
        }
    }
}