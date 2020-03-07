using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class InterfaceDefinitionExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.InterfaceDefinition WithModifier(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.InterfaceDefinition subject, ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier modifier)
        {
            subject.Modifiers.Add(modifier);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.InterfaceDefinition WithImplement(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.InterfaceDefinition subject, string referenceKey)
        {
            subject.Implements.Add(new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey});
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.InterfaceDefinition WithField(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.InterfaceDefinition subject, Func<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.FieldDeclaration, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.FieldDeclaration> fieldBuilder)
        {
            subject.Fields.Add(fieldBuilder(new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.FieldDeclaration()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.InterfaceDefinition WithMethod(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.InterfaceDefinition subject, Func<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration> methodBuilder)
        {
            subject.Methods.Add(methodBuilder(new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.InterfaceDefinition WithName(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.InterfaceDefinition subject, string name)
        {
            subject.Name = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.InterfaceDefinition WithTypeKey(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.InterfaceDefinition subject, string typeKey)
        {
            subject.TypeKey = typeKey;
            return subject;
        }
    }
}