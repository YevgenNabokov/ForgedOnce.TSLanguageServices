using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class ExpressionNewExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNew WithArgument(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNew subject, Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode argument)
        {
            subject.Arguments.Add(argument);
            return subject;
        }

        public static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNew WithSubjectType(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNew subject, string referenceKey)
        {
            subject.SubjectType = new Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey};
            return subject;
        }
    }
}