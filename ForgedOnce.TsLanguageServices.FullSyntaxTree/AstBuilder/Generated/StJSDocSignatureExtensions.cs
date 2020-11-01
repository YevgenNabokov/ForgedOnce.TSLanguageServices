using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJSDocSignatureExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature WithTypeParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTemplateTag, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTemplateTag> typeParameterBuilder)
        {
            subject.typeParameters.Add(typeParameterBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTemplateTag()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature WithParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocParameterTag, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocParameterTag> parameterBuilder)
        {
            subject.parameters.Add(parameterBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocParameterTag()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature WithType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag> typeBuilder)
        {
            subject.type = typeBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}