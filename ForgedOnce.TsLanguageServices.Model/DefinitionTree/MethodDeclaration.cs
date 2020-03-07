using ForgedOnce.TsLanguageServices.Model.TypeData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.Model.DefinitionTree
{
    public class MethodDeclaration : Node
    {
        public MethodDeclaration()
        {
            this.NodeType = NodeType.MethodDeclaration;
            this.Parameters = new List<MethodParameter>();
        }

        public List<Modifier> Modifiers;

        public Identifier Name;

        public List<MethodParameter> Parameters;

        public StatementBlock Body;

        public TypeReferenceId ReturnType;
    }
}
