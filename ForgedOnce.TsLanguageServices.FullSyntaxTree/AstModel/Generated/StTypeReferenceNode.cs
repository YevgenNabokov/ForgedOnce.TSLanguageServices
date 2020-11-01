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

        public StTypeReferenceNode()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TypeReference;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName _typeName;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName typeName
        {
            get
            {
                return this._typeName;
            }

            set
            {
                this.SetAsParentFor(this._typeName, value);
                this._typeName = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeReferenceNode()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), typeArguments = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode>(this.typeArguments), typeName = this.typeName != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IEntityName)this.typeName.GetTransportModelNode() : null};
        }
    }
}