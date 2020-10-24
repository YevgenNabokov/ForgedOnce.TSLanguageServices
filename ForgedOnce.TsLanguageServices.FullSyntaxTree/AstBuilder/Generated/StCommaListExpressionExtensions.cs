using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StCommaListExpressionExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCommaListExpression WithElement(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCommaListExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression element)
        {
            subject.elements.Add(element);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCommaListExpression WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCommaListExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCommaListExpression WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCommaListExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCommaListExpression WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCommaListExpression subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}