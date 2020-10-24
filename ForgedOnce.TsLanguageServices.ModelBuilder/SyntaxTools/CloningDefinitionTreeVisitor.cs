using ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.SyntaxTools
{
    public class CloningDefinitionTreeVisitor : BuilderDefinitionTreeVisitor<CloningDefinitionTreeVisitorContext>
    {
        public override void Visit(Node node, CloningDefinitionTreeVisitorContext context)
        {
            if (node == null)
            {
                context.Result = null;
            }

            base.Visit(node, context);
        }

        public override void VisitExpressionTypeReference(ExpressionTypeReference node, CloningDefinitionTreeVisitorContext context)
        {
            var result = new ExpressionTypeReference()
            {
                TypeId = this.CloneNode(node.TypeId, context)
            };

            context.Result = result;
        }

        public override void VisitStatementIf(StatementIf node, CloningDefinitionTreeVisitorContext context)
        {
            var result = new StatementIf()
            {
                Expression = this.CloneNode(node.Expression, context),
                Else = this.CloneNode(node.Else, context),
                Then = this.CloneNode(node.Then, context)
            };

            context.Result = result;
        }

        public override void VisitExpressionElementAccess(ExpressionElementAccess node, CloningDefinitionTreeVisitorContext context)
        {
            var result = new ExpressionElementAccess()
            {
                Expression = this.CloneNode(node.Expression, context),
                Index = this.CloneNode(node.Index, context)
            };

            context.Result = result;
        }

        public override void VisitClassDefinition(ClassDefinition node, CloningDefinitionTreeVisitorContext context)
        {
            var result = new ClassDefinition()
            {
                BaseType = this.CloneNode(node.BaseType, context),
                Constructor = this.CloneNode(node.Constructor, context),
                Name = this.CloneNode(node.Name, context),
                TypeKey = node.TypeKey
            };
            this.CloneNodeCollection(node.Fields, result.Fields, context);
            this.CloneNodeCollection(node.Implements, result.Implements, context);
            this.CloneNodeCollection(node.Methods, result.Methods, context);
            this.CloneList(node.Modifiers, result.Modifiers);
            this.CloneNodeCollection(node.Properties, result.Properties, context);
            context.Result = result;
        }

        public override void VisitConstructorDeclaration(ConstructorDeclaration node, CloningDefinitionTreeVisitorContext context)
        {
            var result = new ConstructorDeclaration()
            {
                Body = this.CloneNode(node.Body, context)
            };
            this.CloneNodeCollection(node.Parameters, result.Parameters, context);
            this.CloneList(node.Modifiers, result.Modifiers);            
            context.Result = result;
        }

        public override void VisitEnumDefinition(EnumDefinition node, CloningDefinitionTreeVisitorContext context)
        {
            var result = new EnumDefinition()
            {
                Name = this.CloneNode(node.Name, context),
                TypeKey = node.TypeKey
            };
            this.CloneNodeCollection(node.Members, result.Members, context);
            this.CloneList(node.Modifiers, result.Modifiers);
            context.Result = result;
        }

        public override void VisitEnumMember(EnumMember node, CloningDefinitionTreeVisitorContext context)
        {
            context.Result = new EnumMember()
            {
                Name = this.CloneNode(node.Name, context),
                Value = this.CloneNode(node.Value, context)
            };
        }

        public override void VisitExpressionAssignment(ExpressionAssignment node, CloningDefinitionTreeVisitorContext context)
        {
            context.Result = new ExpressionAssignment()
            {
                Left = this.CloneNode(node.Left, context),
                Right = this.CloneNode(node.Right, context)
            };
        }

        public override void VisitExpressionBinary(ExpressionBinary node, CloningDefinitionTreeVisitorContext context)
        {
            context.Result = new ExpressionBinary()
            {
                Left = this.CloneNode(node.Left, context),
                Operator = node.Operator,
                Right = this.CloneNode(node.Right)
            };
        }

        public override void VisitExpressionIdentifierReference(ExpressionIdentifierReference node, CloningDefinitionTreeVisitorContext context)
        {
            context.Result = new ExpressionIdentifierReference()
            {
                Name = this.CloneNode(node.Name, context)
            };
        }

        public override void VisitExpressionInvocation(ExpressionInvocation node, CloningDefinitionTreeVisitorContext context)
        {
            var result = new ExpressionInvocation()
            {
                Expression = this.CloneNode(node.Expression)
            };
            this.CloneNodeCollection(node.Arguments, result.Arguments, context);
            context.Result = result;
        }

        public override void VisitExpressionLiteral(ExpressionLiteral node, CloningDefinitionTreeVisitorContext context)
        {
            context.Result = new ExpressionLiteral()
            {
                IsNumeric = node.IsNumeric,
                Text = node.Text
            };
        }

        public override void VisitExpressionMemberAccess(ExpressionMemberAccess node, CloningDefinitionTreeVisitorContext context)
        {
            context.Result = new ExpressionMemberAccess()
            {
                Name = this.CloneNode(node.Name, context),
                Expression = this.CloneNode(node.Expression, context)
            };
        }

        public override void VisitExpressionNew(ExpressionNew node, CloningDefinitionTreeVisitorContext context)
        {
            var result = new ExpressionNew()
            {
                SubjectType = this.CloneNode(node.SubjectType)
            };
            this.CloneNodeCollection(node.Arguments, result.Arguments, context);
            context.Result = result;
        }

        public override void VisitExpressionThis(ExpressionThis node, CloningDefinitionTreeVisitorContext context)
        {
            context.Result = new ExpressionThis();
        }

        public override void VisitExpressionUnary(ExpressionUnary node, CloningDefinitionTreeVisitorContext context)
        {
            context.Result = new ExpressionUnary()
            {
                Left = this.CloneNode(node.Left, context),
                Operator = node.Operator
            };
        }

        public override void VisitFieldDeclaration(FieldDeclaration node, CloningDefinitionTreeVisitorContext context)
        {
            var result = new FieldDeclaration()
            {
                Initializer = this.CloneNode(node.Initializer, context),
                Name = this.CloneNode(node.Name, context),
                TypeReference = this.CloneNode(node.TypeReference, context)
            };
            this.CloneList(node.Modifiers, result.Modifiers);
            context.Result = result;
        }

        public override void VisitFileRoot(FileRoot node, CloningDefinitionTreeVisitorContext context)
        {
            var result = new FileRoot();
            this.CloneNodeCollection(node.Items, result.Items, context);
            context.Result = result;
        }

        public override void VisitIdentifier(Identifier node, CloningDefinitionTreeVisitorContext context)
        {
            context.Result = new Identifier()
            {
                Name = node.Name
            };
        }

        public override void VisitInterfaceDefinition(InterfaceDefinition node, CloningDefinitionTreeVisitorContext context)
        {
            var result = new InterfaceDefinition()
            {
                Name = this.CloneNode(node.Name, context),
                TypeKey = node.TypeKey
            };
            this.CloneNodeCollection(node.Fields, result.Fields, context);
            this.CloneNodeCollection(node.Implements, result.Implements, context);
            this.CloneNodeCollection(node.Methods, result.Methods, context);
            this.CloneList(node.Modifiers, result.Modifiers);
            context.Result = result;
        }

        public override void VisitMethodDeclaration(MethodDeclaration node, CloningDefinitionTreeVisitorContext context)
        {
            var result = new MethodDeclaration()
            {
                Body = this.CloneNode(node.Body, context),
                Name = this.CloneNode(node.Name, context),
                ReturnType = this.CloneNode(node.ReturnType, context)
            };
            this.CloneNodeCollection(node.Parameters, result.Parameters, context);
            this.CloneList(node.Modifiers, result.Modifiers);
            context.Result = result;
        }

        public override void VisitMethodParameter(MethodParameter node, CloningDefinitionTreeVisitorContext context)
        {
            context.Result = new MethodParameter()
            {
                DefaultValue = this.CloneNode(node.DefaultValue, context),
                Name = this.CloneNode(node.Name, context),
                TypeReference = this.CloneNode(node.TypeReference, context)
            };
        }

        public override void VisitPropertyDeclaration(PropertyDeclaration node, CloningDefinitionTreeVisitorContext context)
        {
            var result = new PropertyDeclaration()
            {
                Getter = this.CloneNode(node.Getter, context),
                Name = this.CloneNode(node.Name, context),
                Setter = this.CloneNode(node.Setter, context),
                TypeReference = this.CloneNode(node.TypeReference, context)
            };
            this.CloneList(node.Modifiers, result.Modifiers);
            context.Result = result;
        }

        public override void VisitStatementBlock(StatementBlock node, CloningDefinitionTreeVisitorContext context)
        {
            var result = new StatementBlock();
            this.CloneNodeCollection(node.Statements, result.Statements, context);
            context.Result = result;
        }

        public override void VisitStatementExpression(StatementExpression node, CloningDefinitionTreeVisitorContext context)
        {
            context.Result = new StatementExpression()
            {
                Expression = this.CloneNode(node.Expression, context)
            };
        }

        public override void VisitStatementFor(StatementFor node, CloningDefinitionTreeVisitorContext context)
        {
            context.Result = new StatementFor()
            {
                Condition = this.CloneNode(node.Condition, context),
                Increment = this.CloneNode(node.Increment, context),
                Initializer = this.CloneNode(node.Initializer, context),
                Statement = this.CloneNode(node.Statement, context)
            };
        }

        public override void VisitStatementLocalDeclaration(StatementLocalDeclaration node, CloningDefinitionTreeVisitorContext context)
        {
            context.Result = new StatementLocalDeclaration()
            {
                Initializer = this.CloneNode(node.Initializer, context),
                Name = this.CloneNode(node.Name, context),
                TypeReference = this.CloneNode(node.TypeReference, context)
            };
        }

        public override void VisitStatementReturn(StatementReturn node, CloningDefinitionTreeVisitorContext context)
        {
            context.Result = new StatementReturn()
            {
                Expression = this.CloneNode(node.Expression, context)
            };
        }

        public override void VisitTypeReferenceId(TypeReferenceId node, CloningDefinitionTreeVisitorContext context)
        {
            context.Result = new TypeReferenceId()
            {
                ReferenceKey = node.ReferenceKey
            };
        }

        public TNode CloneNode<TNode>(TNode node) where TNode : Node
        {
            return this.CloneNode(node, new CloningDefinitionTreeVisitorContext());
        }

        private TNode CloneNode<TNode>(TNode node, CloningDefinitionTreeVisitorContext context) where TNode : Node
        {
            this.Visit(node, context);
            return context.Result != null ? (TNode)context.Result : null;
        }

        private void CloneNodeCollection<TNode>(BuilderNodeCollection<TNode> source, BuilderNodeCollection<TNode> target, CloningDefinitionTreeVisitorContext context) where TNode : Node
        {
            foreach (var node in source)
            {
                target.Add(this.CloneNode(node, context));
            }
        }

        private void CloneList<TItem>(List<TItem> source, List<TItem> target)
        {
            foreach (var item in source)
            {
                target.Add(item);
            }
        }
    }
}
