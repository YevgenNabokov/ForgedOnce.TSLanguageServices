using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel
{
    public class TransportModelEnum
    {
        public string Name;

        public Dictionary<string, TransportModelEnumMember> Members = new Dictionary<string, TransportModelEnumMember>();
    }
}
