using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.PreprocessorParts.ParametersCreation
{
    public class ModelSettings
    {
        public Dictionary<string, string> InterfacesMappedToPrimitiveTypes = new Dictionary<string, string>()
        {
            { "__String", typeof(string).FullName }
        };

        public HashSet<string> InterfacesMappedAsCollection = new HashSet<string>()
        {
            "NodeArray"
        };

        public Dictionary<string, string> PrimitiveTypesMappings = new Dictionary<string, string>()
        {
            { "string", typeof(string).FullName },
            { "number", typeof(int).FullName },
            { "boolean", typeof(bool).FullName },
            { "any", typeof(object).FullName },
        };

        public HashSet<string> OtherExcludedTypes;

        public HashSet<string> ExcludedAstNodes;

        public HashSet<string> TypesRepresentedAsInterface;

        public ModelSettings(Settings settings)
        {
            this.OtherExcludedTypes = new HashSet<string>(settings.OtherExcludedTypes.Split(','));
            this.ExcludedAstNodes = new HashSet<string>(settings.ExcludedAstNodes.Split(','));
            this.TypesRepresentedAsInterface = new HashSet<string>(settings.TypesRepresentedAsInterface.Split(','));
        }
    }
}
