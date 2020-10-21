using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public abstract class StNode : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeBase, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode
    {
        public StNode(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers)
        {
            this.decorators = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(this);
            this.modifiers = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(this);
            this.flags = flags;
            this.decorators.AddRange(decorators);
            this.modifiers.AddRange(modifiers);
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind _kind;
        ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags _flags;
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind kind
        {
            get
            {
                return this._kind;
            }

            set
            {
                this.EnsureIsEditable();
                this._kind = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags
        {
            get
            {
                return this._flags;
            }

            set
            {
                this.EnsureIsEditable();
                this._flags = value;
            }
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators
        {
            get;
            private set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers
        {
            get;
            private set;
        }
    }
}