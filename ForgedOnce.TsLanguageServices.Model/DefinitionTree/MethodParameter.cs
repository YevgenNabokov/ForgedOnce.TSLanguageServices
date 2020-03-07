using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
{
    public class MethodParameter : Node
    {
        public MethodParameter()
        {
            this.NodeType = NodeType.MethodParameter;
        }

        public Identifier Name;

        public TypeReferenceId TypeReference;

        public ExpressionLiteral DefaultValue;
    }
}
