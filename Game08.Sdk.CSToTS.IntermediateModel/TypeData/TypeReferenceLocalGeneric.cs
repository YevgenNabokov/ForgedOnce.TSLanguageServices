﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.IntermediateModel.TypeData
{
    public class TypeReferenceLocalGeneric : TypeReference
    {
        public TypeReferenceLocalGeneric()
        {
            this.Kind = TypeReferenceKind.LocalGeneric;
        }

        public string ArgumentName;

        public string ReferenceTypeId;

        public override string RefreshId()
        {
            this.Id = $"{{{this.Kind}|A:{this.ArgumentName}}}";
            return this.Id;
        }
    }
}