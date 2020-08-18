using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin
{
    public class Settings
    {
        public const string AstDescriptionJsonFilePathKey = "astDescriptionJsonFilePath";

        public const string AstNodeBaseTypeQualifiedKey = "astNodeBaseTypeQualified";

        public const string ExcludedAstNodesKey = "excludedAstNodes";

        public string AstDescriptionJsonFilePath;

        public string AstNodeBaseTypeQualified;

        public string ExcludedAstNodes = "ts.TransientIdentifier";

        public string BasePath;
    }
}
