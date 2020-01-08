using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class MethodDeclarationExtensions
    {
        public static MethodDeclaration WithModifiers(this MethodDeclaration methodDeclaration, params LTSModel.Modifier[] modifiers)
        {
            foreach (var modifier in modifiers)
            {
                if (!methodDeclaration.Modifiers.Contains(modifier))
                {
                    methodDeclaration.Modifiers.Add(modifier);
                }
            }

            return methodDeclaration;
        }

        public static MethodDeclaration WithParameters(this MethodDeclaration methodDeclaration, params MethodParameter[] parameters)
        {
            foreach (var parameter in parameters)
            {
                methodDeclaration.Parameters.Add(parameter);
            }

            return methodDeclaration;
        }
    }
}
