using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StFunctionExpression : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionLikeDeclarationBase, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPrimaryExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJSDocContainer
    {
        public StFunctionExpression(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName name, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration> typeParameters, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration> parameters, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock body, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken asteriskToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken questionToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken exclamationToken): base(flags, decorators, modifiers, name, typeParameters, parameters, type, asteriskToken, questionToken, exclamationToken)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.FunctionExpression;
            this.body = body;
        }

        public StFunctionExpression()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.FunctionExpression;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock _body;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock body
        {
            get
            {
                return this._body;
            }

            set
            {
                this.SetAsParentFor(this._body, value);
                this._body = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.FunctionExpression()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), name = this.name != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IPropertyName)this.name.GetTransportModelNode() : null, typeParameters = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeParameterDeclaration>(this.typeParameters), parameters = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ParameterDeclaration>(this.parameters), type = this.type != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ITypeNode)this.type.GetTransportModelNode() : null, _functionLikeDeclarationBrand = this._functionLikeDeclarationBrand, asteriskToken = this.asteriskToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AsteriskTokenToken)this.asteriskToken.GetTransportModelNode() : null, questionToken = this.questionToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.QuestionTokenToken)this.questionToken.GetTransportModelNode() : null, exclamationToken = this.exclamationToken != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExclamationTokenToken)this.exclamationToken.GetTransportModelNode() : null, body = this.body != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Block)this.body.GetTransportModelNode() : null};
        }
    }
}