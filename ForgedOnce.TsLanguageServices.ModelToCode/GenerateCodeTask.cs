using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace ForgedOnce.TsLanguageServices.ModelToCode
{
    public class GenerateCodeTask
    {
        protected readonly Dictionary<OSPlatform, string> NodeExecutableNames = new Dictionary<OSPlatform, string>()
        {
            { OSPlatform.Windows, "node.exe" },
            { OSPlatform.OSX, "node" },
            { OSPlatform.Linux, "node" },
        };

        private readonly string TaskJsFileName = "generationLauncher.js";

        private readonly string CodeGeneratorJsAppFolder = "CodeGeneratorJs";

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
                foreach (var os in this.NodeExecutableNames)
                {
                    if (RuntimeInformation.IsOSPlatform(os.Key))
                    {
                        return os.Value;
                    }
                }

                throw new InvalidOperationException($"OS platform was not recognized as one of: {nameof(OSPlatform.Windows)}, {nameof(OSPlatform.OSX)}, {nameof(OSPlatform.Linux)}");
            }
        }

        private string TaskJsFilePath
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), CodeGeneratorJsAppFolder, TaskJsFileName);
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
            return $"{TaskJsFilePath} {this.generationDataJsonPath} {this.outputFolder} {this.outputMetadataJsonPath} > app_log.log 2> app_err.log";
        }
    }
}
