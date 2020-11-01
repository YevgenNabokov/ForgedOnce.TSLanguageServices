using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StSpreadAssignment : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJSDocContainer, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStObjectLiteralElement, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStObjectLiteralElementLike
    {
        public StSpreadAssignment(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name, System.Object _objectLiteralBrand, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.SpreadAssignment;
            this.name = name;
            this._objectLiteralBrand = _objectLiteralBrand;
            this.expression = expression;
        }

        public StSpreadAssignment()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.SpreadAssignment;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName _name;
        System.Object __objectLiteralBrand;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression _expression;
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

        public System.Object _objectLiteralBrand
        {
            get
            {
                return this.__objectLiteralBrand;
            }

            set
            {
                this.EnsureIsEditable();
                this.__objectLiteralBrand = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression
        {
            get
            {
                return this._expression;
            }

            set
            {
                this.SetAsParentFor(this._expression, value);
                this._expression = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SpreadAssignment()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), name = this.name != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IDeclarationName)this.name.GetTransportModelNode() : null, _objectLiteralBrand = this._objectLiteralBrand, expression = this.expression != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.expression.GetTransportModelNode() : null};
        }
    }
}