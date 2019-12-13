using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static class ExpressionIdentifierReferenceExtensions
    {
        public static ExpressionIdentifierReference WithName(this ExpressionIdentifierReference expressionIdentifierReference, string name)
        {
            expressionIdentifierReference.Name = new Identifier() { Name = name };
            return expressionIdentifierReference;
        }
    }
}
