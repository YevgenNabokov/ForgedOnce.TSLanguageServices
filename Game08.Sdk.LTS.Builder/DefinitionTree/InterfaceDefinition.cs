using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class InterfaceDefinition : NamedTypeDefinition
    {
        public InterfaceDefinition()
        {
            this.Modifiers = new List<LTSModel.Modifier>();
            this.Implements = new BuilderNodeCollection<TypeReferenceId>(this);
            this.Fields = new BuilderNodeCollection<FieldDeclaration>(this);
            this.Methods = new BuilderNodeCollection<MethodDeclaration>(this);
        }

        public List<LTSModel.Modifier> Modifiers { get; private set; }

        public BuilderNodeCollection<TypeReferenceId> Implements { get; private set; }

        public BuilderNodeCollection<FieldDeclaration> Fields { get; private set; }

        public BuilderNodeCollection<MethodDeclaration> Methods { get; private set; }

        public override LTSModel.Node ToLtsModelNode()
        {
            return new LTSModel.InterfaceDefinition()
            {
                Modifiers = new List<LTSModel.Modifier>(this.Modifiers),
                Implements = this.Implements.Select(i => (LTSModel.TypeReferenceId)i.ToLtsModelNode()).ToList(),
                Fields = this.Fields.Select(i => (LTSModel.FieldDeclaration)i.ToLtsModelNode()).ToList(),
                Methods = this.Methods.Select(i => (LTSModel.MethodDeclaration)i.ToLtsModelNode()).ToList(),
                Name = this.Name?.Name,
                TypeKey = this.TypeKey
            };
        }
    }
}
