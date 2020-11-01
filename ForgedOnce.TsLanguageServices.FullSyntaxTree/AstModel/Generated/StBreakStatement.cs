using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StBreakStatement : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement
    {
        public StBreakStatement(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier label): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.BreakStatement;
            this.label = label;
        }

        public StBreakStatement()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.BreakStatement;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier _label;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier label
        {
            get
            {
                return this._label;
            }

            set
            {
                this.SetAsParentFor(this._label, value);
                this._label = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BreakStatement()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), label = this.label != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier)this.label.GetTransportModelNode() : null};
        }
    }
}