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

        public override bool Equals(object obj)
        {
            if (obj is TransportModelTypeReferencePrimitive primitive)
            {
                if (this.GenericArguments.Count != primitive.GenericArguments.Count)
                {
                    return false;
                }

                for (var i = 0; i < this.GenericArguments.Count; i++)
                {
                    if (!this.GenericArguments[i].Equals(primitive.GenericArguments[i]))
                    {
                        return false;
                    }
                }

                return this.FullyQualifiedName == primitive.FullyQualifiedName && this.IsCollection == primitive.IsCollection;
            }

            return false;
        }
    }
}
