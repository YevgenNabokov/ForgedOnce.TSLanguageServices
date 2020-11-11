using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public interface IStNamedDeclaration : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode
    {
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name
        {
            get;
            set;
        }
    }
}