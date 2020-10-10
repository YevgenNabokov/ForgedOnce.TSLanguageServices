using ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.Emitters
{
    public class EmitterHelper
    {
        public static string GetCSharpTransportModelFullyQualifiedName(TransportModelItem item, Settings settings)
        {
            return $"{settings.CsTransportModelNamespace}.{GetCSharpTransportModelShortName(item)}";
        }

        public static string GetCSharpTransportModelShortName(TransportModelItem item)
        {
            if (item is TransportModelInterface)
            {
                return $"I{item.Name}";
            }

            return item.Name;
        }
    }
}
