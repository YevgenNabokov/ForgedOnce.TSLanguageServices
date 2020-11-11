using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ConstructorTypeNode : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.FunctionOrConstructorTypeNodeBase
    {
        public ConstructorTypeNode()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ConstructorType;
        }
    }
}