using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.ModelTsInterfacesPlugin
{
    public class Settings
    {
        public const string ModelBaseNamespaceKey = "modelBaseNamespace";

        public const string SkipUnmappedTypeReferencesKey = "skipUnmappedTypeReferences";

        public const string OutputFileNameKey = "outputFileName";

        public string ModelBaseNamespace;

        public bool SkipUnmappedTypeReferences;

        public string OutputFileName;
    }
}
