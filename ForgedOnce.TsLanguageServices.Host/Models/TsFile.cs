using ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Host.Models
{
    public class TsFile
    {
        public string FileName { get; set; }

        public string Path { get; set; }

        public IEnumerable<IStatement> Statements { get; set; }
    }
}
