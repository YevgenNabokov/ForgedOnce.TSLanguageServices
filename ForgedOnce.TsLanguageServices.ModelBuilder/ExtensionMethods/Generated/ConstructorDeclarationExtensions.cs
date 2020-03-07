using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class ConstructorDeclarationExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ConstructorDeclaration WithModifier(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ConstructorDeclaration subject, ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier modifier)
        {
            subject.Modifiers.Add(modifier);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ConstructorDeclaration WithParameter(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ConstructorDeclaration subject, Func<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodParameter, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodParameter> parameterBuilder)
        {
            subject.Parameters.Add(parameterBuilder(new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodParameter()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ConstructorDeclaration WithBody(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ConstructorDeclaration subject, Func<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementBlock, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementBlock> bodyBuilder)
        {
            subject.Body = bodyBuilder(new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementBlock());
            return subject;
        }
    }
}