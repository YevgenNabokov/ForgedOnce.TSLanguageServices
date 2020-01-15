﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.BuilderDefinitionTreePlugin
{
    public class Settings
    {
        public const string OutputNamespaceKey = "outputNamespace";

        public const string SourceNodeBaseTypeKey = "sourceNodeBaseType";

        public const string TrackingCollectionTypeKey = "trackingCollectionType";

        public const string DestinationNodeBaseTypeKey = "destinationNodeBaseType";

        public const string TypesToSkipKey = "typesToSkip";

        public string OutputNamespace;

        public string SourceNodeBaseType;

        public string TrackingCollectionType;

        public string DestinationNodeBaseType;

        public string[] TypesToSkip;
    }
}
