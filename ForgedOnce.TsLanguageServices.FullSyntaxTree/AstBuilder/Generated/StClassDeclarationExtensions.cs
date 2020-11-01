using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StClassDeclarationExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassDeclaration WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassDeclaration WithTypeParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassDeclaration subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration> typeParameterBuilder)
        {
            subject.typeParameters.Add(typeParameterBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassDeclaration WithHeritageClaus(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassDeclaration subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause> heritageClausBuilder)
        {
            subject.heritageClauses.Add(heritageClausBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassDeclaration WithMember(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStClassElement member)
        {
            subject.members.Add(member);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassDeclaration WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassDeclaration WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassDeclaration subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassDeclaration WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}