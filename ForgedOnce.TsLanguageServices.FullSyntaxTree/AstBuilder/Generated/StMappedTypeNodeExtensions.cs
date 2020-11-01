using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StMappedTypeNodeExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMappedTypeNode WithReadonlyToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMappedTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode readonlyToken)
        {
            subject.readonlyToken = readonlyToken;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMappedTypeNode WithTypeParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMappedTypeNode subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration> typeParameterBuilder)
        {
            subject.typeParameter = typeParameterBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMappedTypeNode WithQuestionToken(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMappedTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode questionToken)
        {
            subject.questionToken = questionToken;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMappedTypeNode WithType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMappedTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode type)
        {
            subject.type = type;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMappedTypeNode WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMappedTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMappedTypeNode WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMappedTypeNode subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMappedTypeNode WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMappedTypeNode subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}