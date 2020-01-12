using Game08.Sdk.LTS.Builder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.ExtensionMethods
{
    public static partial class FileRootExtensions
    {
        public static Game08.Sdk.LTS.Builder.DefinitionTree.FileRoot WithItem(this Game08.Sdk.LTS.Builder.DefinitionTree.FileRoot subject, Game08.Sdk.LTS.Builder.DefinitionTree.Node item)
        {
            subject.Items.Add(item);
            return subject;
        }
    }
}