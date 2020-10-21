using ForgedOnce.Core.Interfaces;
using ForgedOnce.CSharp;
using ForgedOnce.Environment.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin
{
    public class PluginFactory : ICodeGenerationPluginFactory<Settings, Parameters, CodeFileCSharp>
    {
        public ICodeGenerationPlugin CreatePlugin(JObject configuration, IPipelineCreationContext context, IPluginPreprocessor<CodeFileCSharp, Parameters, Settings> pluginPreprocessor = null)
        {
            Settings settings = new Settings();
            this.SetFromConfiguration((v) => settings.AstDescriptionJsonFilePath = v, configuration, Settings.AstDescriptionJsonFilePathKey);
            this.SetFromConfiguration((v) => settings.AstNodeBaseTypeQualified = v, configuration, Settings.AstNodeBaseTypeQualifiedKey);
            this.SetFromConfiguration((v) => settings.ExcludedAstNodes = v, configuration, Settings.ExcludedAstNodesKey);
            this.SetFromConfiguration((v) => settings.OtherExcludedTypes = v, configuration, Settings.OtherExcludedTypesKey);
            this.SetFromConfiguration((v) => settings.TypesRepresentedAsInterface = v, configuration, Settings.TypesRepresentedAsInterfaceKey);
            this.SetFromConfiguration((v) => settings.ExcludedProperties = v, configuration, Settings.ExcludedPropertiesKey);
            this.SetFromConfiguration((v) => settings.CsTransportModelNamespace = v, configuration, Settings.CsTransportModelNamespaceKey);
            this.SetFromConfiguration((v) => settings.CsTransportModelCollectionType = v, configuration, Settings.CsTransportModelCollectionTypeKey);
            this.SetFromConfiguration((v) => settings.CsTransportModelAssemblyName = v, configuration, Settings.CsTransportModelAssemblyNameKey);
            this.SetFromConfiguration((v) => settings.CsAstModelNamespace = v, configuration, Settings.CsAstModelNamespaceKey);
            this.SetFromConfiguration((v) => settings.CsAstModelNodeCollectionType = v, configuration, Settings.CsAstModelNodeCollectionTypeKey);

            settings.BasePath = context.BasePath;

            return new Plugin()
            {
                Preprocessor = new Preprocessor(),
                Settings = settings
            };
        }

        private void SetFromConfiguration(Action<string> target, JObject configuration, string key)
        {
            if (configuration != null && configuration.ContainsKey(key))
            {
                target(configuration[key].Value<string>());
            }
        }
    }
}
