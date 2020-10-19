using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StJsxOpeningElement : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression
    {
        public StJsxOpeningElement(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxTagNameExpression tagName, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode> typeArguments, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttributes attributes): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxOpeningElement;
            this.tagName = tagName;
            this.typeArguments = typeArguments;
            this.attributes = attributes;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxTagNameExpression tagName
        {
            get;
            set;
        }

        public System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode> typeArguments
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttributes attributes
        {
            get;
            set;
        }
    }
}