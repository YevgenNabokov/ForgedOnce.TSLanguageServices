using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public interface IStLiteralLikeNode : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode
    {
        System.String text
        {
            get;
            set;
        }

        System.Nullable<System.Boolean> isUnterminated
        {
            get;
            set;
        }

        System.Nullable<System.Boolean> hasExtendedUnicodeEscape
        {
            get;
            set;
        }
    }
}