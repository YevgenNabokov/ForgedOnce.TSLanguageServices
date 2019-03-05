using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.ModelRefiner
{
    public class TypeDetails
    {
        public List<PropertyInfo> SimpleProperties { get; set; }

        public List<PropertyInfo> ListProperties { get; set; }

        public List<PropertyInfo> DictionaryProperties { get; set; }

        public TypeDetails()
        {
            this.SimpleProperties = new List<PropertyInfo>();
            this.ListProperties = new List<PropertyInfo>();
            this.DictionaryProperties = new List<PropertyInfo>();
        }
    }
}
