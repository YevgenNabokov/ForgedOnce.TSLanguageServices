using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public abstract class StFunctionOrConstructorTypeNodeBase : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSignatureDeclarationBase, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode
    {
        public StFunctionOrConstructorTypeNodeBase(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName name, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration> typeParameters, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration> parameters, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type): base(flags, decorators, modifiers, name, typeParameters, parameters, type)
        {
        }

        public StFunctionOrConstructorTypeNodeBase()
        {
        }
    }
}