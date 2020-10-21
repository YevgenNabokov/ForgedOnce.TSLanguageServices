using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StLabeledStatement : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJSDocContainer
    {
        public StLabeledStatement(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier label, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement statement): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.LabeledStatement;
            this.label = label;
            this.statement = statement;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier _label;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement _statement;
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

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement statement
        {
            get
            {
                return this._statement;
            }

            set
            {
                this.SetAsParentFor(this._statement, value);
                this._statement = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.LabeledStatement()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), label = this.label != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier)this.label.GetTransportModelNode() : null, statement = this.statement != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IStatement)this.statement.GetTransportModelNode() : null};
        }
    }
}