using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class FileRoot : Game08.Sdk.LTS.Builder.DefinitionTree.Node
    {
        public FileRoot()
        {
            this.Items = new Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.Node>(this);
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.Node> Items
        {
            get;
            private set;
        }

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.FileRoot();
            result.Items = this.Items.Select((i) => (Game08.Sdk.LTS.Model.DefinitionTree.Node)i.ToLtsModelNode()).ToList();
            return result;
        }
    }
}