using ForgedOnce.TsLanguageServices.AstDescription.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.PreprocessorParts
{
    public class AstDescription
    {
        public Dictionary<string, Declaration> AstDeclarations;

        public Dictionary<string, Declaration> ReferredDeclarations;

        public Dictionary<string, HashSet<TypeReference>> UnresolvedReferences;
    }
}
