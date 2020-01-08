using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;
using Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class MethodDeclarationExtensions
    {
        static Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration WithModifier(this Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration subject, Game08.Sdk.LTS.Model.DefinitionTree.Modifier modifier)
        {
            subject.Modifiers.Add(modifier);
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration WithName(this Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration subject, string name)
        {
            subject.Name = new Game08.Sdk.LTS.Builder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration WithParameter(this Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration subject, Func<Game08.Sdk.LTS.Builder.DefinitionTree.MethodParameter, Game08.Sdk.LTS.Builder.DefinitionTree.MethodParameter> parameterBuilder)
        {
            subject.Parameters.Add(parameterBuilder(new Game08.Sdk.LTS.Builder.DefinitionTree.MethodParameter()));
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration WithBody(this Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration subject, Func<Game08.Sdk.LTS.Builder.DefinitionTree.StatementBlock, Game08.Sdk.LTS.Builder.DefinitionTree.StatementBlock> bodyBuilder)
        {
            subject.Body = bodyBuilder(new Game08.Sdk.LTS.Builder.DefinitionTree.StatementBlock());
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration WithReturnType(this Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration subject, string referenceKey)
        {
            subject.ReturnType = new Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey};
            return subject;
        }
    }
}