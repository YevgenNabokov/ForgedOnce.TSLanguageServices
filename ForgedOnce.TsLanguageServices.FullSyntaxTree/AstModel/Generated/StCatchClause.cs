using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StCatchClause : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode
    {
        public StCatchClause(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclaration variableDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock block): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.CatchClause;
            this.variableDeclaration = variableDeclaration;
            this.block = block;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclaration variableDeclaration
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock block
        {
            get;
            set;
        }
    }
}