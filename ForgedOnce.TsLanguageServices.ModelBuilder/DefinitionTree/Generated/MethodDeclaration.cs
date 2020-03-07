using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class MethodDeclaration : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Node
    {
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier name;
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementBlock body;
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId returnType;
        public MethodDeclaration()
        {
            this.Modifiers = new System.Collections.Generic.List<ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier>();
            this.Parameters = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodParameter>(this);
        }

        public System.Collections.Generic.List<ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier> Modifiers
        {
            get;
            private set;
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

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodParameter> Parameters
        {
            get;
            private set;
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementBlock Body
        {
            get
            {
                return this.body;
            }

            set
            {
                this.SetAsParentFor(this.body, value);
                this.body = value;
            }
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId ReturnType
        {
            get
            {
                return this.returnType;
            }

            set
            {
                this.SetAsParentFor(this.returnType, value);
                this.returnType = value;
            }
        }

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.MethodDeclaration();
            result.Modifiers = new System.Collections.Generic.List<ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier>(this.Modifiers);
            result.Name = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.Identifier)this.Name?.ToLtsModelNode();
            result.Parameters = this.Parameters.Select((i) => (ForgedOnce.TsLanguageServices.Model.DefinitionTree.MethodParameter)i.ToLtsModelNode()).ToList();
            result.Body = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.StatementBlock)this.Body?.ToLtsModelNode();
            result.ReturnType = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.TypeReferenceId)this.ReturnType?.ToLtsModelNode();
            return result;
        }
    }
}