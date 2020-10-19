using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StTypeReferenceNode : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeWithTypeArguments
    {
        public StTypeReferenceNode(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode> typeArguments, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName typeName): base(flags, decorators, modifiers, typeArguments)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TypeReference;
            this.typeName = typeName;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName typeName
        {
            get;
            set;
        }
    }
}