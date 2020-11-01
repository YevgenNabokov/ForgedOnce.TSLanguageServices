using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StImportTypeNode : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeWithTypeArguments
    {
        public StImportTypeNode(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode> typeArguments, System.Nullable<System.Boolean> isTypeOf, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode argument, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName qualifier): base(flags, decorators, modifiers, typeArguments)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ImportType;
            this.isTypeOf = isTypeOf;
            this.argument = argument;
            this.qualifier = qualifier;
        }

        public StImportTypeNode()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ImportType;
        }

        System.Nullable<System.Boolean> _isTypeOf;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode _argument;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName _qualifier;
        public System.Nullable<System.Boolean> isTypeOf
        {
            get
            {
                return this._isTypeOf;
            }

            set
            {
                this.EnsureIsEditable();
                this._isTypeOf = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode argument
        {
            get
            {
                return this._argument;
            }

            set
            {
                this.SetAsParentFor(this._argument, value);
                this._argument = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName qualifier
        {
            get
            {
                return this._qualifier;
            }

            set
            {
                this.SetAsParentFor(this._qualifier, value);
                this._qualifier = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ImportTypeNode()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), typeArguments = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode>(this.typeArguments), isTypeOf = this.isTypeOf, argument = this.argument != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode)this.argument.GetTransportModelNode() : null, qualifier = this.qualifier != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IEntityName)this.qualifier.GetTransportModelNode() : null};
        }
    }
}