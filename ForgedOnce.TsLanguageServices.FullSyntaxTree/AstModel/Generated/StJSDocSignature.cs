using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StJSDocSignature : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJSDocType, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclaration
    {
        public StJSDocSignature(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTemplateTag> typeParameters, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocParameterTag> parameters, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag type): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocSignature;
            this.typeParameters = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTemplateTag>(this);
            this.parameters = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocParameterTag>(this);
            this.typeParameters.AddRange(typeParameters);
            this.parameters.AddRange(parameters);
            this.type = type;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTemplateTag> typeParameters
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocParameterTag> parameters
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag type
        {
            get;
            set;
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocSignature()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), typeParameters = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocTemplateTag>(this.typeParameters), parameters = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocParameterTag>(this.parameters), type = this.type != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocReturnTag)this.type.GetTransportModelNode() : null};
        }
    }
}