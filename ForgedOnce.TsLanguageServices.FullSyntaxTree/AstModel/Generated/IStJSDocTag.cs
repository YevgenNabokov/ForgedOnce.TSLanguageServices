using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public interface IStJSDocTag : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode
    {
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier tagName
        {
            get;
            set;
        }

        System.String comment
        {
            get;
            set;
        }
    }
}