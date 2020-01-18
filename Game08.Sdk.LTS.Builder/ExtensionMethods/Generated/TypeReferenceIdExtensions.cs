using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class TypeReferenceIdExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId WithReferenceKey(this Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId subject, string referenceKey)
        {
            subject.ReferenceKey = referenceKey;
            return subject;
        }
    }
}