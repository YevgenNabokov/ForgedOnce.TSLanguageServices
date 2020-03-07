using ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = ForgedOnce.TsLanguageServices.Model.DefinitionTree;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class PropertyDeclarationExtensions
    {        
        public static PropertyDeclaration WithModifiers(this PropertyDeclaration propertyDeclaration, params LTSModel.Modifier[] modifiers)
        {
            foreach (var modifier in modifiers)
            {
                if (!propertyDeclaration.Modifiers.Contains(modifier))
                {
                    propertyDeclaration.Modifiers.Add(modifier);
                }
            }

            return propertyDeclaration;
        }
    }
}
