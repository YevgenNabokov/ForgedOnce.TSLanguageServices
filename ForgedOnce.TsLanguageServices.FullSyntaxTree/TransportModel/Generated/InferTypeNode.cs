using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class InferTypeNode : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode
    {
        public InferTypeNode()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.InferType;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeParameterDeclaration typeParameter
        {
            get;
            set;
        }
    }
}