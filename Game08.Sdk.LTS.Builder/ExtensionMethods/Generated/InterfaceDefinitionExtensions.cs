using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;
using Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class InterfaceDefinitionExtensions
    {
        static Game08.Sdk.LTS.Builder.DefinitionTree.InterfaceDefinition WithModifier(this Game08.Sdk.LTS.Builder.DefinitionTree.InterfaceDefinition subject, Game08.Sdk.LTS.Model.DefinitionTree.Modifier modifier)
        {
            subject.Modifiers.Add(modifier);
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.InterfaceDefinition WithImplement(this Game08.Sdk.LTS.Builder.DefinitionTree.InterfaceDefinition subject, string referenceKey)
        {
            subject.Implements.Add(new Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey});
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.InterfaceDefinition WithField(this Game08.Sdk.LTS.Builder.DefinitionTree.InterfaceDefinition subject, Func<Game08.Sdk.LTS.Builder.DefinitionTree.FieldDeclaration, Game08.Sdk.LTS.Builder.DefinitionTree.FieldDeclaration> fieldBuilder)
        {
            subject.Fields.Add(fieldBuilder(new Game08.Sdk.LTS.Builder.DefinitionTree.FieldDeclaration()));
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.InterfaceDefinition WithMethod(this Game08.Sdk.LTS.Builder.DefinitionTree.InterfaceDefinition subject, Func<Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration, Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration> methodBuilder)
        {
            subject.Methods.Add(methodBuilder(new Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration()));
            return subject;
        }

        static Game08.Sdk.LTS.Builder.DefinitionTree.InterfaceDefinition WithName(this Game08.Sdk.LTS.Builder.DefinitionTree.InterfaceDefinition subject, string name)
        {
            subject.Name = new Game08.Sdk.LTS.Builder.DefinitionTree.Identifier{Name = name};
            return subject;
        }
    }
}