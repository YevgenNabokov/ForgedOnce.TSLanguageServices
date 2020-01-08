using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class StatementLocalDeclarationExtensions
    {
        static Game08.Sdk.LTS.Builder.DefinitionTree.StatementLocalDeclaration WithTypeReference(this Game08.Sdk.LTS.Builder.DefinitionTree.StatementLocalDeclaration subject, string referenceKey)
        {
            subject.TypeReference = new Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey};
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.StatementLocalDeclaration WithName(this Game08.Sdk.LTS.Builder.DefinitionTree.StatementLocalDeclaration subject, string name)
        {
            subject.Name = new Game08.Sdk.LTS.Builder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.StatementLocalDeclaration WithInitializer(this Game08.Sdk.LTS.Builder.DefinitionTree.StatementLocalDeclaration subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode initializer)
        {
            subject.Initializer = initializer;
            return subject;
        }
    }
}