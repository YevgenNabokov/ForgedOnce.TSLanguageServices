using Game08.Sdk.CSToTS.IntermediateModel.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel
{
    public class CodeFile
    {
        public string FileName;

        public bool IsDefinitionFile;

        public FileRoot RootNode;
    }
}
