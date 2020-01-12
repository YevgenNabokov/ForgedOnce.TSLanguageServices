using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class MethodParameterExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.MethodParameter WithName(this Game08.Sdk.LTS.Builder.DefinitionTree.MethodParameter subject, string name)
        {
            subject.Name = new Game08.Sdk.LTS.Builder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.MethodParameter WithTypeReference(this Game08.Sdk.LTS.Builder.DefinitionTree.MethodParameter subject, string referenceKey)
        {
            subject.TypeReference = new Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey};
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.MethodParameter WithDefaultValue(this Game08.Sdk.LTS.Builder.DefinitionTree.MethodParameter subject, Func<Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionLiteral, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionLiteral> defaultValueBuilder)
        {
            subject.DefaultValue = defaultValueBuilder(new Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionLiteral());
            return subject;
        }
    }
}