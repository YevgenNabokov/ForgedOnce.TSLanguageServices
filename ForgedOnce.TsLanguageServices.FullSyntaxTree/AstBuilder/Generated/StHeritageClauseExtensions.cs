using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StHeritageClauseExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause WithToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind token)
        {
            subject.token = token;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause WithType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExpressionWithTypeArguments, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExpressionWithTypeArguments> typeBuilder)
        {
            subject.types.Add(typeBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExpressionWithTypeArguments()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}