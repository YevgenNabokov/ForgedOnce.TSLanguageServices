﻿using ForgedOnce.Core.Interfaces;
using ForgedOnce.Core.Plugins;
using ForgedOnce.CSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.ModelTsInterfacesPlugin
{
    public class Preprocessor : IPluginPreprocessor<CodeFileCSharp, Parameters, Settings>
    {
        public Parameters GenerateParameters(CodeFileCSharp input, Settings pluginSettings, IMetadataReader metadataReader, ILogger logger, IFileGroup<CodeFileCSharp, GroupItemDetails> fileGroup = null)
        {
            return new Parameters();
        }
    }
}
