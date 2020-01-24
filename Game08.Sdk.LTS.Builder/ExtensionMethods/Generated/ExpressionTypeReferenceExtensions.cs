using System;
using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class ExpressionTypeReferenceExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionTypeReference WithTypeId(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionTypeReference subject, string referenceKey)
        {
            subject.TypeId = new Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey};
            return subject;
        }
    }
}