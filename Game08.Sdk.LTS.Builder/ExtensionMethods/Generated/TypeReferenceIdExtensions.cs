using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;
using System;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class TypeReferenceIdExtensions
    {
        static Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId WithReferenceKey(this Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId subject, string referenceKey)
        {
            subject.ReferenceKey = referenceKey;
            return subject;
        }
    }
}