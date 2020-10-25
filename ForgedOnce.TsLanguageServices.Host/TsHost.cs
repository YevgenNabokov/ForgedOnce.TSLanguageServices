using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Host
{
    public class TsHost
    {
        protected readonly Dictionary<OSPlatform, string> NodeExecutableNames = new Dictionary<OSPlatform, string>()
        {
            { OSPlatform.Windows, "node.exe" },
            { OSPlatform.OSX, "node" },
            { OSPlatform.Linux, "node" },
        };

        private readonly string TaskJsFileName = "foTsHostLauncher.js";

        private readonly string CodeGeneratorJsAppFolder = "CodeGeneratorJs";
        private readonly string basePath;
        private readonly int minPortNumber;
        private readonly int maxPortNumber;

        public TsHost(string basePath, int minPortNumber, int maxPortNumber)
        {
            this.basePath = basePath;
            this.minPortNumber = minPortNumber;
            this.maxPortNumber = maxPortNumber;
        }

        public void Start()
        {
            throw new NotImplementedException();
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

        private string PrepareArgumentString()
        {
            return $"{TaskJsFilePath} {this.GetFreePort()} {this.basePath} > app_log.log 2> app_err.log";
        }

        private int GetFreePort()
        {
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            var takenPorts = new HashSet<int>(ipGlobalProperties.GetActiveTcpListeners().Where(l => l.Port >= this.minPortNumber && l.Port <= this.maxPortNumber).Select(l => l.Port));
            for (var port = this.minPortNumber; port <= this.maxPortNumber; port++)
            {
                if (!takenPorts.Contains(port))
                {
                    return port;
                }
            }

            throw new InvalidOperationException("Could not start TS language host, no free port available in configured range.");
        }
    }
}
