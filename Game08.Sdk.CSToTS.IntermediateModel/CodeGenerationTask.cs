using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel
{    
    public class CodeGenerationTask
    {
        public List<CodeFile> Files;

        public CodeGenerationTask()
        {
            this.Files = new List<CodeFile>();
        }
    }
}
