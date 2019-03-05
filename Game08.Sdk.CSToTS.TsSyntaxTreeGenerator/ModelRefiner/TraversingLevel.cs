using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.ModelRefiner
{
    public class TraversingLevel
    {
        public TraversingLevel Parent { get; set; }

        public PropertyInfo ParentProperty { get; set; }

        public TraversingLevel Child { get; set; }

        public object Node { get; set; }

        public int? Index { get; set; }

        public void Reset()
        {
            this.Parent = null;
            this.ParentProperty = null;
            this.Child = null;
            this.Node = null;
            this.Index = null;
        }
    }
}
