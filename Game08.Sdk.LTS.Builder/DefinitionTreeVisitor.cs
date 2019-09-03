using Game08.Sdk.LTS.Model.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder
{
    public class DefinitionTreeVisitor<TContext>
    {
        public virtual void Visit(Node node, TContext context)
        {
            if (node is FileRoot)
            {
                this.VisitFileRoot(node as FileRoot, context);
                return;
            }

            if (node is ClassDefinition)
            {
                this.VisitClassDefinition(node as ClassDefinition, context);
                return;
            }
        }

        public virtual void VisitFileRoot(FileRoot node, TContext context)
        {
            if (node.Items != null)
            {
                foreach (var subNode in node.Items)
                {
                    this.Visit(subNode, context);
                }
            }
        }

        public virtual void VisitClassDefinition(ClassDefinition node, TContext context)
        {
            if (node.BaseType != null)
            {
                this.Visit(node.BaseType, context);
            }

            if (node.Constructor != null)
            {
                this.Visit(node.Constructor, context);
            }

            if (node.Fields != null)
            {
                foreach (var field in node.Fields)
                {
                    this.Visit(field, context);
                }
            }

            if (node.Implements != null)
            {
                foreach (var i in node.Implements)
                {
                    this.Visit(i, context);
                }
            }

            if (node.Methods != null)
            {
                foreach (var m in node.Methods)
                {
                    this.Visit(m, context);
                }
            }

            if (node.Properties != null)
            {
                foreach (var p in node.Properties)
                {
                    this.Visit(p, context);
                }
            }
        }
    }
}
