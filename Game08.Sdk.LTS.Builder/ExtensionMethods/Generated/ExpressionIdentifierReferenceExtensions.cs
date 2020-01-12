using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class ExpressionIdentifierReferenceExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionIdentifierReference WithName(this Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionIdentifierReference subject, string name)
        {
            subject.Name = new Game08.Sdk.LTS.Builder.DefinitionTree.Identifier{Name = name};
            return subject;
        }
    }
}