using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StImportClause : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNamedDeclaration
    {
        public StImportClause(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier name, System.Boolean isTypeOnly, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNamedImportBindings namedBindings): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ImportClause;
            this.name = name;
            this.isTypeOnly = isTypeOnly;
            this.namedBindings = namedBindings;
        }

        public StImportClause()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ImportClause;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName _name;
        System.Boolean _isTypeOnly;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNamedImportBindings _namedBindings;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name
        {
            get
            {
                return this._name;
            }

            set
            {
                this.SetAsParentFor(this._name, value);
                this._name = value;
            }
        }

        public System.Boolean isTypeOnly
        {
            get
            {
                return this._isTypeOnly;
            }

            set
            {
                this.EnsureIsEditable();
                this._isTypeOnly = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNamedImportBindings namedBindings
        {
            get
            {
                return this._namedBindings;
            }

            set
            {
                this.SetAsParentFor(this._namedBindings, value);
                this._namedBindings = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ImportClause()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), name = this.name != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier)this.name.GetTransportModelNode() : null, isTypeOnly = this.isTypeOnly, namedBindings = this.namedBindings != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INamedImportBindings)this.namedBindings.GetTransportModelNode() : null};
        }
    }
}