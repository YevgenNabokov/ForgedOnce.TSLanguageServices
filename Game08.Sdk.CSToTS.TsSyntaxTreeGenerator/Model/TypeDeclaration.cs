using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class TypeDeclaration
    {
        public TypeNameDeclaration Name { get; set; }

        public TypeConstraint Constraint { get; set; }
    }
}
