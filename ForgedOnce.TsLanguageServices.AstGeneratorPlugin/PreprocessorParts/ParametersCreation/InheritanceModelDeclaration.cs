using ForgedOnce.TsLanguageServices.AstDescription.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.PreprocessorParts.ParametersCreation
{
    public class InheritanceModelDeclaration
    {


        public Declaration OriginalDeclaration;

        public Declaration BaseDeclaration
        {
            get => baseDeclaration;
            set 
            {
                baseDeclaration = value;
            }
        }

        public List<Declaration> ImplementedInterfaces = new List<Declaration>();

        public List<Declaration> MergedDeclarations = new List<Declaration>();

        public bool RepresentedAsInterface;

        public bool CollapsedToInterface;

        public bool CollapsedToEmptyInterface;
        private Declaration baseDeclaration;
    }
}
