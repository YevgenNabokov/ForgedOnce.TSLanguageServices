using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StJSDocSignatureExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature WithTypeParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTemplateTag typeParameter)
        {
            subject.typeParameters.Add(typeParameter);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature WithParameter(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocParameterTag parameter)
        {
            subject.parameters.Add(parameter);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature WithType(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag type)
        {
            subject.type = type;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator decorator)
        {
            subject.decorators.Add(decorator);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}