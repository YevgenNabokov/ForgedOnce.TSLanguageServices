using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public abstract class StObjectLiteralExpressionBase<T> : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPrimaryExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclaration where T : IStObjectLiteralElement
    {
        public StObjectLiteralExpressionBase(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, System.Collections.Generic.List<T> properties): base(flags, decorators, modifiers)
        {
            this.properties = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<T>(this);
            this.properties.AddRange(properties);
        }

        public StObjectLiteralExpressionBase()
        {
            this.properties = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<T>(this);
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<T> properties
        {
            get;
            private set;
        }
    }
}