using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StPropertyAssignmentExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAssignment WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAssignment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAssignment With_objectLiteralBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAssignment subject, object _objectLiteralBrand)
        {
            subject._objectLiteralBrand = _objectLiteralBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAssignment WithQuestionToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAssignment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken questionToken)
        {
            subject.questionToken = questionToken;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAssignment WithInitializer(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAssignment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression initializer)
        {
            subject.initializer = initializer;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAssignment WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAssignment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAssignment WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAssignment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAssignment WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAssignment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}