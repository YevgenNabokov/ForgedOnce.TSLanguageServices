using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StCommaListExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression
    {
        public StCommaListExpression(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression> elements): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.CommaListExpression;
            this.elements = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression>(this);
            this.elements.AddRange(elements);
        }

        public StCommaListExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.CommaListExpression;
            this.elements = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression>(this);
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression> elements
        {
            get;
            private set;
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CommaListExpression()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), elements = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression>(this.elements)};
        }
    }
}