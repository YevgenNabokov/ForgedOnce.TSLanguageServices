using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StJSDocPropertyTag : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocPropertyLikeTag
    {
        public StJSDocPropertyTag(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier tagName, System.String comment, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName name, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression typeExpression, System.Boolean isNameFirst, System.Boolean isBracketed): base(flags, decorators, modifiers, tagName, comment, name, typeExpression, isNameFirst, isBracketed)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocPropertyTag;
        }

        public StJSDocPropertyTag()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocPropertyTag;
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocPropertyTag()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), tagName = this.tagName != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier)this.tagName.GetTransportModelNode() : null, comment = this.comment, name = this.name != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IEntityName)this.name.GetTransportModelNode() : null, typeExpression = this.typeExpression != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocTypeExpression)this.typeExpression.GetTransportModelNode() : null, isNameFirst = this.isNameFirst, isBracketed = this.isBracketed};
        }
    }
}