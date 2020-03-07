using ForgedOnce.TsLanguageServices.Model.TypeData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model
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
