using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StClassExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassLikeDeclarationBase, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPrimaryExpression
    {
        public StClassExpression(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier name, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration> typeParameters, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause> heritageClauses, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStClassElement> members): base(flags, decorators, modifiers, name, typeParameters, heritageClauses, members)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ClassExpression;
        }

        public StClassExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ClassExpression;
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ClassExpression()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), name = this.name != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier)this.name.GetTransportModelNode() : null, typeParameters = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeParameterDeclaration>(this.typeParameters), heritageClauses = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.HeritageClause>(this.heritageClauses), members = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IClassElement>(this.members)};
        }
    }
}