using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public abstract class StIterationStatement : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement
    {
        public StIterationStatement(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement statement): base(flags, decorators, modifiers)
        {
            this.statement = statement;
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement _statement;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement statement
        {
            get
            {
                return this._statement;
            }

            set
            {
                this.SetAsParentFor(this._statement, value);
                this._statement = value;
            }
        }
    }
}