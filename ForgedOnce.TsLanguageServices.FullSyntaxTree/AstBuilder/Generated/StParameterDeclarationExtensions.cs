using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StParameterDeclarationExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration WithDotDotDotToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDotDotDotTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDotDotDotTokenToken> dotDotDotTokenBuilder)
        {
            subject.dotDotDotToken = dotDotDotTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDotDotDotTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration WithQuestionToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken> questionTokenBuilder)
        {
            subject.questionToken = questionTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration WithType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type)
        {
            subject.type = type;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration WithInitializer(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression initializer)
        {
            subject.initializer = initializer;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}