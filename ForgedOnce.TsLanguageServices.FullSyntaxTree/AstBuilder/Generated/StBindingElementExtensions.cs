using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StBindingElementExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBindingElement WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBindingElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBindingElement WithPropertyName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBindingElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName propertyName)
        {
            subject.propertyName = propertyName;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBindingElement WithDotDotDotToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBindingElement subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDotDotDotTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDotDotDotTokenToken> dotDotDotTokenBuilder)
        {
            subject.dotDotDotToken = dotDotDotTokenBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDotDotDotTokenToken());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBindingElement WithInitializer(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBindingElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression initializer)
        {
            subject.initializer = initializer;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBindingElement WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBindingElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBindingElement WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBindingElement subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBindingElement WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBindingElement subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}