using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class TypeDeclaration
    {
        public Modifier[] Modifiers { get; set; }

        public TypeNameDeclaration Name { get; set; }

        public Expression Constraint { get; set; }
    }
}
