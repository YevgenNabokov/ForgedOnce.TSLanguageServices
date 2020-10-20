using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StJSDocTypedefTag : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJSDocTag, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNamedDeclaration
    {
        public StJSDocTypedefTag(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier tagName, System.String comment, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier name, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode fullName, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode typeExpression): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocTypedefTag;
            this.tagName = tagName;
            this.comment = comment;
            this.name = name;
            this.fullName = fullName;
            this.typeExpression = typeExpression;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier tagName
        {
            get;
            set;
        }

        public System.String comment
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode fullName
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode typeExpression
        {
            get;
            set;
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocTypedefTag()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), tagName = this.tagName != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier)this.tagName.GetTransportModelNode() : null, comment = this.comment, name = this.name != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier)this.name.GetTransportModelNode() : null, fullName = this.fullName != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INode)this.fullName.GetTransportModelNode() : null, typeExpression = this.typeExpression != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode)this.typeExpression.GetTransportModelNode() : null};
        }
    }
}