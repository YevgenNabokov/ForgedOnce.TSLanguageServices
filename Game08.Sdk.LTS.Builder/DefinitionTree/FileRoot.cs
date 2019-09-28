using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class FileRoot : Node
    {
        public FileRoot()
        {
            this.Items = new BuilderNodeCollection<Node>(this);
        }

        public BuilderNodeCollection<Node> Items { get; private set; }

        public override LTSModel.Node ToLtsModelNode()
        {
            return this.ToLtsModelFileRoot();
        }

        public LTSModel.FileRoot ToLtsModelFileRoot()
        {
            return new LTSModel.FileRoot()
            {
                Items = this.Items.Select(i => i.ToLtsModelNode()).ToList()
            };
        }
    }
}
