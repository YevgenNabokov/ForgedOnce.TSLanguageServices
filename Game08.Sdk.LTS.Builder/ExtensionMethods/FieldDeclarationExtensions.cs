using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class FieldDeclarationExtensions
    {
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
