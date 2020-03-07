using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class FileRoot : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Node
    {
        public FileRoot()
        {
            this.Items = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Node>(this);
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Node> Items
        {
            get;
            private set;
        }

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.FileRoot();
            result.Items = this.Items.Select((i) => (ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node)i.ToLtsModelNode()).ToList();
            return result;
        }
    }
}