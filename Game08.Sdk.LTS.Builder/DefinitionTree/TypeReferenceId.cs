using System;
using System.Collections.Generic;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class TypeReferenceId : Node
    {
        public string ReferenceKey { get; set; }

        public override LTSModel.Node ToLtsModelNode()
        {
            return new LTSModel.TypeReferenceId()
            {
                ReferenceKey = this.ReferenceKey
            };
        }
    }
}
