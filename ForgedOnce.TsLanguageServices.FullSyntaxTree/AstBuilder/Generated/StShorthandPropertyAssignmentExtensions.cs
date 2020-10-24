using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StShorthandPropertyAssignmentExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StShorthandPropertyAssignment WithName(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StShorthandPropertyAssignment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName name)
        {
            subject.name = name;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StShorthandPropertyAssignment With_objectLiteralBrand(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StShorthandPropertyAssignment subject, object _objectLiteralBrand)
        {
            subject._objectLiteralBrand = _objectLiteralBrand;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StShorthandPropertyAssignment WithQuestionToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StShorthandPropertyAssignment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken questionToken)
        {
            subject.questionToken = questionToken;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StShorthandPropertyAssignment WithExclamationToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StShorthandPropertyAssignment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken exclamationToken)
        {
            subject.exclamationToken = exclamationToken;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StShorthandPropertyAssignment WithEqualsToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StShorthandPropertyAssignment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsTokenToken equalsToken)
        {
            subject.equalsToken = equalsToken;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StShorthandPropertyAssignment WithObjectAssignmentInitializer(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StShorthandPropertyAssignment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression objectAssignmentInitializer)
        {
            subject.objectAssignmentInitializer = objectAssignmentInitializer;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StShorthandPropertyAssignment WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StShorthandPropertyAssignment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StShorthandPropertyAssignment WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StShorthandPropertyAssignment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StShorthandPropertyAssignment WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StShorthandPropertyAssignment subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}