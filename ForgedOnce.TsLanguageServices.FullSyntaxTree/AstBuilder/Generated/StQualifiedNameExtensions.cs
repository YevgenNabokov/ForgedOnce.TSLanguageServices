using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StQualifiedNameExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQualifiedName WithLeft(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQualifiedName subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName left)
        {
            subject.left = left;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQualifiedName WithRight(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQualifiedName subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier> rightBuilder)
        {
            subject.right = rightBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQualifiedName WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQualifiedName subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQualifiedName WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQualifiedName subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQualifiedName WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQualifiedName subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}