using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.BuilderDefinitionTreePlugin
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
