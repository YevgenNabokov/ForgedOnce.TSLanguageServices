using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class NewExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IPrimaryExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclaration
    {
        public NewExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NewExpression;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ILeftHandSideExpression expression
        {
            get;
            set;
        }

        public System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode> typeArguments
        {
            get;
            set;
        }

        public System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression> arguments
        {
            get;
            set;
        }
    }
}