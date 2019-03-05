using Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.ModelRefiner;
using Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Parser;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            ////TestTokenAggregator(args[0], args[1]);
            ////TestModelParser(args[0]);
            TestModelFilter(args[0]);
        }

        static void TestModelFilter(string inputFile)
        {
            var content = File.ReadAllText(inputFile);

            TsParser parser = new TsParser();

            HashSet<string> skipDefinitions = new HashSet<string>()
            {
                "EmitHelper", "SymbolTracker", "PragmaPseudoMapEntry"
            };

            var model = parser.Parse(content, skipDefinitions);

            ModelFilter filter = new ModelFilter();

            var depth = filter.DeepestPath(model);
        }

        static void TestModelParser(string inputFile)
        {
            var content = File.ReadAllText(inputFile);

            TsParser parser = new TsParser();

            HashSet<string> skipDefinitions = new HashSet<string>()
            {
                "EmitHelper", "SymbolTracker", "PragmaPseudoMapEntry"
            };

            var result = parser.Parse(content, skipDefinitions);
        }

        static void TestTokenAggregator(string inputFile, string outputFile)
        {
            using (var outStream = File.OpenWrite(outputFile))
            {
                using (var writer = new StreamWriter(outStream))
                {
                    writer.AutoFlush = true;
                    using (var reader = File.OpenText(inputFile))
                    {
                        var bufferSize = 256;
                        char[] buffer = new char[bufferSize];

                        var readCount = reader.Read(buffer, 0, bufferSize);

                        TokenAggregator aggregator = new TokenAggregator();
                        Token[] parsingResult = null;

                        while (readCount > 0)
                        {
                            for (var i = 0; i < readCount; i++)
                            {
                                parsingResult = aggregator.Add(buffer[i]);
                                if (parsingResult != null)
                                {
                                    foreach (var token in parsingResult)
                                    {
                                        writer.Write(token);
                                    }
                                }
                            }

                            readCount = reader.Read(buffer, 0, bufferSize);
                        }
                    }
                }
            }
        }
    }
}
