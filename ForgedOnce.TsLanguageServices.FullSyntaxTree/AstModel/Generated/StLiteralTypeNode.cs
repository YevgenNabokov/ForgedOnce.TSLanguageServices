using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StLiteralTypeNode : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode
    {
        public StLiteralTypeNode(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode literal): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.LiteralType;
            this.literal = literal;
        }

        public StLiteralTypeNode()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.LiteralType;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode _literal;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode literal
        {
            get
            {
                return this._literal;
            }

            set
            {
                this.SetAsParentFor(this._literal, value);
                this._literal = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.LiteralTypeNode()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), literal = this.literal != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INode)this.literal.GetTransportModelNode() : null};
        }
    }
}