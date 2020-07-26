﻿using ForgedOnce.Core.Interfaces;
using ForgedOnce.Core.Plugins;
using ForgedOnce.CSharp;
using ForgedOnce.TsLanguageServices.AstDescription.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin
{
    public class Preprocessor : IPluginPreprocessor<CodeFileCSharp, Parameters, Settings>
    {
        public Parameters GenerateParameters(CodeFileCSharp input, Settings pluginSettings, IMetadataReader metadataReader, ILogger logger, IFileGroup<CodeFileCSharp, GroupItemDetails> fileGroup = null)
        {
            if (string.IsNullOrEmpty(pluginSettings.AstDescriptionJsonFilePath))
            {
                throw new InvalidOperationException($"Setting {Settings.AstDescriptionJsonFilePathKey} should be provided.");
            }

            var path = pluginSettings.AstDescriptionJsonFilePath;

            if (!Path.IsPathRooted(pluginSettings.AstDescriptionJsonFilePath))
            {
                path = Path.Combine(pluginSettings.BasePath, pluginSettings.AstDescriptionJsonFilePath);
            }

            var description = JsonConvert.DeserializeObject<Root>(File.ReadAllText(path));

            return new Parameters();
        }
    }
}
