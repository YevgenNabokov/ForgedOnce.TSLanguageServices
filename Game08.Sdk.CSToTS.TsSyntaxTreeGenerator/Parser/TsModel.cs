using Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Parser
{
    public class TsModel
    {
        public TypeDeclarationCache TypeDeclarations { get; set; }

        public Dictionary<string, TsEnum> Enums { get; set; }

        public Dictionary<string, TsInterface> Interfaces { get; set; }

        public Dictionary<string, Model.TypeDeclaration> Types { get; set; }

        public TsModel()
        {
            this.Enums = new Dictionary<string, TsEnum>();
            this.Interfaces = new Dictionary<string, TsInterface>();
            this.Types = new Dictionary<string, Model.TypeDeclaration>();
            this.TypeDeclarations = new TypeDeclarationCache();            
        }
    }
}
