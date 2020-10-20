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

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CatchClause()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), variableDeclaration = this.variableDeclaration != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.VariableDeclaration)this.variableDeclaration.GetTransportModelNode() : null, block = this.block != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Block)this.block.GetTransportModelNode() : null};
        }
    }
}