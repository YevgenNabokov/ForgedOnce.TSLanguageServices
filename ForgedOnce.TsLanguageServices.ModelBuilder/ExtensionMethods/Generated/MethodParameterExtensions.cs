using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class MethodParameterExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodParameter WithName(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodParameter subject, string name)
        {
            subject.Name = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodParameter WithTypeReference(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodParameter subject, string referenceKey)
        {
            subject.TypeReference = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey};
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodParameter WithDefaultValue(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodParameter subject, Func<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionLiteral, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionLiteral> defaultValueBuilder)
        {
            subject.DefaultValue = defaultValueBuilder(new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionLiteral());
            return subject;
        }
    }
}