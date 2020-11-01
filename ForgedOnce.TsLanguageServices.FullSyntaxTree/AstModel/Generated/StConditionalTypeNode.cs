using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StConditionalTypeNode : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode
    {
        public StConditionalTypeNode(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode checkType, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode extendsType, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode trueType, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode falseType): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ConditionalType;
            this.checkType = checkType;
            this.extendsType = extendsType;
            this.trueType = trueType;
            this.falseType = falseType;
        }

        public StConditionalTypeNode()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ConditionalType;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode _checkType;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode _extendsType;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode _trueType;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode _falseType;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode checkType
        {
            get
            {
                return this._checkType;
            }

            set
            {
                this.SetAsParentFor(this._checkType, value);
                this._checkType = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode extendsType
        {
            get
            {
                return this._extendsType;
            }

            set
            {
                this.SetAsParentFor(this._extendsType, value);
                this._extendsType = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode trueType
        {
            get
            {
                return this._trueType;
            }

            set
            {
                this.SetAsParentFor(this._trueType, value);
                this._trueType = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode falseType
        {
            get
            {
                return this._falseType;
            }

            set
            {
                this.SetAsParentFor(this._falseType, value);
                this._falseType = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ConditionalTypeNode()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), checkType = this.checkType != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode)this.checkType.GetTransportModelNode() : null, extendsType = this.extendsType != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode)this.extendsType.GetTransportModelNode() : null, trueType = this.trueType != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode)this.trueType.GetTransportModelNode() : null, falseType = this.falseType != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode)this.falseType.GetTransportModelNode() : null};
        }
    }
}