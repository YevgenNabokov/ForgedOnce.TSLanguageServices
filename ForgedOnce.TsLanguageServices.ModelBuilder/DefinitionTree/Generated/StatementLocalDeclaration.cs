using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class StatementLocalDeclaration : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.StatementNode
    {
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId typeReference;
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier name;
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode initializer;
        public StatementLocalDeclaration()
        {
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

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode Initializer
        {
            get
            {
                return this.initializer;
            }

            set
            {
                this.SetAsParentFor(this.initializer, value);
                this.initializer = value;
            }
        }

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.StatementLocalDeclaration();
            result.TypeReference = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.TypeReferenceId)this.TypeReference?.ToLtsModelNode();
            result.Name = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.Identifier)this.Name?.ToLtsModelNode();
            result.Initializer = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionNode)this.Initializer?.ToLtsModelNode();
            return result;
        }
    }
}