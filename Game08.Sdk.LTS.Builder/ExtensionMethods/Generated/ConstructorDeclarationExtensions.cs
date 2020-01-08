using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;
using Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class ConstructorDeclarationExtensions
    {
        static Game08.Sdk.LTS.Builder.DefinitionTree.ConstructorDeclaration WithModifier(this Game08.Sdk.LTS.Builder.DefinitionTree.ConstructorDeclaration subject, Game08.Sdk.LTS.Model.DefinitionTree.Modifier modifier)
        {
            subject.Modifiers.Add(modifier);
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.ConstructorDeclaration WithParameter(this Game08.Sdk.LTS.Builder.DefinitionTree.ConstructorDeclaration subject, Func<Game08.Sdk.LTS.Builder.DefinitionTree.MethodParameter, Game08.Sdk.LTS.Builder.DefinitionTree.MethodParameter> parameterBuilder)
        {
            subject.Parameters.Add(parameterBuilder(new Game08.Sdk.LTS.Builder.DefinitionTree.MethodParameter()));
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.ConstructorDeclaration WithBody(this Game08.Sdk.LTS.Builder.DefinitionTree.ConstructorDeclaration subject, Func<Game08.Sdk.LTS.Builder.DefinitionTree.StatementBlock, Game08.Sdk.LTS.Builder.DefinitionTree.StatementBlock> bodyBuilder)
        {
            subject.Body = bodyBuilder(new Game08.Sdk.LTS.Builder.DefinitionTree.StatementBlock());
            return subject;
        }
    }
}