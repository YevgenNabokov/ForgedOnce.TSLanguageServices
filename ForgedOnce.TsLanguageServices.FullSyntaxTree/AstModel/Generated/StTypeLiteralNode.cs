using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StTypeLiteralNode : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclaration
    {
        public StTypeLiteralNode(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeElement> members): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TypeLiteral;
            this.members = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeElement>(this);
            this.members.AddRange(members);
        }

        public StTypeLiteralNode()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TypeLiteral;
            this.members = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeElement>(this);
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeElement> members
        {
            get;
            private set;
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeLiteralNode()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), members = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeElement>(this.members)};
        }
    }
}