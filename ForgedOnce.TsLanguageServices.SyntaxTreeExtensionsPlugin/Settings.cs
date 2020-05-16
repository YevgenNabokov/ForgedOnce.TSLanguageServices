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

        /// <summary>
        /// Output namespace for the extensions.
        /// </summary>
        public string OutputNamespace;

        /// <summary>
        /// Fully qualified .NET type that is required for input class to be or inherit or implement as interface.
        /// </summary>
        public string RequiredClassBaseType;

        /// <summary>
        /// Fully qualified .NET types that will be inlined in extension methods. No extensions are generated for those if encountreed in the input.
        /// </summary>
        public string[] TypesToUnfold;

        /// <summary>
        /// List of property names for which no extension methods will be generated.
        /// </summary>
        public string[] IgnorePropertyNames;

        /// <summary>
        /// Allows to unpluralize plural names for collection-like properties in extension methods that will add single item.
        /// </summary>
        public bool UnpluralizeVariables;
    }
}
