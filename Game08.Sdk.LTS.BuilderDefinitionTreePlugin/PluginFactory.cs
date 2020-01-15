using Game08.Sdk.CodeMixer.Core.Interfaces;
using Game08.Sdk.CodeMixer.CSharp;
using Game08.Sdk.CodeMixer.Environment.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.BuilderDefinitionTreePlugin
{
    public class PluginFactory : ICodeGenerationPluginFactory<Settings, Parameters, CodeFileCSharp>
    {
        public ICodeGenerationPlugin CreatePlugin(JObject configuration, IPluginPreprocessor<CodeFileCSharp, Parameters> pluginPreprocessor = null)
        {
            Settings settings = new Settings();
            this.SetFromConfiguration((v) => settings.OutputNamespace = v, configuration, Settings.OutputNamespaceKey);
            this.SetFromConfiguration((v) => settings.SourceNodeBaseType = v, configuration, Settings.SourceNodeBaseTypeKey);
            this.SetFromConfiguration((v) => settings.TrackingCollectionType = v, configuration, Settings.TrackingCollectionTypeKey);
            this.SetFromConfiguration((v) => settings.DestinationNodeBaseType = v, configuration, Settings.DestinationNodeBaseTypeKey);
            this.SetFromConfiguration((v) => settings.TypesToSkip = v.Split(';'), configuration, Settings.TypesToSkipKey);

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
