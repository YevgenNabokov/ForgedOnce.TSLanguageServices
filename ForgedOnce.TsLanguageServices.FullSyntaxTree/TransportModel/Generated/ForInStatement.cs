using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel
{
    public class ForInStatement : ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IterationStatement
    {
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IForInitializer initializer
        {
            get;
            set;
        }

        public ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IExpression expression
        {
            get;
            set;
        }
    }
}