﻿using ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel;
using ForgedOnce.TsLanguageServices.Host.Commands;
using ForgedOnce.TsLanguageServices.Host.Interfaces;
using ForgedOnce.TsLanguageServices.Host.Models;
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
    public class TsHost : ITsHost, IDisposable
    {
        protected readonly Dictionary<OSPlatform, string> NodeExecutableNames = new Dictionary<OSPlatform, string>()
        {
            { OSPlatform.Windows, "node.exe" },
            { OSPlatform.OSX, "node" },
            { OSPlatform.Linux, "node" },
        };

        private readonly string TaskJsFileName = "foTsHostLauncher.js";

        private readonly string CodeGeneratorJsAppFolder = "CodeGeneratorJs";
        private readonly int minPortNumber;
        private readonly int maxPortNumber;
        private readonly int hostStartTimeoutMs;
        private readonly ITsHostLogger logger;
        private bool disposed = false;
        private Process hostProcess;
        private HttpClient hostClient;

        public TsHost(int minPortNumber, int maxPortNumber, int hostStartTimeoutMs, ITsHostLogger logger = null)
        {
            this.minPortNumber = minPortNumber;
            this.maxPortNumber = maxPortNumber;
            this.hostStartTimeoutMs = hostStartTimeoutMs;
            this.logger = logger;
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
            var arguments = this.PrepareArgumentString(port);
            this.hostProcess = Process.Start(this.NodeExecutablePath, arguments);

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

        public TsFile ReadFile(string filePath)
        {
            var command = new ReadFileCommand()
            {
                FilePath = filePath
            };

            var response = this.ExecuteCommand(command);

            var result = JsonConvert.DeserializeObject<ReadFileCommandResult>(response);

            List<IStatement> ast = JsonConvert.DeserializeObject<List<IStatement>>(result.AstPayload, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
                MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead
            });

            return new TsFile()
            {
                FileName = result.FileName,
                Statements = ast,
                Path = filePath
            };
        }

        public IStatement[] Parse(string payload, ScriptKind scriptKind)
        {
            var command = new ParseCommand()
            {
                Payload = payload,
                ScriptKind = scriptKind
            };

            var response = this.ExecuteCommand(command);

            var result = JsonConvert.DeserializeObject<ParseCommandResult>(response);

            List<IStatement> ast = JsonConvert.DeserializeObject<List<IStatement>>(result.AstPayload, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
                MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead
            });

            return ast.ToArray();
        }

        public void WriteFile(TsFile file)
        {
            var astPayload = JsonConvert.SerializeObject(file.Statements.ToArray());

            var command = new WriteFileCommand()
            {
                AstPayload = astPayload,
                FileName = file.FileName,
                Path = file.Path
            };

            this.ExecuteCommand(command);
        }

        public string Print(IStatement[] statements, ScriptKind scriptKind)
        {
            var astPayload = JsonConvert.SerializeObject(statements);

            var command = new PrintCommand()
            {
                AstPayload = astPayload,
                ScriptKind = scriptKind
            };

            var response = this.ExecuteCommand(command);

            var result = JsonConvert.DeserializeObject<PrintCommandResult>(response);

            return result.Payload;
        }

        public void Ping()
        {
            var command = new PingCommand();
            this.ExecuteCommand(command);
        }

        public bool IsAlive()
        {
            try
            {
                this.Ping();
                return true;
            }
            catch
            {
                return false;
            }
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

            this.LogCommand(payload);

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
            return $"\"{TaskJsFilePath}\" {port} > app_log.log 2> app_err.log";
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

        private void LogCommand(string payload)
        {
            if (this.logger != null)
            {
                this.logger.WriteLog(
                    LogMessageSeverity.Debug,
$@"------------------------------------- TS Host Command Payload Begin -----------------------------------------------
{payload}
------------------------------------- TS Host Command Payload End -------------------------------------------------");
            }
        }
    }
}
