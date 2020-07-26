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

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin
{
    public class Plugin : CodeGenerationFromCSharpPlugin<Settings, Parameters>
    {
        public const string CsModelsOutStreamName = "CsModels";

        public const string TsModelsOutStreamName = "TsModels";

        protected ICodeStream csModelsOutputStream;

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
            this.csModelsOutputStream = codeStreamFactory.CreateCodeStream(Languages.CSharp, CsModelsOutStreamName);
            result.Add(this.csModelsOutputStream);

            this.tsModelsOutputStream = codeStreamFactory.CreateCodeStream(Languages.LimitedTypeScript, TsModelsOutStreamName);
            result.Add(this.tsModelsOutputStream);
            return result;
        }

        protected override void Implementation(CodeFileCSharp input, Parameters parameters, IMetadataRecorder metadataRecorder, ILogger logger)
        {
            if (!this.hasExecuted)
            {

                this.hasExecuted = true;
            }
        }
    }
}
