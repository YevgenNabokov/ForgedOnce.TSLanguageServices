using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class ExpressionNew : ExpressionNode
    {
        private TypeReferenceId subjectType;

        public ExpressionNew()
        {
            this.Arguments = new BuilderNodeCollection<ExpressionNode>(this);
        }

        public BuilderNodeCollection<ExpressionNode> Arguments { get; private set; }

        public TypeReferenceId SubjectType
        {
            get => subjectType;
            set
            {
                this.SetAsParentFor(this.subjectType, value);
                this.subjectType = value;
            }
        }

        public override LTSModel.Node ToLtsModelNode()
        {
            return new LTSModel.ExpressionNew()
            {
                Arguments = this.Arguments.Select(a => (LTSModel.ExpressionNode)a.ToLtsModelNode()).ToList(),
                SubjectType = this.SubjectType != null ? (LTSModel.TypeReferenceId)this.SubjectType.ToLtsModelNode() : null
            };
        }
    }
}
