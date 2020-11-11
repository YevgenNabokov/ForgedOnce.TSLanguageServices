using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public abstract class StJSDocNamespaceDeclaration : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StModuleDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJSDocNamespaceBody
    {
        public StJSDocNamespaceDeclaration(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModuleName name, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode body): base(flags, decorators, modifiers, name, body)
        {
        }

        public StJSDocNamespaceDeclaration()
        {
        }
    }
}