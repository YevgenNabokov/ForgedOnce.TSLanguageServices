using ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = ForgedOnce.TsLanguageServices.Model.DefinitionTree;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
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
