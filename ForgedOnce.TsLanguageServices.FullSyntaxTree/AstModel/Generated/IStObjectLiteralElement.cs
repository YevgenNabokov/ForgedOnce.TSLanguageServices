using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public interface IStObjectLiteralElement : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNamedDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode
    {
        System.Object _objectLiteralBrand
        {
            get;
            set;
        }
    }
}