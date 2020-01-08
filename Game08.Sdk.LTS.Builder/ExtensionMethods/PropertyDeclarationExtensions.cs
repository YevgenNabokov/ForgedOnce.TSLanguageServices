using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
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
