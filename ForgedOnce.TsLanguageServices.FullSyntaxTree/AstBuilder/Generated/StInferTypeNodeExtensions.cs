using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StInferTypeNodeExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInferTypeNode WithTypeParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInferTypeNode subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration> typeParameterBuilder)
        {
            subject.typeParameter = typeParameterBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInferTypeNode WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInferTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInferTypeNode WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInferTypeNode subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInferTypeNode WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInferTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}