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
using ForgedOnce.CSharp.Helpers.SemanticAnalysis;
using ForgedOnce.TsLanguageServices.AstGeneratorPlugin.Emitters;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin
{
    public class Plugin : CodeGenerationFromCSharpPlugin<Settings, Parameters>
    {
        public const string CsTransportModelsOutStreamName = "CsTransportModels";

        public const string CsAstModelOutStreamName = "CsAstModels";

        public const string CsModelBuildersOutStreamName = "CsModelBuilders";

        public const string CsTransportToAstConverterOutputStreamName = "CsTransportToAstConverter";

        public const string TsModelsOutStreamName = "TsModels";

        protected ICodeStream csAstModelsOutputStream;

        protected ICodeStream csTransportModelsOutputStream;

        protected ICodeStream csModelBuildersOutputStream;

        protected ICodeStream csTransportToAstConverterOutputStream;

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

            this.csAstModelsOutputStream = codeStreamFactory.CreateCodeStream(Languages.CSharp, CsAstModelOutStreamName);
            result.Add(this.csAstModelsOutputStream);

            this.csModelBuildersOutputStream = codeStreamFactory.CreateCodeStream(Languages.CSharp, CsModelBuildersOutStreamName);
            result.Add(this.csModelBuildersOutputStream);

            this.csTransportToAstConverterOutputStream = codeStreamFactory.CreateCodeStream(Languages.CSharp, CsTransportToAstConverterOutputStreamName);
            result.Add(this.csTransportToAstConverterOutputStream);

            this.tsModelsOutputStream = codeStreamFactory.CreateCodeStream(Languages.TypeScript, TsModelsOutStreamName);
            result.Add(this.tsModelsOutputStream);
            return result;
        }

        protected override void Implementation(CodeFileCSharp input, Parameters parameters, IMetadataRecorder metadataRecorder, ILogger logger)
        {
            if (!this.hasExecuted)
            {
                var csTransportModelEmitter = new CsTransportModelEmitter(this.Settings);
                csTransportModelEmitter.Emit(parameters, this.csTransportModelsOutputStream);

                var csAstEmitter = new CsAstModelEmitter(this.Settings);
                csAstEmitter.Emit(parameters, this.csAstModelsOutputStream);

                var csTransportToAstTranslatorEmitter = new CsTransportToAstTranslatorEmitter(this.Settings);
                csTransportToAstTranslatorEmitter.Emit(parameters, this.csTransportToAstConverterOutputStream);

                var tsAstToTransportTranslatorEmitter = new TsAstToTransportTranslatorEmitter(this.Settings);
                tsAstToTransportTranslatorEmitter.Emit(parameters, this.tsModelsOutputStream);

                var tsTransportToAstTranslatorEmitter = new TsTransportToAstTranslatorEmitter(this.Settings);
                tsTransportToAstTranslatorEmitter.Emit(parameters, this.tsModelsOutputStream);

                this.hasExecuted = true;
            }
        }
    }
}
