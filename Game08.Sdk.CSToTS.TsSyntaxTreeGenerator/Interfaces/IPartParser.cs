using Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Interfaces
{
    public interface IPartParser<T>
    {
        T Parse(ParserState state);
    }
}
