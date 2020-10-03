using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.PreprocessorParts.ParametersCreation
{
    public class InheritanceModel
    {
        public Dictionary<string, InheritanceModelDeclaration> Declarations = new Dictionary<string, InheritanceModelDeclaration>();

        public HashSet<Declaration> CollapsedToEmptyInterface = new HashSet<Declaration>();

        public HashSet<Declaration> CollapsedToInterface = new HashSet<Declaration>();

        public HashSet<Declaration> RepresentedAsInterface = new HashSet<Declaration>();

        public bool InheritanceExists(Declaration baseDeclaration, Declaration inheritingDeclaration)
        {
            if (this.Declarations.ContainsKey(inheritingDeclaration.GetName()))
            {
                var inheritance = this.Declarations[inheritingDeclaration.GetName()];

                return inheritance.BaseDeclaration == baseDeclaration
                    || inheritance.ImplementedInterfaces.Contains(baseDeclaration)
                    || (inheritance.BaseDeclaration != null && this.InheritanceExists(baseDeclaration, inheritance.BaseDeclaration));                    
            }

            return false;
        }
    }
}
