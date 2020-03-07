using ForgedOnce.TsLanguageServices.Model.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.ModelBuilder
{
    public class DefinitionTreeVisitor<TContext>
    {
        public virtual void Visit(Node node, TContext context)
        {
            if (node == null)
            {
                return;
            }

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

            if (node is ConstructorDeclaration)
            {
                this.VisitConstructorDeclaration(node as ConstructorDeclaration, context);
                return;
            }

            if (node is EnumDefinition)
            {
                this.VisitEnumDefinition(node as EnumDefinition, context);
                return;
            }

            if (node is EnumMember)
            {
                this.VisitEnumMember(node as EnumMember, context);
                return;
            }

            if (node is ExpressionAssignment)
            {
                this.VisitExpressionAssignment(node as ExpressionAssignment, context);
                return;
            }

            if (node is ExpressionBinary)
            {
                this.VisitExpressionBinary(node as ExpressionBinary, context);
                return;
            }

            if (node is ExpressionIdentifierReference)
            {
                this.VisitExpressionIdentifierReference(node as ExpressionIdentifierReference, context);
                return;
            }

            if (node is ExpressionInvocation)
            {
                this.VisitExpressionInvocation(node as ExpressionInvocation, context);
                return;
            }

            if (node is ExpressionLiteral)
            {
                this.VisitExpressionLiteral(node as ExpressionLiteral, context);
                return;
            }

            if (node is ExpressionMemberAccess)
            {
                this.VisitExpressionMemberAccess(node as ExpressionMemberAccess, context);
                return;
            }

            if (node is ExpressionThis)
            {
                this.VisitExpressionThis(node as ExpressionThis, context);
                return;
            }

            if (node is FieldDeclaration)
            {
                this.VisitFieldDeclaration(node as FieldDeclaration, context);
                return;
            }

            if (node is InterfaceDefinition)
            {
                this.VisitInterfaceDefinition(node as InterfaceDefinition, context);
                return;
            }

            if (node is MethodDeclaration)
            {
                this.VisitMethodDeclaration(node as MethodDeclaration, context);
                return;
            }

            if (node is MethodParameter)
            {
                this.VisitMethodParameter(node as MethodParameter, context);
                return;
            }

            if (node is PropertyDeclaration)
            {
                this.VisitPropertyDeclaration(node as PropertyDeclaration, context);
                return;
            }

            if (node is StatementBlock)
            {
                this.VisitStatementBlock(node as StatementBlock, context);
                return;
            }

            if (node is StatementExpression)
            {
                this.VisitStatementExpression(node as StatementExpression, context);
                return;
            }

            if (node is StatementLocalDeclaration)
            {
                this.VisitStatementLocalDeclaration(node as StatementLocalDeclaration, context);
                return;
            }

            if (node is StatementReturn)
            {
                this.VisitStatementReturn(node as StatementReturn, context);
                return;
            }

            if (node is TypeReferenceId)
            {
                this.VisitTypeReferenceId(node as TypeReferenceId, context);
                return;
            }

            throw new NotImplementedException($"No method for {node.GetType()}");
        }

        public virtual void VisitTypeReferenceId(TypeReferenceId node, TContext context)
        {
        }

        public virtual void VisitStatementReturn(StatementReturn node, TContext context)
        {
            this.Visit(node.Expression, context);
        }

        public virtual void VisitStatementLocalDeclaration(StatementLocalDeclaration node, TContext context)
        {
            this.Visit(node.TypeReference, context);
            this.Visit(node.Initializer, context);
        }

        public virtual void VisitStatementExpression(StatementExpression node, TContext context)
        {
            this.Visit(node.Expression, context);
        }

        public virtual void VisitStatementBlock(StatementBlock node, TContext context)
        {
            if (node.Statements != null)
            {
                foreach (var s in node.Statements)
                {
                    this.Visit(s, context);
                }
            }
        }

        public virtual void VisitPropertyDeclaration(PropertyDeclaration node, TContext context)
        {
            this.Visit(node.Getter, context);
            this.Visit(node.Setter, context);
            this.Visit(node.TypeReference, context);
        }

        public virtual void VisitMethodParameter(MethodParameter node, TContext context)
        {
            this.Visit(node.TypeReference, context);
        }

        public virtual void VisitMethodDeclaration(MethodDeclaration node, TContext context)
        {
            this.Visit(node.Body, context);
            this.Visit(node.ReturnType, context);
            if (node.Parameters != null)
            {
                foreach (var p in node.Parameters)
                {
                    this.Visit(p, context);
                }
            }
        }

        public virtual void VisitInterfaceDefinition(InterfaceDefinition node, TContext context)
        {
            if (node.Fields != null)
            {
                foreach (var f in node.Fields)
                {
                    this.Visit(f, context);
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
        }

        public virtual void VisitFieldDeclaration(FieldDeclaration node, TContext context)
        {
            this.Visit(node.Initializer, context);
            this.Visit(node.TypeReference, context);
        }

        public virtual void VisitExpressionThis(ExpressionThis node, TContext context)
        {
        }

        public virtual void VisitExpressionMemberAccess(ExpressionMemberAccess node, TContext context)
        {
            this.Visit(node.Expression, context);
        }

        public virtual void VisitExpressionLiteral(ExpressionLiteral node, TContext context)
        {            
        }

        public virtual void VisitExpressionInvocation(ExpressionInvocation node, TContext context)
        {
            this.Visit(node.Expression, context);
            if (node.Arguments != null)
            {
                foreach (var a in node.Arguments)
                {
                    this.Visit(a, context);
                }
            }
        }

        public virtual void VisitExpressionIdentifierReference(ExpressionIdentifierReference node, TContext context)
        {            
        }

        public virtual void VisitExpressionBinary(ExpressionBinary node, TContext context)
        {
            this.Visit(node.Left, context);
            this.Visit(node.Right, context);
        }

        public virtual void VisitExpressionAssignment(ExpressionAssignment node, TContext context)
        {
            this.Visit(node.Left, context);
            this.Visit(node.Right, context);
        }

        public virtual void VisitEnumMember(EnumMember node, TContext context)
        {
            this.Visit(node.Value, context);
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
            this.Visit(node.BaseType, context);
            this.Visit(node.Constructor, context);

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

        public virtual void VisitConstructorDeclaration(ConstructorDeclaration node, TContext context)
        {
            if (node.Parameters != null)
            {
                foreach (var p in node.Parameters)
                {
                    this.Visit(p, context);
                }
            }

            this.Visit(node.Body, context);
        }

        public virtual void VisitEnumDefinition(EnumDefinition node, TContext context)
        {
            if (node.Members != null)
            {
                foreach (var m in node.Members)
                {
                    this.Visit(m, context);
                }
            }
        }
    }
}
