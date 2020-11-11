using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel
{
    public class TransportModelFunctionBinding
    {
        public string Name;

        public List<TransportModelFunctionParameterBinding> Parameters = new List<TransportModelFunctionParameterBinding>();
    }
}
