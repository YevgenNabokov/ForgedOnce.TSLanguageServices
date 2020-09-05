using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel
{
    public class TransportModel
    {
        public Dictionary<string, TransportModelEntity> TransportModelEntities = new Dictionary<string, TransportModelEntity>();

        public Dictionary<string, TransportModelInterface> TransportModelInterfaces = new Dictionary<string, TransportModelInterface>();

        public Dictionary<string, TransportModelEnum> TransportModelEnums = new Dictionary<string, TransportModelEnum>();
    }
}
