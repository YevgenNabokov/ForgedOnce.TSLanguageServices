using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class PropertyDeclaration : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Node
    {
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId typeReference;
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier name;
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration getter;
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration setter;
        public PropertyDeclaration()
        {
            this.Modifiers = new System.Collections.Generic.List<ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier>();
        }

        public System.Collections.Generic.List<ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier> Modifiers
        {
            get;
            private set;
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId TypeReference
        {
            get
            {
                return this.typeReference;
            }

            set
            {
                this.SetAsParentFor(this.typeReference, value);
                this.typeReference = value;
            }
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.SetAsParentFor(this.name, value);
                this.name = value;
            }
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration Getter
        {
            get
            {
                return this.getter;
            }

            set
            {
                this.SetAsParentFor(this.getter, value);
                this.getter = value;
            }
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodDeclaration Setter
        {
            get
            {
                return this.setter;
            }

            set
            {
                this.SetAsParentFor(this.setter, value);
                this.setter = value;
            }
        }

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.PropertyDeclaration();
            result.Modifiers = new System.Collections.Generic.List<ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier>(this.Modifiers);
            result.TypeReference = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.TypeReferenceId)this.TypeReference?.ToLtsModelNode();
            result.Name = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.Identifier)this.Name?.ToLtsModelNode();
            result.Getter = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.MethodDeclaration)this.Getter?.ToLtsModelNode();
            result.Setter = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.MethodDeclaration)this.Setter?.ToLtsModelNode();
            return result;
        }
    }
}