using Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model
{
    public class TypeDeclaration : INamed, IHaveModifiers
    {
        public Modifier[] Modifiers { get; set; }

        public TypeNameDeclaration Name { get; set; }

        public Expression Constraint { get; set; }

        public string GetName()
        {
            return this.Name?.Name;
        }
    }
}
