using ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = ForgedOnce.TsLanguageServices.Model.DefinitionTree;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class ClassDefinitionExtensions
    {
        public static ClassDefinition WithModifiers(this ClassDefinition classDefinition, params LTSModel.Modifier[] modifiers)
        {
            foreach (var modifier in modifiers)
            {
                if (!classDefinition.Modifiers.Contains(modifier))
                {
                    classDefinition.Modifiers.Add(modifier);
                }
            }
            
            return classDefinition;
        }
    }
}
