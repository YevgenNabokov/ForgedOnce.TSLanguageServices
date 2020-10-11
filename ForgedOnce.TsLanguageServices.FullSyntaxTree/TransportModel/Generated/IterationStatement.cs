using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class IterationStatement : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Node, ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IStatement
    {
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IStatement statement
        {
            get;
            set;
        }
    }
}