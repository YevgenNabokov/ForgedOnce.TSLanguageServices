using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StExportDeclaration : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJSDocContainer, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationStatement
    {
        public StExportDeclaration(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name, System.Boolean isTypeOnly, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNamedExportBindings exportClause, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression moduleSpecifier): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ExportDeclaration;
            this.name = name;
            this.isTypeOnly = isTypeOnly;
            this.exportClause = exportClause;
            this.moduleSpecifier = moduleSpecifier;
        }

        public StExportDeclaration()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ExportDeclaration;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName _name;
        System.Boolean _isTypeOnly;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNamedExportBindings _exportClause;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression _moduleSpecifier;
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

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNamedExportBindings exportClause
        {
            get
            {
                return this._exportClause;
            }

            set
            {
                this.SetAsParentFor(this._exportClause, value);
                this._exportClause = value;
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
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExportDeclaration()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), name = this.name != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclarationName)this.name.GetTransportModelNode() : null, isTypeOnly = this.isTypeOnly, exportClause = this.exportClause != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INamedExportBindings)this.exportClause.GetTransportModelNode() : null, moduleSpecifier = this.moduleSpecifier != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.moduleSpecifier.GetTransportModelNode() : null};
        }
    }
}