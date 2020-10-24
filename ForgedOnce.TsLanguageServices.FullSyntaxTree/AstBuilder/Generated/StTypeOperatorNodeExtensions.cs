using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StTypeOperatorNodeExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeOperatorNode WithOperator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeOperatorNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind @operator)
        {
            subject.@operator = @operator;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeOperatorNode WithType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeOperatorNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type)
        {
            subject.type = type;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeOperatorNode WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeOperatorNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeOperatorNode WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeOperatorNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeOperatorNode WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeOperatorNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}