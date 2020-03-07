using ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = ForgedOnce.TsLanguageServices.Model.DefinitionTree;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class ConstructorDeclarationExtensions
    {        
        public static ConstructorDeclaration WithParameters(this ConstructorDeclaration constructorDeclaration, params MethodParameter[] parameters)
        {
            foreach (var parameter in parameters)
            {
                constructorDeclaration.Parameters.Add(parameter);
            }

            return constructorDeclaration;
        }

        public static ConstructorDeclaration WithModifiers(this ConstructorDeclaration constructorDeclaration, params LTSModel.Modifier[] modifiers)
        {
            foreach (var modifier in modifiers)
            {
                if (!constructorDeclaration.Modifiers.Contains(modifier))
                {
                    constructorDeclaration.Modifiers.Add(modifier);
                }
            }

            return constructorDeclaration;
        }
    }
}
