using System.Collections.Generic;
using System.Linq;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree
{
    public partial class ExpressionNew : ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode
    {
        ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId subjectType;
        public ExpressionNew()
        {
            this.Arguments = new ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode>(this);
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.BuilderNodeCollection<ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.ExpressionNode> Arguments
        {
            get;
            private set;
        }

        public ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId SubjectType
        {
            get
            {
                return this.subjectType;
            }

            set
            {
                this.SetAsParentFor(this.subjectType, value);
                this.subjectType = value;
            }
        }

        public override ForgedOnce.TsLanguageServices.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionNew();
            result.Arguments = this.Arguments.Select((i) => (ForgedOnce.TsLanguageServices.Model.DefinitionTree.ExpressionNode)i.ToLtsModelNode()).ToList();
            result.SubjectType = (ForgedOnce.TsLanguageServices.Model.DefinitionTree.TypeReferenceId)this.SubjectType?.ToLtsModelNode();
            return result;
        }
    }
}