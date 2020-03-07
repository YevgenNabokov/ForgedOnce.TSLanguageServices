using ForgedOnce.TsLanguageServices.Model.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model
{
    public class CodeFile
    {
        public string FileName;

        public bool IsDefinitionFile;

        public FileRoot RootNode;
    }
}
