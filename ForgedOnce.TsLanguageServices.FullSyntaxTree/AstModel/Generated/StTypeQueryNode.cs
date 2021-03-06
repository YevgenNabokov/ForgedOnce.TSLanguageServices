using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StTypeQueryNode : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode
    {
        public StTypeQueryNode(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName exprName): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TypeQuery;
            this.exprName = exprName;
        }

        public StTypeQueryNode()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TypeQuery;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName _exprName;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName exprName
        {
            get
            {
                return this._exprName;
            }

            set
            {
                this.SetAsParentFor(this._exprName, value);
                this._exprName = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeQueryNode()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), exprName = this.exprName != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IEntityName)this.exprName.GetTransportModelNode() : null};
        }
    }
}