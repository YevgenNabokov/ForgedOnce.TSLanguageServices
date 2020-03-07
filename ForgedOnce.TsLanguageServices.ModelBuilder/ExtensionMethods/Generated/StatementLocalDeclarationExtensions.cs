using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class StatementLocalDeclarationExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementLocalDeclaration WithTypeReference(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementLocalDeclaration subject, string referenceKey)
        {
            subject.TypeReference = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey};
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementLocalDeclaration WithName(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementLocalDeclaration subject, string name)
        {
            subject.Name = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementLocalDeclaration WithInitializer(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementLocalDeclaration subject, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode initializer)
        {
            subject.Initializer = initializer;
            return subject;
        }
    }
}