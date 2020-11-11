using ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel;
using ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            ModelConverter converter = new ModelConverter();

            var builderAst = ast.Select(n => converter.ConvertFromNode(n)).ToArray();

            var rAst = builderAst.Select(n => (IStatement)n.GetTransportModelNode()).ToArray();

            var newPayload = JsonConvert.SerializeObject(rAst);

            File.WriteAllText(args[1], newPayload);
        }

        private class Wrapper
        {
            public List<IStatement> statements { get; set; }
        }
    }
}
