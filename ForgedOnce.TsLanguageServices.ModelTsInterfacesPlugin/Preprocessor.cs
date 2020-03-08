using ForgedOnce.TsLanguageServices.CodeMixer.Core.Interfaces;
using ForgedOnce.TsLanguageServices.CodeMixer.Core.Plugins;
using ForgedOnce.TsLanguageServices.CodeMixer.CSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.LTS.ModelTsInterfacesPlugin
{
    public class Preprocessor : IPluginPreprocessor<CodeFileCSharp, Parameters, Settings>
    {
        public Parameters GenerateMetadata(CodeFileCSharp input, Settings pluginSettings, IMetadataReader metadataReader, ILogger logger, IFileGroup<CodeFileCSharp, GroupItemDetails> fileGroup = null)
        {
            return new Parameters();
        }
    }
}
