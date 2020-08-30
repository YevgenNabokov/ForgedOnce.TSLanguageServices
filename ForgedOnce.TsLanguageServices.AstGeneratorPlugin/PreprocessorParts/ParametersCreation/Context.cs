using Description = ForgedOnce.TsLanguageServices.AstDescription.Model;
using ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.PreprocessorParts.ParametersCreation
{
    public class Context
    {
        public Dictionary<string, TransportModelItem> TransportModelItems = new Dictionary<string, TransportModelItem>();

        public Dictionary<Description.TypeReference, TransportModelItem> ReferencesMappedToEntities = new Dictionary<Description.TypeReference, TransportModelItem>();
    }
}
