using Game08.Sdk.CodeMixer.Core.Interfaces;
using Game08.Sdk.CodeMixer.CSharp;
using Game08.Sdk.CodeMixer.Environment.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.BuilderExtensionsPlugin
{
    public class PluginFactory : ICodeGenerationPluginFactory<Settings, Parameters, CodeFileCSharp>
    {
        public ICodeGenerationPlugin CreatePlugin(JObject configuration, IPluginPreprocessor<CodeFileCSharp, Parameters, Settings> pluginPreprocessor = null)
        {
            Settings settings = new Settings();
            this.SetFromConfiguration((v) => settings.OutputNamespace = v, configuration, Settings.OutputNamespaceKey);
            this.SetFromConfiguration((v) => settings.RequiredClassBaseType = v, configuration, Settings.RequiredClassBaseTypeKey);
            this.SetFromConfiguration((v) => settings.TypesToUnfold = v.Split(';'), configuration, Settings.TypesToUnfoldKey);
            this.SetFromConfiguration((v) => settings.IgnorePropertyNames = v.Split(';'), configuration, Settings.IgnorePropertyNamesKey);
            this.SetFromConfiguration((v) => bool.TryParse(v, out settings.UnpluralizeVariables), configuration, Settings.UnpluralizeVariablesKey);

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
