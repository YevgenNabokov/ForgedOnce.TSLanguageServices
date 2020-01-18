using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class FileRoot
    {
        public LTSModel.FileRoot ToLtsModelFileRoot()
        {
            return new LTSModel.FileRoot()
            {
                Items = this.Items.Select(i => i.ToLtsModelNode()).ToList()
            };
        }
    }
}
