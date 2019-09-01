using Game08.Sdk.LTS.Model.TypeData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model
{    
    public class CodeGenerationTask
    {
        public List<CodeFile> Files;

        public TypeCache Types;

        public CodeGenerationTask()
        {
            this.Files = new List<CodeFile>();
        }
    }
}
