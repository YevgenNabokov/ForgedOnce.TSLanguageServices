using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class MethodDeclaration : Node
    {
        private Identifier name;

        private StatementBlock body;

        private TypeReferenceId returnType;

        public MethodDeclaration()
        {
            this.Modifiers = new List<LTSModel.Modifier>();
            this.Parameters = new BuilderNodeCollection<MethodParameter>(this);
        }

        public List<LTSModel.Modifier> Modifiers { get; private set; }

        public Identifier Name
        {
            get => name;
            set
            {
                this.SetAsParentFor(this.name, value);
                this.name = value;
            }
        }

        public BuilderNodeCollection<MethodParameter> Parameters { get; private set; }

        public StatementBlock Body
        {
            get => body;
            set
            {
                this.SetAsParentFor(this.body, value);
                this.body = value;
            }
        }

        public TypeReferenceId ReturnType
        {
            get => returnType;
            set
            {
                this.SetAsParentFor(this.returnType, value);
                this.returnType = value;
            }
        }

        public override LTSModel.Node ToLtsModelNode()
        {
            return new LTSModel.MethodDeclaration()
            {
                Modifiers = new List<LTSModel.Modifier>(this.Modifiers),
                Name = this.Name?.Name,
                Parameters = this.Parameters.Select(p => (LTSModel.MethodParameter)p.ToLtsModelNode()).ToList(),
                Body = this.Body != null ? (LTSModel.StatementBlock)this.Body.ToLtsModelNode() : null,
                ReturnType = this.ReturnType != null ? (LTSModel.TypeReferenceId)this.ReturnType.ToLtsModelNode() : null
            };
        }
    }
}
