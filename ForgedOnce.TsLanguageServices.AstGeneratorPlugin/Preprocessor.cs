using ForgedOnce.Core.Interfaces;
using ForgedOnce.Core.Plugins;
using ForgedOnce.CSharp;
using ForgedOnce.TsLanguageServices.AstDescription.Model;
using ForgedOnce.TsLanguageServices.AstGeneratorPlugin.PreprocessorParts;
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

            var payload = File.ReadAllText(path);

            var description = JsonConvert.DeserializeObject<Root>(payload);

            var fixer = new InstanceReferenceFixer();

            description = (Root)fixer.FixInstanceReferences(description);

            var analyzer = new DescriptionAnalyzer(pluginSettings);

            return analyzer.CreateParameters(description);
        }
    }
}
