using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StInputFiles : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNode
    {
        public StInputFiles(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags flags, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator> decorators, System.Collections.Generic.List<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier> modifiers, System.String javascriptPath, System.String javascriptText, System.String javascriptMapPath, System.String javascriptMapText, System.String declarationPath, System.String declarationText, System.String declarationMapPath, System.String declarationMapText): base(flags, decorators, modifiers)
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.InputFiles;
            this.javascriptPath = javascriptPath;
            this.javascriptText = javascriptText;
            this.javascriptMapPath = javascriptMapPath;
            this.javascriptMapText = javascriptMapText;
            this.declarationPath = declarationPath;
            this.declarationText = declarationText;
            this.declarationMapPath = declarationMapPath;
            this.declarationMapText = declarationMapText;
        }

        public System.String javascriptPath
        {
            get;
            set;
        }

        public System.String javascriptText
        {
            get;
            set;
        }

        public System.String javascriptMapPath
        {
            get;
            set;
        }

        public System.String javascriptMapText
        {
            get;
            set;
        }

        public System.String declarationPath
        {
            get;
            set;
        }

        public System.String declarationText
        {
            get;
            set;
        }

        public System.String declarationMapPath
        {
            get;
            set;
        }

        public System.String declarationMapText
        {
            get;
            set;
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.InputFiles()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), javascriptPath = this.javascriptPath, javascriptText = this.javascriptText, javascriptMapPath = this.javascriptMapPath, javascriptMapText = this.javascriptMapText, declarationPath = this.declarationPath, declarationText = this.declarationText, declarationMapPath = this.declarationMapPath, declarationMapText = this.declarationMapText};
        }
    }
}