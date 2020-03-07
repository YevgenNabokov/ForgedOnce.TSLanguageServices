using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods
{
    public static partial class MethodDeclarationExtensions
    {
        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration WithModifier(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration subject, ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier modifier)
        {
            subject.Modifiers.Add(modifier);
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration WithName(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration subject, string name)
        {
            subject.Name = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier{Name = name};
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration WithParameter(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration subject, Func<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodParameter, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodParameter> parameterBuilder)
        {
            subject.Parameters.Add(parameterBuilder(new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodParameter()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration WithBody(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration subject, Func<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementBlock, ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementBlock> bodyBuilder)
        {
            subject.Body = bodyBuilder(new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementBlock());
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration WithReturnType(this ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration subject, string referenceKey)
        {
            subject.ReturnType = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId{ReferenceKey = referenceKey};
            return subject;
        }
    }
}