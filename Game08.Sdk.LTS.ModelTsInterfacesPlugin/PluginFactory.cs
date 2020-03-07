﻿using Game08.Sdk.CodeMixer.Core.Interfaces;
using Game08.Sdk.CodeMixer.CSharp;
using Game08.Sdk.CodeMixer.Environment.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.ModelTsInterfacesPlugin
{
    public class PluginFactory : ICodeGenerationPluginFactory<Settings, Parameters, CodeFileCSharp>
    {
        public ICodeGenerationPlugin CreatePlugin(JObject configuration, IPluginPreprocessor<CodeFileCSharp, Parameters, Settings> pluginPreprocessor = null)
        {
            Settings settings = new Settings();
            this.SetFromConfiguration((v) => settings.ModelBaseNamespace = v, configuration, Settings.ModelBaseNamespaceKey);
            this.SetFromConfiguration((v) => bool.TryParse(v, out settings.SkipUnmappedTypeReferences), configuration, Settings.SkipUnmappedTypeReferencesKey);
            this.SetFromConfiguration((v) => settings.OutputFileName = v, configuration, Settings.OutputFileNameKey);

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