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

        System.String _javascriptPath;
        System.String _javascriptText;
        System.String _javascriptMapPath;
        System.String _javascriptMapText;
        System.String _declarationPath;
        System.String _declarationText;
        System.String _declarationMapPath;
        System.String _declarationMapText;
        public System.String javascriptPath
        {
            get
            {
                return this._javascriptPath;
            }

            set
            {
                this.EnsureIsEditable();
                this._javascriptPath = value;
            }
        }

        public System.String javascriptText
        {
            get
            {
                return this._javascriptText;
            }

            set
            {
                this.EnsureIsEditable();
                this._javascriptText = value;
            }
        }

        public System.String javascriptMapPath
        {
            get
            {
                return this._javascriptMapPath;
            }

            set
            {
                this.EnsureIsEditable();
                this._javascriptMapPath = value;
            }
        }

        public System.String javascriptMapText
        {
            get
            {
                return this._javascriptMapText;
            }

            set
            {
                this.EnsureIsEditable();
                this._javascriptMapText = value;
            }
        }

        public System.String declarationPath
        {
            get
            {
                return this._declarationPath;
            }

            set
            {
                this.EnsureIsEditable();
                this._declarationPath = value;
            }
        }

        public System.String declarationText
        {
            get
            {
                return this._declarationText;
            }

            set
            {
                this.EnsureIsEditable();
                this._declarationText = value;
            }
        }

        public System.String declarationMapPath
        {
            get
            {
                return this._declarationMapPath;
            }

            set
            {
                this.EnsureIsEditable();
                this._declarationMapPath = value;
            }
        }

        public System.String declarationMapText
        {
            get
            {
                return this._declarationMapText;
            }

            set
            {
                this.EnsureIsEditable();
                this._declarationMapText = value;
            }
        }

        public override System.Object GetTransportModelNode()
        {
            return new ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.InputFiles()
            {kind = this.kind, flags = this.flags, decorators = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator>(this.decorators), modifiers = this.GetTransportModelNodes<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IModifier>(this.modifiers), javascriptPath = this.javascriptPath, javascriptText = this.javascriptText, javascriptMapPath = this.javascriptMapPath, javascriptMapText = this.javascriptMapText, declarationPath = this.declarationPath, declarationText = this.declarationText, declarationMapPath = this.declarationMapPath, declarationMapText = this.declarationMapText};
        }
    }
}