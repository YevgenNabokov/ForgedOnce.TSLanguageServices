using System;

namespace ForgedOnce.TsLanguageServices.SyntaxTreeExtensionsPlugin
{
    public class Settings
    {
        public const string OutputNamespaceKey = "outputNamespace";

        public const string RequiredClassBaseTypeKey = "requiredClassBaseType";

        public const string TypesToUnfoldKey = "typesToUnfold";

        public const string IgnorePropertyNamesKey = "ignorePropertyNames";

        public const string UnpluralizeVariablesKey = "unpluralizeVariables";

        public string OutputNamespace;

        public string RequiredClassBaseType;

        public string[] TypesToUnfold;

        public string[] IgnorePropertyNames;

        public bool UnpluralizeVariables;
    }
}
