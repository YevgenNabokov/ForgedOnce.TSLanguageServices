using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StJSDocTypeLiteral : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJSDocType
    {
        public StJSDocTypeLiteral(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocPropertyLikeTag> jsDocPropertyTags, System.Nullable<System.Boolean> isArrayType): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocTypeLiteral;
            this.jsDocPropertyTags = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocPropertyLikeTag>(this);
            this.jsDocPropertyTags.AddRange(jsDocPropertyTags);
            this.isArrayType = isArrayType;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocPropertyLikeTag> jsDocPropertyTags
        {
            get;
            set;
        }

        public System.Nullable<System.Boolean> isArrayType
        {
            get;
            set;
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocTypeLiteral()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), jsDocPropertyTags = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocPropertyLikeTag>(this.jsDocPropertyTags), isArrayType = this.isArrayType};
        }
    }
}