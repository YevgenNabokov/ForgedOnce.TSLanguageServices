using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class StatementLocalDeclarationExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.StatementLocalDeclaration WithTypeReference(this Game08.Sdk.LTS.Builder.DefinitionTree.StatementLocalDeclaration subject, string referenceKey)
        {
            subject.TypeReference = new Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey};
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.StatementLocalDeclaration WithName(this Game08.Sdk.LTS.Builder.DefinitionTree.StatementLocalDeclaration subject, string name)
        {
            subject.Name = new Game08.Sdk.LTS.Builder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.StatementLocalDeclaration WithInitializer(this Game08.Sdk.LTS.Builder.DefinitionTree.StatementLocalDeclaration subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode initializer)
        {
            subject.Initializer = initializer;
            return subject;
        }
    }
}