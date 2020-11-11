using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel
{
    public class TransportModelEnum : TransportModelItem
    {
        public Dictionary<string, TransportModelEnumMember> Members = new Dictionary<string, TransportModelEnumMember>();

        public bool IsFlags;
    }
}
