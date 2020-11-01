using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StSuperExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPrimaryExpression
    {
        public StSuperExpression(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.SuperKeyword;
        }

        public StSuperExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.SuperKeyword;
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SuperExpression()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers)};
        }
    }
}