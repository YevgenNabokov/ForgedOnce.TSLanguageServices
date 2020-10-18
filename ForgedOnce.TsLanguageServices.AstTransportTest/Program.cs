using ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ForgedOnce.TsLanguageServices.AstTransportTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var payload = File.ReadAllText(args[0]);

            List<IStatement> ast = JsonConvert.DeserializeObject<List<IStatement>>(payload, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
                MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead
            });

            var newPayload = JsonConvert.SerializeObject(ast);

            File.WriteAllText(args[1], newPayload);
        }

        private class Wrapper
        {
            public List<IStatement> statements { get; set; }
        }
    }
}
