using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
{
    public class StatementLocalDeclaration : StatementNode
    {
        public StatementLocalDeclaration()
        {
            this.NodeType = NodeType.StatementLocalDeclaration;            
        }

        public TypeReferenceId TypeReference;

        public Identifier Name;

        public ExpressionNode Initializer;
    }
}
