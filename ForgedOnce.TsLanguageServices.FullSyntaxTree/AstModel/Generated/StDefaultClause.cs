using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StDefaultClause : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStCaseOrDefaultClause
    {
        public StDefaultClause(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement> statements): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.DefaultClause;
            this.statements = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement>(this);
            this.statements.AddRange(statements);
        }

        public StDefaultClause()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.DefaultClause;
            this.statements = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement>(this);
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement> statements
        {
            get;
            private set;
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.DefaultClause()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), statements = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IStatement>(this.statements)};
        }
    }
}