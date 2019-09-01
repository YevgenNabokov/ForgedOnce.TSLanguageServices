using Game08.Sdk.CSToTS.IntermediateModel;
using Game08.Sdk.CSToTS.IntermediateModel.ResultModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Game08.Sdk.LTS.ModelToCode
{
    public class Launcher
    {
        private string outputFolder;

        public Launcher(string outputFolder)
        {            
            this.outputFolder = outputFolder;            
        }

        private string GetModelFilePath()
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "CodeGenerationTask.json");
        }

        private string GetOutputMetadataPath()
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "CodeGenerationOutput.json");
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
