using Game08.Sdk.CodeMixer.Core.Interfaces;
using Game08.Sdk.CodeMixer.Core.Plugins;
using Game08.Sdk.CodeMixer.CSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.BuilderExtensionsPlugin
{
    public class Preprocessor : IPluginPreprocessor<CodeFileCSharp, Parameters>
    {
        public Parameters GenerateMetadata(CodeFileCSharp input, IMetadataReader metadataReader, ILogger logger, IFileGroup<CodeFileCSharp, GroupItemDetails> fileGroup = null)
        {


            return new Parameters();
        }
    }
}
