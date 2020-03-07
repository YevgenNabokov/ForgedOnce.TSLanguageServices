using ForgedOnce.TsLanguageServices.Model;
using ForgedOnce.TsLanguageServices.Model.ResultModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ForgedOnce.TsLanguageServices.ModelToCode
{
    public class Launcher
    {
        private readonly string modelFileName = "CodeGenerationTask.json";

        private readonly string outputMetadataFileName = "CodeGenerationOutput.json";

        private string outputFolder;
        private readonly string tempFolder;

        public Launcher(string outputFolder, string tempFolder = null)
        {            
            this.outputFolder = outputFolder;
            this.tempFolder = tempFolder;
        }

        private string GetModelFilePath()
        {
            if (!string.IsNullOrEmpty(this.tempFolder))
            {
                return Path.Combine(this.tempFolder, modelFileName);
            }

            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), modelFileName);
        }

        private string GetOutputMetadataPath()
        {
            if (!string.IsNullOrEmpty(this.tempFolder))
            {
                return Path.Combine(this.tempFolder, outputMetadataFileName);
            }

            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), outputMetadataFileName);
        }

        public CodeGenerationResult Execute(CodeGenerationTask task)
        {
            var modelFilePath = this.GetModelFilePath();

            var outputStatusFilePath = this.GetOutputMetadataPath();

            File.WriteAllText(modelFilePath, JsonConvert.SerializeObject(task));

            GenerateCodeTask generateTask = new GenerateCodeTask(modelFilePath, this.outputFolder, outputStatusFilePath);

            generateTask.Execute();

            if (File.Exists(outputStatusFilePath))
            {
                var result = JsonConvert.DeserializeObject<CodeGenerationResult>(File.ReadAllText(outputStatusFilePath));

                return result;
            }

            return null;
        }
    }
}
