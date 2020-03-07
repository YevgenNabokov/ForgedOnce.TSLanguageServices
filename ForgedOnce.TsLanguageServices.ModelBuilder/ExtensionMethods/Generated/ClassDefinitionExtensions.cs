using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class ClassDefinitionExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ClassDefinition WithModifier(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ClassDefinition subject, ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier modifier)
        {
            subject.Modifiers.Add(modifier);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ClassDefinition WithBaseType(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ClassDefinition subject, string referenceKey)
        {
            subject.BaseType = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey};
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ClassDefinition WithImplement(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ClassDefinition subject, string referenceKey)
        {
            subject.Implements.Add(new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey});
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ClassDefinition WithField(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ClassDefinition subject, Func<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.FieldDeclaration, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.FieldDeclaration> fieldBuilder)
        {
            subject.Fields.Add(fieldBuilder(new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.FieldDeclaration()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ClassDefinition WithMethod(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ClassDefinition subject, Func<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration> methodBuilder)
        {
            subject.Methods.Add(methodBuilder(new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ClassDefinition WithProperty(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ClassDefinition subject, Func<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.PropertyDeclaration, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.PropertyDeclaration> propertyBuilder)
        {
            subject.Properties.Add(propertyBuilder(new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.PropertyDeclaration()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ClassDefinition WithConstructor(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ClassDefinition subject, Func<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ConstructorDeclaration, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ConstructorDeclaration> constructorBuilder)
        {
            subject.Constructor = constructorBuilder(new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ConstructorDeclaration());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ClassDefinition WithName(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ClassDefinition subject, string name)
        {
            subject.Name = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ClassDefinition WithTypeKey(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ClassDefinition subject, string typeKey)
        {
            subject.TypeKey = typeKey;
            return subject;
        }
    }
}