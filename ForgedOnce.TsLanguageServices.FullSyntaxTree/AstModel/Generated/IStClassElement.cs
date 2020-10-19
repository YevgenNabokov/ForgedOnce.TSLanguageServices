using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public interface IStClassElement : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNamedDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode
    {
        System.Object _classElementBrand
        {
            get;
            set;
        }
    }
}