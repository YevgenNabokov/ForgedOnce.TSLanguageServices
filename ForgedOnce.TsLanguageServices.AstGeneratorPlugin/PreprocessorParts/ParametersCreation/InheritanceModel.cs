using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.PreprocessorParts.ParametersCreation
{
    public class InheritanceModel
    {
        public Dictionary<string, InheritanceModelDeclaration> Declarations = new Dictionary<string, InheritanceModelDeclaration>();

        public HashSet<Declaration> CollapsedToEmptyInterface = new HashSet<Declaration>();

        public HashSet<Declaration> CollapsedToInterface = new HashSet<Declaration>();

        public HashSet<Declaration> RepresentedAsInterface = new HashSet<Declaration>();
    }
}
