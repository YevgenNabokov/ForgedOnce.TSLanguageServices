using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public interface ILiteralLikeNode : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INode
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