using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StClassExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassExpression WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassExpression WithTypeParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration typeParameter)
        {
            subject.typeParameters.Add(typeParameter);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassExpression WithHeritageClaus(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause heritageClaus)
        {
            subject.heritageClauses.Add(heritageClaus);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassExpression WithMember(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStClassElement member)
        {
            subject.members.Add(member);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}