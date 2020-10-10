using ForgedOnce.Core;
using ForgedOnce.Core.Interfaces;
using ForgedOnce.Core.Metadata.Interfaces;
using ForgedOnce.Core.Plugins;
using ForgedOnce.CSharp;
using ForgedOnce.TypeScript;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using ForgedOnce.TsLanguageServices.Model.TypeData;
using ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree;
using ForgedOnce.CSharp.Helpers.SemanticAnalysis;
using ForgedOnce.TsLanguageServices.AstGeneratorPlugin.Emitters;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin
{
    public class Plugin : CodeGenerationFromCSharpPlugin<Settings, Parameters>
    {
        public const string CsTransportModelsOutStreamName = "CsTransportModels";

        public const string CsModelBuildersOutStreamName = "CsModelBuilders";

        public const string TsModelsOutStreamName = "TsModels";

        protected ICodeStream csTransportModelsOutputStream;

        protected ICodeStream csModelBuildersOutputStream;

        protected ICodeStream tsModelsOutputStream;

        protected bool hasExecuted;

        public Plugin()
        {
            this.Signature = new PluginSignature()
            {
                Id = "B485F28E-97B9-488C-944D-4A93DA2C0CD3",
                InputLanguage = Languages.CSharp,
                Name = typeof(Plugin).FullName
            };
        }

        protected override List<ICodeStream> CreateOutputs(ICodeStreamFactory codeStreamFactory)
        {
            List<ICodeStream> result = new List<ICodeStream>();
            this.csTransportModelsOutputStream = codeStreamFactory.CreateCodeStream(Languages.CSharp, CsTransportModelsOutStreamName);
            result.Add(this.csTransportModelsOutputStream);

            this.csModelBuildersOutputStream = codeStreamFactory.CreateCodeStream(Languages.CSharp, CsModelBuildersOutStreamName);
            result.Add(this.csModelBuildersOutputStream);

            this.tsModelsOutputStream = codeStreamFactory.CreateCodeStream(Languages.LimitedTypeScript, TsModelsOutStreamName);
            result.Add(this.tsModelsOutputStream);
            return result;
        }

        protected override void Implementation(CodeFileCSharp input, Parameters parameters, IMetadataRecorder metadataRecorder, ILogger logger)
        {
            if (!this.hasExecuted)
            {
                var csTransportModelEmitter = new CsTransportModelEmitter(this.Settings);
                csTransportModelEmitter.Emit(parameters, this.csTransportModelsOutputStream);

                this.hasExecuted = true;
            }
        }
    }
}
