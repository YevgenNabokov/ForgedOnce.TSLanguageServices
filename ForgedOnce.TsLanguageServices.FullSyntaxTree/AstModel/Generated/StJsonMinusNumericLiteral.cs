using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StJsonMinusNumericLiteral : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrefixUnaryExpression
    {
        public StJsonMinusNumericLiteral(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind @operator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression operand): base(flags, decorators, modifiers, @operator, operand)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PrefixUnaryExpression;
        }
    }
}