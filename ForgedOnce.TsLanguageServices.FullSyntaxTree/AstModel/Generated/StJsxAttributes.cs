using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StJsxAttributes : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StObjectLiteralExpressionBase<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxAttributeLike>
    {
        public StJsxAttributes(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxAttributeLike> properties): base(flags, decorators, modifiers, properties)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxAttributes;
        }
    }
}