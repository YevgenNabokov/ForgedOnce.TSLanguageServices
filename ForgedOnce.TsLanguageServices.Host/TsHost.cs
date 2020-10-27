using ForgedOnce.TsLanguageServices.Host.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Host
{
    public class TsHost : IDisposable
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
        private readonly int hostStartTimeoutMs;
        private bool disposed = false;
        private Process hostProcess;
        private HttpClient hostClient;

        public TsHost(string basePath, int minPortNumber, int maxPortNumber, int hostStartTimeoutMs)
        {
            this.basePath = basePath;
            this.minPortNumber = minPortNumber;
            this.maxPortNumber = maxPortNumber;
            this.hostStartTimeoutMs = hostStartTimeoutMs;
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                if (this.hostClient != null)
                {
                    try
                    {
                        this.Shutdown();
                    }
                    catch
                    {
                    }

                    this.hostClient.Dispose();
                }

                if (this.hostProcess != null)
                {
                    this.hostProcess.Close();
                    this.hostProcess.Dispose();
                }
            }

            disposed = true;
        }

        public void Start()
        {
            var port = this.GetFreePort();
            this.hostProcess = Process.Start(this.NodeExecutablePath, this.PrepareArgumentString(port));

            this.hostClient = new HttpClient();
            this.hostClient.BaseAddress = new Uri($"http://localhost:{port}/");
            this.hostClient.DefaultRequestHeaders.Accept.Clear();
            this.hostClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Stopwatch timeoutWatch = new Stopwatch();
            timeoutWatch.Start();

            while (true)
            {
                try
                {
                    this.Ping();
                    break;
                }
                catch
                {
                }

                if (timeoutWatch.ElapsedMilliseconds >= this.hostStartTimeoutMs)
                {
                    throw new InvalidOperationException($"Unable to start TypeScript host within given timeout {this.hostStartTimeoutMs}ms");
                }
            }
        }

        public void Ping()
        {
            var command = new PingCommand();
            this.ExecuteCommand(command);
        }

        private void Shutdown()
        {
            var command = new ShutdownCommand();
            this.ExecuteCommand(command);
        }

        private string ExecuteCommand(Command command)
        {
            if (this.hostClient == null)
            {
                this.Start();
            }

            var payload = JsonConvert.SerializeObject(command);
            var data = new StringContent(payload, Encoding.UTF8, "application/json");

            var response = this.hostClient.PostAsync(string.Empty, data).Result;
            string result = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"TypeScript host returned error:\r\n{result}");
            }

            return result;
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

        private string PrepareArgumentString(int port)
        {
            return $"{TaskJsFilePath} {port} {this.basePath} > app_log.log 2> app_err.log";
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
