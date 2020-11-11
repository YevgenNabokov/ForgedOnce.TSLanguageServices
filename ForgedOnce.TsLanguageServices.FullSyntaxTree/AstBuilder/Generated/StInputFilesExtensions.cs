using System;
using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder
{
    public static partial class StInputFilesExtensions
    {
        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles WithJavascriptPath(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles subject, string javascriptPath)
        {
            subject.javascriptPath = javascriptPath;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles WithJavascriptText(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles subject, string javascriptText)
        {
            subject.javascriptText = javascriptText;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles WithJavascriptMapPath(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles subject, string javascriptMapPath)
        {
            subject.javascriptMapPath = javascriptMapPath;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles WithJavascriptMapText(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles subject, string javascriptMapText)
        {
            subject.javascriptMapText = javascriptMapText;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles WithDeclarationPath(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles subject, string declarationPath)
        {
            subject.declarationPath = declarationPath;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles WithDeclarationText(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles subject, string declarationText)
        {
            subject.declarationText = declarationText;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles WithDeclarationMapPath(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles subject, string declarationMapPath)
        {
            subject.declarationMapPath = declarationMapPath;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles WithDeclarationMapText(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles subject, string declarationMapText)
        {
            subject.declarationMapText = declarationMapText;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles WithFlags(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags)
        {
            subject.flags = flags;
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles WithDecorator(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles subject, Func<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decoratorBuilder)
        {
            subject.decorators.Add(decoratorBuilder(new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator()));
            return subject;
        }

        public static ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles WithModifier(this ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles subject, ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier modifier)
        {
            subject.modifiers.Add(modifier);
            return subject;
        }
    }
}