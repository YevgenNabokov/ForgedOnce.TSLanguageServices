using ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.ModelTsInterfacesPlugin
{
    public class TypeMappings
    {
        public Dictionary<Type, string> PrimitiveTypeMappings = new Dictionary<Type, string>();

        public Dictionary<Type, Func<IStTypeNode>> ComplexTypeMappings = new Dictionary<Type, Func<IStTypeNode>>();
    }
}
