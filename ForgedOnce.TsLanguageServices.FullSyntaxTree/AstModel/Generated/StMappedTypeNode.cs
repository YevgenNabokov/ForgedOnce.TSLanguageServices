using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StMappedTypeNode : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclaration
    {
        public StMappedTypeNode(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode readonlyToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration typeParameter, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode questionToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.MappedType;
            this.readonlyToken = readonlyToken;
            this.typeParameter = typeParameter;
            this.questionToken = questionToken;
            this.type = type;
        }

        public StMappedTypeNode()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.MappedType;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode _readonlyToken;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration _typeParameter;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode _questionToken;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode _type;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode readonlyToken
        {
            get
            {
                return this._readonlyToken;
            }

            set
            {
                this.SetAsParentFor(this._readonlyToken, value);
                this._readonlyToken = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration typeParameter
        {
            get
            {
                return this._typeParameter;
            }

            set
            {
                this.SetAsParentFor(this._typeParameter, value);
                this._typeParameter = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode questionToken
        {
            get
            {
                return this._questionToken;
            }

            set
            {
                this.SetAsParentFor(this._questionToken, value);
                this._questionToken = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type
        {
            get
            {
                return this._type;
            }

            set
            {
                this.SetAsParentFor(this._type, value);
                this._type = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.MappedTypeNode()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), readonlyToken = this.readonlyToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INode)this.readonlyToken.GetTransportModelNode() : null, typeParameter = this.typeParameter != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeParameterDeclaration)this.typeParameter.GetTransportModelNode() : null, questionToken = this.questionToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INode)this.questionToken.GetTransportModelNode() : null, type = this.type != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode)this.type.GetTransportModelNode() : null};
        }
    }
}