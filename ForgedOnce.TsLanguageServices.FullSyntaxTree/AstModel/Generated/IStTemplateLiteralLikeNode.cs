using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public interface IStTemplateLiteralLikeNode : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLiteralLikeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode
    {
        System.String rawText
        {
            get;
            set;
        }
    }
}