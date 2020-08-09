using ForgedOnce.TsLanguageServices.AstDescription.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.PreprocessorParts
{
    public class DescriptionAnalyzer
    {
        private readonly Settings pluginSettings;

        public DescriptionAnalyzer(Settings pluginSettings)
        {
            this.pluginSettings = pluginSettings;
        }

        public Parameters CreateParameters(Root description)
        {

            return new Parameters();
        }

        protected Dictionary<string, Declaration> BuildDeclarationGraph(Root description)
        {
            var result = new Dictionary<string, Declaration>();

            return result;
        }

        protected List<TypeReference> GetNonParameterTypeReferences(TypeReference typeReference, HashSet<string> typeParametersInScope)
        {
            var result = new List<TypeReference>();

            return result;
        }
    }
}
