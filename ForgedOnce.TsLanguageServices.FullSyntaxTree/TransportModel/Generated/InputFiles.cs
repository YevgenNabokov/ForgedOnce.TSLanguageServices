using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class InputFiles : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node
    {
        public InputFiles()
        {
            this.kind = ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.InputFiles;
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
    }
}