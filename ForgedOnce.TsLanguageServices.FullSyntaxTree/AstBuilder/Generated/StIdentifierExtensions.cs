using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StIdentifierExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier WithEscapedText(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier subject, string escapedText)
        {
            subject.escapedText = escapedText;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier WithOriginalKeywordKind(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind originalKeywordKind)
        {
            subject.originalKeywordKind = originalKeywordKind;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier WithIsInJSDocNamespace(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier subject, bool? isInJSDocNamespace)
        {
            subject.isInJSDocNamespace = isInJSDocNamespace;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}