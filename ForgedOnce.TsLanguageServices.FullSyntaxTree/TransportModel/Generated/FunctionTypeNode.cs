using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class FunctionTypeNode : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.FunctionOrConstructorTypeNodeBase
    {
        public FunctionTypeNode()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.FunctionType;
        }
    }
}