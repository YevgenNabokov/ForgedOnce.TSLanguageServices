using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class ConstructorDeclaration : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Node
    {
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementBlock body;
        public ConstructorDeclaration()
        {
            this.Modifiers = new System.Collections.Generic.List<ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier>();
            this.Parameters = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.MethodParameter>(this);
        }

        public System.Collections.Generic.List<ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier> Modifiers
        {
            get;
            private set;
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

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.ConstructorDeclaration();
            result.Modifiers = new System.Collections.Generic.List<ForgedOnce.TsLanguageServices.Model.DefinitionTree.Modifier>(this.Modifiers);
            result.Parameters = this.Parameters.Select((i) => (ForgedOnce.TsLanguageServices.Model.DefinitionTree.MethodParameter)i.ToLtsModelNode()).ToList();
            result.Body = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.StatementBlock)this.Body?.ToLtsModelNode();
            return result;
        }
    }
}