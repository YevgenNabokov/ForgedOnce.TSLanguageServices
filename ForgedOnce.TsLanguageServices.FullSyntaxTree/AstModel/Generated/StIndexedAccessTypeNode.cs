using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StIndexedAccessTypeNode : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode
    {
        public StIndexedAccessTypeNode(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode objectType, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode indexType): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.IndexedAccessType;
            this.objectType = objectType;
            this.indexType = indexType;
        }

        public StIndexedAccessTypeNode()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.IndexedAccessType;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode _objectType;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode _indexType;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode objectType
        {
            get
            {
                return this._objectType;
            }

            set
            {
                this.SetAsParentFor(this._objectType, value);
                this._objectType = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode indexType
        {
            get
            {
                return this._indexType;
            }

            set
            {
                this.SetAsParentFor(this._indexType, value);
                this._indexType = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IndexedAccessTypeNode()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), objectType = this.objectType != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode)this.objectType.GetTransportModelNode() : null, indexType = this.indexType != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode)this.indexType.GetTransportModelNode() : null};
        }
    }
}