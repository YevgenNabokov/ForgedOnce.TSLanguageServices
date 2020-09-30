using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel
{
    public class TransportModelTypeReferencePrimitive : TransportModelTypeReference
    {
        public string FullyQualifiedName;

        public List<TransportModelTypeReference> GenericArguments = new List<TransportModelTypeReference>();

        public override TransportModelTypeReference Clone()
        {
            return new TransportModelTypeReferencePrimitive()
            {
                FullyQualifiedName = this.FullyQualifiedName,
                GenericArguments = new List<TransportModelTypeReference>(this.GenericArguments),
                IsCollection = this.IsCollection
            };
        }
    }
}
