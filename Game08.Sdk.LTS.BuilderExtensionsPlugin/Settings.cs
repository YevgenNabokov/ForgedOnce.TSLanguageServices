﻿using System;

namespace Game08.Sdk.LTS.BuilderExtensionsPlugin
{
    public class Settings
    {
        public const string OutputNamespaceKey = "outputNamespace";

        public const string RequiredClassBaseTypeKey = "requiredClassBaseType";

        public const string TypesToFoldKey = "typesToFold";

        public string OutputNamespace;

        public string RequiredClassBaseType;

        public string[] TypesToFold;
    }
}
