using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.BuilderDefinitionTreePlugin
{
    public class Parameters
    {
        public Parameters(List<NodeTypeInfo> types)
        {
            this.Types = types;
        }

        public List<NodeTypeInfo> Types
        {
            get;
            private set;
        }
    }
}
