using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace Game08.Sdk.CSToTS.NodeTaskWrapper
{
    public class GenerateCodeTask
    {
        private readonly string NodeRedistFolder = "NodeRedist";

        private readonly string PlatformNameFolder = "win-x64";

        private readonly string NodeFileName = "Node.exe";

        private readonly string TaskJsFileName = "generationLauncher.js";

        private string generationDataJsonPath;

        private string outputFolder;

        private string outputMetadataJsonPath;

        public GenerateCodeTask(string generationDataJsonPath, string outputFolder, string outputMetadataJsonPath)
        {
            this.generationDataJsonPath = generationDataJsonPath;
            this.outputFolder = outputFolder;
            this.outputMetadataJsonPath = outputMetadataJsonPath;
        }

        private string NodeExecutablePath
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), NodeRedistFolder, PlatformNameFolder, NodeFileName);
            }
        }

        private string TaskJsFilePath
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..\\..\\..\\..\\Game08.Sdk.CSToTS.TypeScriptBuilder", TaskJsFileName);
            }
        }

        public void Execute()
        {
            var process = Process.Start(this.NodeExecutablePath, this.PrepareArgumentString());

            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                throw new InvalidOperationException($"Code generation process exited with code {process.ExitCode}.");
            }
        }

        private string PrepareArgumentString()
        {
            return $"{TaskJsFilePath} {this.generationDataJsonPath} {this.outputFolder} {this.outputMetadataJsonPath}";
        }
    }
}
