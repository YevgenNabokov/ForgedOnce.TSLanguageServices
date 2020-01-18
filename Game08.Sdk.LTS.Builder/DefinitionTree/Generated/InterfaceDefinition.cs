using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class InterfaceDefinition : Game08.Sdk.LTS.Builder.DefinitionTree.NamedTypeDefinition
    {
        public InterfaceDefinition()
        {
            this.Modifiers = new System.Collections.Generic.List<Game08.Sdk.LTS.Model.DefinitionTree.Modifier>();
            this.Implements = new Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId>(this);
            this.Fields = new Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.FieldDeclaration>(this);
            this.Methods = new Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration>(this);
        }

        public System.Collections.Generic.List<Game08.Sdk.LTS.Model.DefinitionTree.Modifier> Modifiers
        {
            get;
            private set;
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId> Implements
        {
            get;
            private set;
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.FieldDeclaration> Fields
        {
            get;
            private set;
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.MethodDeclaration> Methods
        {
            get;
            private set;
        }

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.InterfaceDefinition();
            result.Modifiers = new System.Collections.Generic.List<Game08.Sdk.LTS.Model.DefinitionTree.Modifier>(this.Modifiers);
            result.Implements = this.Implements.Select((i) => (Game08.Sdk.LTS.Model.DefinitionTree.TypeReferenceId)i.ToLtsModelNode()).ToList();
            result.Fields = this.Fields.Select((i) => (Game08.Sdk.LTS.Model.DefinitionTree.FieldDeclaration)i.ToLtsModelNode()).ToList();
            result.Methods = this.Methods.Select((i) => (Game08.Sdk.LTS.Model.DefinitionTree.MethodDeclaration)i.ToLtsModelNode()).ToList();
            result.Name = (Game08.Sdk.LTS.Model.DefinitionTree.Identifier)this.Name?.ToLtsModelNode();
            result.TypeKey = this.TypeKey;
            return result;
        }
    }
}