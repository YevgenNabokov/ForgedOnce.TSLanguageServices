using ForgedOnce.TsLanguageServices.AstDescription.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.PreprocessorParts.ParametersCreation
{
    public class InheritanceModelDeclaration
    {
        public Declaration OriginalDeclaration;

        public Declaration BaseDeclaration;

        public List<Declaration> ImplementedInterfaces = new List<Declaration>();

        public List<TypeElement> AdditionalElements = new List<TypeElement>();

        public bool RepresentedAsInterface;
    }
}
