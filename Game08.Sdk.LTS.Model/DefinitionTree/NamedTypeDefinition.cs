﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Model.DefinitionTree
{
    public abstract class NamedTypeDefinition : Node
    {
        public Identifier Name;

        public string TypeKey;
    }
}
