using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel
{
    public class TransportModelTypeReferenceGenericParameter : TransportModelTypeReference
    {
        public string Name;

        public override TransportModelTypeReference Clone()
        {
            return new TransportModelTypeReferenceGenericParameter()
            {
                Name = this.Name,
                IsCollection = this.IsCollection
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is TransportModelTypeReferenceGenericParameter param)
            {
                return this.Name == param.Name && this.IsCollection == param.IsCollection;
            }

            return false;
        }
    }
}
