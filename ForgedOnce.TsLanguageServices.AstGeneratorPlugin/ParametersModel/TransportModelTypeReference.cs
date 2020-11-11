using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel
{
    public abstract class TransportModelTypeReference
    {
        public bool IsCollection { get; set; }

        public abstract TransportModelTypeReference Clone();
    }
}
