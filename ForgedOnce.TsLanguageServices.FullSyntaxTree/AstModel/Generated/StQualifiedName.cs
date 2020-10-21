using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StQualifiedName : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName
    {
        public StQualifiedName(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName left, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier right): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.QualifiedName;
            this.left = left;
            this.right = right;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName _left;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier _right;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName left
        {
            get
            {
                return this._left;
            }

            set
            {
                this.SetAsParentFor(this._left, value);
                this._left = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier right
        {
            get
            {
                return this._right;
            }

            set
            {
                this.SetAsParentFor(this._right, value);
                this._right = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.QualifiedName()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), left = this.left != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IEntityName)this.left.GetTransportModelNode() : null, right = this.right != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier)this.right.GetTransportModelNode() : null};
        }
    }
}