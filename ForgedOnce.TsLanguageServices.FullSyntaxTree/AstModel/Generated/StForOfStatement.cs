using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StForOfStatement : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIterationStatement
    {
        public StForOfStatement(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement statement, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAwaitKeywordToken awaitModifier, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStForInitializer initializer, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression): base(flags, decorators, modifiers, statement)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ForOfStatement;
            this.awaitModifier = awaitModifier;
            this.initializer = initializer;
            this.expression = expression;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAwaitKeywordToken awaitModifier
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStForInitializer initializer
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression
        {
            get;
            set;
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ForOfStatement()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), statement = this.statement != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IStatement)this.statement.GetTransportModelNode() : null, awaitModifier = this.awaitModifier != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AwaitKeywordToken)this.awaitModifier.GetTransportModelNode() : null, initializer = this.initializer != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IForInitializer)this.initializer.GetTransportModelNode() : null, expression = this.expression != null ? (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression)this.expression.GetTransportModelNode() : null};
        }
    }
}