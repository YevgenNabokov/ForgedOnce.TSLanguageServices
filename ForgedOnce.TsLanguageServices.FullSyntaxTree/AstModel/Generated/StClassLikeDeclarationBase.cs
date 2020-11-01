using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public abstract class StClassLikeDeclarationBase : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJSDocContainer, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNamedDeclaration
    {
        public StClassLikeDeclarationBase(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier name, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration> typeParameters, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause> heritageClauses, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStClassElement> members): base(flags, decorators, modifiers)
        {
            this.typeParameters = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(this);
            this.heritageClauses = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause>(this);
            this.members = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStClassElement>(this);
            this.name = name;
            this.typeParameters.AddRange(typeParameters);
            this.heritageClauses.AddRange(heritageClauses);
            this.members.AddRange(members);
        }

        public StClassLikeDeclarationBase()
        {
            this.typeParameters = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(this);
            this.heritageClauses = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause>(this);
            this.members = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStClassElement>(this);
        }

        ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName _name;
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

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration> typeParameters
        {
            get;
            private set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause> heritageClauses
        {
            get;
            private set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStClassElement> members
        {
            get;
            private set;
        }
    }
}