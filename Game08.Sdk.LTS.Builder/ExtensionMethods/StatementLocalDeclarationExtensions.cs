using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static class StatementLocalDeclarationExtensions
    {
        public static StatementLocalDeclaration WithName(this StatementLocalDeclaration statementLocalDeclaration, string name)
        {
            statementLocalDeclaration.Name = new Identifier() { Name = name };
            return statementLocalDeclaration;
        }

        public static StatementLocalDeclaration WithType(this StatementLocalDeclaration statementLocalDeclaration, string typeReferenceKey)
        {
            statementLocalDeclaration.TypeReference = new TypeReferenceId() { ReferenceKey = typeReferenceKey };
            return statementLocalDeclaration;
        }

        public static StatementLocalDeclaration WithInitializer(this StatementLocalDeclaration statementLocalDeclaration, ExpressionNode expression)
        {
            statementLocalDeclaration.Initializer = expression;
            return statementLocalDeclaration;
        }
    }
}
