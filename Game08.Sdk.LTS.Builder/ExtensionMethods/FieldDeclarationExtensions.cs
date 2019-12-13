using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static class FieldDeclarationExtensions
    {
        public static FieldDeclaration WithName(this FieldDeclaration fieldDeclaration, string name)
        {
            fieldDeclaration.Name = new Identifier() { Name = name };
            return fieldDeclaration;
        }

        public static FieldDeclaration WithType(this FieldDeclaration fieldDeclaration, string typeReferenceKey)
        {
            fieldDeclaration.TypeReference = new TypeReferenceId() { ReferenceKey = typeReferenceKey };
            return fieldDeclaration;
        }

        public static FieldDeclaration WithInitializer(this FieldDeclaration fieldDeclaration, ExpressionNode expression)
        {
            fieldDeclaration.Initializer = expression;
            return fieldDeclaration;
        }

        public static FieldDeclaration WithModifiers(this FieldDeclaration fieldDeclaration, params LTSModel.Modifier[] modifiers)
        {
            foreach (var modifier in modifiers)
            {
                if (!fieldDeclaration.Modifiers.Contains(modifier))
                {
                    fieldDeclaration.Modifiers.Add(modifier);
                }
            }

            return fieldDeclaration;
        }
    }
}
