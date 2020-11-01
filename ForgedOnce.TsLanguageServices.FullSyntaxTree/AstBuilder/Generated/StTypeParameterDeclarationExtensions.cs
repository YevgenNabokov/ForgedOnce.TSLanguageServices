using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StTypeParameterDeclarationExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration WithConstraint(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode constraint)
        {
            subject.constraint = constraint;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration WithDefault(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode @default)
        {
            subject.@default = @default;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration WithExpression(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression expression)
        {
            subject.expression = expression;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}