using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StImportDeclaration : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement
    {
        public StImportDeclaration(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportClause importClause, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression moduleSpecifier): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ImportDeclaration;
            this.importClause = importClause;
            this.moduleSpecifier = moduleSpecifier;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportClause _importClause;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression _moduleSpecifier;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportClause importClause
        {
            get
            {
                return this._importClause;
            }

            set
            {
                this.SetAsParentFor(this._importClause, value);
                this._importClause = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression moduleSpecifier
        {
            get
            {
                return this._moduleSpecifier;
            }

            set
            {
                this.SetAsParentFor(this._moduleSpecifier, value);
                this._moduleSpecifier = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ImportDeclaration()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), importClause = this.importClause != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ImportClause)this.importClause.GetTransportModelNode() : null, moduleSpecifier = this.moduleSpecifier != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.moduleSpecifier.GetTransportModelNode() : null};
        }
    }
}