using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class MethodSignature : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SignatureDeclarationBase, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeElement
    {
        public MethodSignature()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.MethodSignature;
        }

        public System.Object _typeElementBrand
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.QuestionTokenToken questionToken
        {
            get;
            set;
        }
    }
}