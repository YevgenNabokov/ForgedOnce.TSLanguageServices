using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class ClassDefinition : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.NamedTypeDefinition
    {
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId baseType;
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ConstructorDeclaration constructor;
        public ClassDefinition()
        {
            this.Modifiers = new System.Collections.Generic.List<ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier>();
            this.Implements = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId>(this);
            this.Fields = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.FieldDeclaration>(this);
            this.Methods = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration>(this);
            this.Properties = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.PropertyDeclaration>(this);
        }

        public System.Collections.Generic.List<ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier> Modifiers
        {
            get;
            private set;
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId BaseType
        {
            get
            {
                return this.baseType;
            }

            set
            {
                this.SetAsParentFor(this.baseType, value);
                this.baseType = value;
            }
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId> Implements
        {
            get;
            private set;
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.FieldDeclaration> Fields
        {
            get;
            private set;
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration> Methods
        {
            get;
            private set;
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.PropertyDeclaration> Properties
        {
            get;
            private set;
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ConstructorDeclaration Constructor
        {
            get
            {
                return this.constructor;
            }

            set
            {
                this.SetAsParentFor(this.constructor, value);
                this.constructor = value;
            }
        }

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.ClassDefinition();
            result.Modifiers = new System.Collections.Generic.List<ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier>(this.Modifiers);
            result.BaseType = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.TypeReferenceId)this.BaseType?.ToLtsModelNode();
            result.Implements = this.Implements.Select((i) => (ForgedOnce.TsLanguageServices.Model.DefinitionTree.TypeReferenceId)i.ToLtsModelNode()).ToList();
            result.Fields = this.Fields.Select((i) => (ForgedOnce.TsLanguageServices.Model.DefinitionTree.FieldDeclaration)i.ToLtsModelNode()).ToList();
            result.Methods = this.Methods.Select((i) => (ForgedOnce.TsLanguageServices.Model.DefinitionTree.MethodDeclaration)i.ToLtsModelNode()).ToList();
            result.Properties = this.Properties.Select((i) => (ForgedOnce.TsLanguageServices.Model.DefinitionTree.PropertyDeclaration)i.ToLtsModelNode()).ToList();
            result.Constructor = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.ConstructorDeclaration)this.Constructor?.ToLtsModelNode();
            result.Name = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.Identifier)this.Name?.ToLtsModelNode();
            result.TypeKey = this.TypeKey;
            return result;
        }
    }
}