using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = ForgedOnce.TsLanguageServices.Model.DefinitionTree;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
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
