using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin
{
    public class Settings
    {
        public const string AstDescriptionJsonFilePathKey = "astDescriptionJsonFilePath";

        public const string AstNodeBaseTypeQualifiedKey = "astNodeBaseTypeQualified";

        public string AstDescriptionJsonFilePath;

        public string AstNodeBaseTypeQualified;

        public string BasePath;
    }
}
