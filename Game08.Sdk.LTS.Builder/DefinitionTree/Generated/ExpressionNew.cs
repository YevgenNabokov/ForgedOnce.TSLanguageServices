using System.Collections.Generic;
using System.Linq;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public partial class ExpressionNew : Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode
    {
        Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId subjectType;
        public ExpressionNew()
        {
            this.Arguments = new Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode>(this);
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.BuilderNodeCollection<Game08.Sdk.LTS.Builder.DefinitionTree.ExpressionNode> Arguments
        {
            get;
            private set;
        }

        public Game08.Sdk.LTS.Builder.DefinitionTree.TypeReferenceId SubjectType
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

        public override Game08.Sdk.LTS.Model.DefinitionTree.Node ToLtsModelNode()
        {
            var result = new Game08.Sdk.LTS.Model.DefinitionTree.ExpressionNew();
            result.Arguments = this.Arguments.Select((i) => (Game08.Sdk.LTS.Model.DefinitionTree.ExpressionNode)i.ToLtsModelNode()).ToList();
            result.SubjectType = (Game08.Sdk.LTS.Model.DefinitionTree.TypeReferenceId)this.SubjectType?.ToLtsModelNode();
            return result;
        }
    }
}