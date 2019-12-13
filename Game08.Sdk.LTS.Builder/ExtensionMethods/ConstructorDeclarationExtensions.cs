using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static class ConstructorDeclarationExtensions
    {
        public static ConstructorDeclaration WithBody(this ConstructorDeclaration constructorDeclaration, StatementBlock body)
        {
            constructorDeclaration.Body = body;
            return constructorDeclaration;
        }

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
