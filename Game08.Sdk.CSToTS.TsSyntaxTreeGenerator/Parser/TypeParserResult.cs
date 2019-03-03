using Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Parser
{
    public class TypeParserResult
    {
        public TypeParserResult()
        {
            this.InlineInterfaces = new List<TsInterface>();
        }

        public Model.TypeDeclaration TypeDeclaration { get; set; }

        public List<TsInterface> InlineInterfaces { get; set; }
    }
}
