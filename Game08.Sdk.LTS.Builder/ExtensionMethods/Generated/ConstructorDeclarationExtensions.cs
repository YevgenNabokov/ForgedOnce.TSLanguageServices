using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class ConstructorDeclarationExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.ConstructorDeclaration WithModifier(this Game08.Sdk.LTS.Builder.DefinitionTree.ConstructorDeclaration subject, Game08.Sdk.LTS.Model.DefinitionTree.Modifier modifier)
        {
            subject.Modifiers.Add(modifier);
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.ConstructorDeclaration WithParameter(this Game08.Sdk.LTS.Builder.DefinitionTree.ConstructorDeclaration subject, Func<Game08.Sdk.LTS.Builder.DefinitionTree.MethodParameter, Game08.Sdk.LTS.Builder.DefinitionTree.MethodParameter> parameterBuilder)
        {
            subject.Parameters.Add(parameterBuilder(new Game08.Sdk.LTS.Builder.DefinitionTree.MethodParameter()));
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.ConstructorDeclaration WithBody(this Game08.Sdk.LTS.Builder.DefinitionTree.ConstructorDeclaration subject, Func<Game08.Sdk.LTS.Builder.DefinitionTree.StatementBlock, Game08.Sdk.LTS.Builder.DefinitionTree.StatementBlock> bodyBuilder)
        {
            subject.Body = bodyBuilder(new Game08.Sdk.LTS.Builder.DefinitionTree.StatementBlock());
            return subject;
        }
    }
}