using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTSModel = Game08.Sdk.LTS.Model.DefinitionTree;

namespace Game08.Sdk.LTS.Builder.DefinitionTree
{
    public class ConstructorDeclaration : Node
    {
        private StatementBlock body;

        public ConstructorDeclaration()
        {
            this.Modifiers = new List<LTSModel.Modifier>();
            this.Parameters = new BuilderNodeCollection<MethodParameter>(this);
        }

        public List<LTSModel.Modifier> Modifiers { get; private set; }

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

        public override LTSModel.Node ToLtsModelNode()
        {
            return new LTSModel.ConstructorDeclaration()
            {
                Modifiers = new List<LTSModel.Modifier>(this.Modifiers),
                Parameters = this.Parameters.Select(p => (LTSModel.MethodParameter)p.ToLtsModelNode()).ToList(),
                Body = this.Body != null ? (LTSModel.StatementBlock)this.Body.ToLtsModelNode() : null
            };
        }
    }
}
