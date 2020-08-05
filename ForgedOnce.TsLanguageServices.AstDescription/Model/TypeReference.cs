using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstDescription.Model
{
    public class TypeReference
    {
        public TypeReferenceNamed Named;

        public TypeReferenceIntersection Intersection;

        public TypeReferenceUnion Union;

        public TypeReferenceLiteral Literal;

        public TypeReferenceParenthesized Parenthesized;

        public TypeReferenceArray Array;

        public TypeReferenceTuple Tuple;

        public TypeReferenceLiteralType LiteralType;

        public TypeReferenceIndexedAccess IndexedAccess;

        public TypeReferencePredicate Predicate;

        public bool? NotSupported;

        public bool Readonly;
    }
}
