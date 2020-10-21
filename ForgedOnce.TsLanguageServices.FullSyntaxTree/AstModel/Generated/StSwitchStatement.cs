using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StSwitchStatement : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement
    {
        public StSwitchStatement(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseBlock caseBlock, System.Nullable<System.Boolean> possiblyExhaustive): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.SwitchStatement;
            this.expression = expression;
            this.caseBlock = caseBlock;
            this.possiblyExhaustive = possiblyExhaustive;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression _expression;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseBlock _caseBlock;
        System.Nullable<System.Boolean> _possiblyExhaustive;
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

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseBlock caseBlock
        {
            get
            {
                return this._caseBlock;
            }

            set
            {
                this.SetAsParentFor(this._caseBlock, value);
                this._caseBlock = value;
            }
        }

        public System.Nullable<System.Boolean> possiblyExhaustive
        {
            get
            {
                return this._possiblyExhaustive;
            }

            set
            {
                this.EnsureIsEditable();
                this._possiblyExhaustive = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SwitchStatement()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), expression = this.expression != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.expression.GetTransportModelNode() : null, caseBlock = this.caseBlock != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CaseBlock)this.caseBlock.GetTransportModelNode() : null, possiblyExhaustive = this.possiblyExhaustive};
        }
    }
}