using Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Parser.PartParsers
{
    public class PartParserBase<T> : IPartParser<T>
    {
        protected Action<T> PartSetter { get; set; }

        public PartParserBase(Action<T> partSetter)
        {
            this.PartSetter = partSetter;
        }

        public PartParserResult Parse(string token)
        {
            throw new NotImplementedException();
        }


    }
}
