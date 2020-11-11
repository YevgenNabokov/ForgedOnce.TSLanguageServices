using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class TaggedTemplateExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IMemberExpression
    {
        public TaggedTemplateExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TaggedTemplateExpression;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ILeftHandSideExpression tag
        {
            get;
            set;
        }

        public System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode> typeArguments
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITemplateLiteral template
        {
            get;
            set;
        }
    }
}