using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class ModelConverter
    {
        public ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode ConvertFromNode(ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INode node)
        {
            if (node == null)
                return null;
            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ModuleBlock)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ModuleBlock)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StModuleBlock((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement>(concreteNode.statements));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.Identifier)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (System.String)concreteNode.escapedText, (System.Nullable<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind>)concreteNode.originalKeywordKind, (System.Nullable<System.Boolean>)concreteNode.isInJSDocNamespace);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TypeLiteral)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeLiteralNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeLiteralNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeElement>(concreteNode.members));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.MappedType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.MappedTypeNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMappedTypeNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode)this.ConvertFromNode(concreteNode.readonlyToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration)this.ConvertFromNode(concreteNode.typeParameter), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode)this.ConvertFromNode(concreteNode.questionToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.StringLiteral)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.StringLiteral)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StStringLiteral((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (System.String)concreteNode.text, (System.Nullable<System.Boolean>)concreteNode.isUnterminated, (System.Nullable<System.Boolean>)concreteNode.hasExtendedUnicodeEscape);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NullKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NullLiteral)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNullLiteral((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TrueKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BooleanLiteralTrueKeyword)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBooleanLiteralTrueKeyword((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.FalseKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BooleanLiteralFalseKeyword)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBooleanLiteralFalseKeyword((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.BinaryExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BinaryExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBinaryExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.left), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStBinaryOperatorToken)this.ConvertFromNode(concreteNode.operatorToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.right));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ArrowFunction)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ArrowFunction)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrowFunction((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName)this.ConvertFromNode(concreteNode.name), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(concreteNode.typeParameters), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration>(concreteNode.parameters), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsGreaterThanTokenToken)this.ConvertFromNode(concreteNode.equalsGreaterThanToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken)this.ConvertFromNode(concreteNode.asteriskToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken)this.ConvertFromNode(concreteNode.questionToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken)this.ConvertFromNode(concreteNode.exclamationToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStConciseBody)this.ConvertFromNode(concreteNode.body));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NoSubstitutionTemplateLiteral)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NoSubstitutionTemplateLiteral)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNoSubstitutionTemplateLiteral((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (System.String)concreteNode.text, (System.Nullable<System.Boolean>)concreteNode.isUnterminated, (System.Nullable<System.Boolean>)concreteNode.hasExtendedUnicodeEscape, (System.String)concreteNode.rawText);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NumericLiteral)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NumericLiteral)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNumericLiteral((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (System.String)concreteNode.text, (System.Nullable<System.Boolean>)concreteNode.isUnterminated, (System.Nullable<System.Boolean>)concreteNode.hasExtendedUnicodeEscape);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.CallExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CallExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression)this.ConvertFromNode(concreteNode.expression), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionDotTokenToken)this.ConvertFromNode(concreteNode.questionDotToken), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode>(concreteNode.typeArguments), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression>(concreteNode.arguments));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NewExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NewExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNewExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression)this.ConvertFromNode(concreteNode.expression), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode>(concreteNode.typeArguments), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression>(concreteNode.arguments));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.VariableStatement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.VariableStatement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableStatement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclarationList)this.ConvertFromNode(concreteNode.declarationList));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ExpressionStatement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExpressionStatement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExpressionStatement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.LabeledStatement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.LabeledStatement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLabeledStatement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.label), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement)this.ConvertFromNode(concreteNode.statement));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocEnumTag)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocEnumTag)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocEnumTag((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.tagName), (System.String)concreteNode.comment, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression)this.ConvertFromNode(concreteNode.typeExpression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocTypedefTag)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocTypedefTag)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypedefTag((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.tagName), (System.String)concreteNode.comment, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.name), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode)this.ConvertFromNode(concreteNode.fullName), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.typeExpression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocCallbackTag)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocCallbackTag)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocCallbackTag((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.tagName), (System.String)concreteNode.comment, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.name), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode)this.ConvertFromNode(concreteNode.fullName), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature)this.ConvertFromNode(concreteNode.typeExpression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocSignature)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocSignature)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocSignature((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTemplateTag>(concreteNode.typeParameters), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocParameterTag>(concreteNode.parameters), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag)this.ConvertFromNode(concreteNode.type));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.Parameter)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ParameterDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStBindingName)this.ConvertFromNode(concreteNode.name), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDotDotDotTokenToken)this.ConvertFromNode(concreteNode.dotDotDotToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken)this.ConvertFromNode(concreteNode.questionToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.initializer));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.FunctionDeclaration)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.FunctionDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName)this.ConvertFromNode(concreteNode.name), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(concreteNode.typeParameters), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration>(concreteNode.parameters), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock)this.ConvertFromNode(concreteNode.body), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken)this.ConvertFromNode(concreteNode.asteriskToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken)this.ConvertFromNode(concreteNode.questionToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken)this.ConvertFromNode(concreteNode.exclamationToken));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.AnyKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeAnyKeyword)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StKeywordTypeNodeAnyKeyword((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.UnknownKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeUnknownKeyword)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StKeywordTypeNodeUnknownKeyword((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NumberKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeNumberKeyword)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StKeywordTypeNodeNumberKeyword((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.BigIntKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeBigIntKeyword)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StKeywordTypeNodeBigIntKeyword((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ObjectKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeObjectKeyword)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StKeywordTypeNodeObjectKeyword((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.BooleanKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeBooleanKeyword)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StKeywordTypeNodeBooleanKeyword((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.StringKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeStringKeyword)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StKeywordTypeNodeStringKeyword((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.SymbolKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeSymbolKeyword)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StKeywordTypeNodeSymbolKeyword((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.VoidKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeVoidKeyword)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StKeywordTypeNodeVoidKeyword((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.UndefinedKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeUndefinedKeyword)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StKeywordTypeNodeUndefinedKeyword((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NullKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeNullKeyword)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StKeywordTypeNodeNullKeyword((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NeverKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeNeverKeyword)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StKeywordTypeNodeNeverKeyword((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ThisKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ThisExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StThisExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PropertyAccessExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PropertyAccessExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAccessExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName)this.ConvertFromNode(concreteNode.name), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression)this.ConvertFromNode(concreteNode.expression), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionDotTokenToken)this.ConvertFromNode(concreteNode.questionDotToken));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ClassDeclaration)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ClassDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.name), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(concreteNode.typeParameters), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause>(concreteNode.heritageClauses), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStClassElement>(concreteNode.members));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.InterfaceDeclaration)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.InterfaceDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInterfaceDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.name), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(concreteNode.typeParameters), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause>(concreteNode.heritageClauses), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeElement>(concreteNode.members));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TypeAliasDeclaration)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeAliasDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeAliasDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.name), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(concreteNode.typeParameters), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.EnumMember)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.EnumMember)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEnumMember((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName)this.ConvertFromNode(concreteNode.name), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.initializer));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.EnumDeclaration)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.EnumDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEnumDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.name), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEnumMember>(concreteNode.members));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ModuleDeclaration)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ModuleDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StModuleDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModuleName)this.ConvertFromNode(concreteNode.name), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode)this.ConvertFromNode(concreteNode.body));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ImportEqualsDeclaration)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ImportEqualsDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportEqualsDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.name), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModuleReference)this.ConvertFromNode(concreteNode.moduleReference));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ExportDeclaration)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExportDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName)this.ConvertFromNode(concreteNode.name), (System.Boolean)concreteNode.isTypeOnly, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNamedExportBindings)this.ConvertFromNode(concreteNode.exportClause), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.moduleSpecifier));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocFunctionType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocFunctionType)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocFunctionType((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName)this.ConvertFromNode(concreteNode.name), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(concreteNode.typeParameters), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration>(concreteNode.parameters), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.CallSignature)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CallSignatureDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCallSignatureDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName)this.ConvertFromNode(concreteNode.name), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(concreteNode.typeParameters), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration>(concreteNode.parameters), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type), (System.Object)concreteNode._typeElementBrand, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken)this.ConvertFromNode(concreteNode.questionToken));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ConstructSignature)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ConstructSignatureDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConstructSignatureDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName)this.ConvertFromNode(concreteNode.name), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(concreteNode.typeParameters), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration>(concreteNode.parameters), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type), (System.Object)concreteNode._typeElementBrand, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken)this.ConvertFromNode(concreteNode.questionToken));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PropertySignature)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PropertySignature)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertySignature((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName)this.ConvertFromNode(concreteNode.name), (System.Object)concreteNode._typeElementBrand, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken)this.ConvertFromNode(concreteNode.questionToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.initializer));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PropertyDeclaration)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PropertyDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName)this.ConvertFromNode(concreteNode.name), (System.Object)concreteNode._classElementBrand, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken)this.ConvertFromNode(concreteNode.questionToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken)this.ConvertFromNode(concreteNode.exclamationToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.initializer));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PropertyAssignment)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PropertyAssignment)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPropertyAssignment((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName)this.ConvertFromNode(concreteNode.name), (System.Object)concreteNode._objectLiteralBrand, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken)this.ConvertFromNode(concreteNode.questionToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.initializer));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ShorthandPropertyAssignment)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ShorthandPropertyAssignment)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StShorthandPropertyAssignment((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.name), (System.Object)concreteNode._objectLiteralBrand, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken)this.ConvertFromNode(concreteNode.questionToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken)this.ConvertFromNode(concreteNode.exclamationToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsTokenToken)this.ConvertFromNode(concreteNode.equalsToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.objectAssignmentInitializer));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.SpreadAssignment)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SpreadAssignment)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSpreadAssignment((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName)this.ConvertFromNode(concreteNode.name), (System.Object)concreteNode._objectLiteralBrand, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.MethodSignature)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.MethodSignature)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodSignature((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName)this.ConvertFromNode(concreteNode.name), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(concreteNode.typeParameters), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration>(concreteNode.parameters), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type), (System.Object)concreteNode._typeElementBrand, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken)this.ConvertFromNode(concreteNode.questionToken));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.MethodDeclaration)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.MethodDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMethodDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName)this.ConvertFromNode(concreteNode.name), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(concreteNode.typeParameters), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration>(concreteNode.parameters), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type), (System.Object)concreteNode._classElementBrand, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken)this.ConvertFromNode(concreteNode.asteriskToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken)this.ConvertFromNode(concreteNode.questionToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken)this.ConvertFromNode(concreteNode.exclamationToken), (System.Object)concreteNode._objectLiteralBrand, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock)this.ConvertFromNode(concreteNode.body));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.Constructor)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ConstructorDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConstructorDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName)this.ConvertFromNode(concreteNode.name), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(concreteNode.typeParameters), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration>(concreteNode.parameters), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type), (System.Object)concreteNode._classElementBrand, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken)this.ConvertFromNode(concreteNode.asteriskToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken)this.ConvertFromNode(concreteNode.questionToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken)this.ConvertFromNode(concreteNode.exclamationToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock)this.ConvertFromNode(concreteNode.body));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.GetAccessor)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.GetAccessorDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGetAccessorDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName)this.ConvertFromNode(concreteNode.name), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(concreteNode.typeParameters), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration>(concreteNode.parameters), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type), (System.Object)concreteNode._classElementBrand, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken)this.ConvertFromNode(concreteNode.asteriskToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken)this.ConvertFromNode(concreteNode.questionToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken)this.ConvertFromNode(concreteNode.exclamationToken), (System.Object)concreteNode._objectLiteralBrand, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock)this.ConvertFromNode(concreteNode.body));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.SetAccessor)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SetAccessorDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSetAccessorDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName)this.ConvertFromNode(concreteNode.name), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(concreteNode.typeParameters), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration>(concreteNode.parameters), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type), (System.Object)concreteNode._classElementBrand, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken)this.ConvertFromNode(concreteNode.asteriskToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken)this.ConvertFromNode(concreteNode.questionToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken)this.ConvertFromNode(concreteNode.exclamationToken), (System.Object)concreteNode._objectLiteralBrand, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock)this.ConvertFromNode(concreteNode.body));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.IndexSignature)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IndexSignatureDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIndexSignatureDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName)this.ConvertFromNode(concreteNode.name), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(concreteNode.typeParameters), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration>(concreteNode.parameters), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type), (System.Object)concreteNode._classElementBrand, (System.Object)concreteNode._typeElementBrand, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken)this.ConvertFromNode(concreteNode.questionToken));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ClassExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ClassExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StClassExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.name), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(concreteNode.typeParameters), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause>(concreteNode.heritageClauses), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStClassElement>(concreteNode.members));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.FunctionExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.FunctionExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName)this.ConvertFromNode(concreteNode.name), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(concreteNode.typeParameters), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration>(concreteNode.parameters), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock)this.ConvertFromNode(concreteNode.body), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken)this.ConvertFromNode(concreteNode.asteriskToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken)this.ConvertFromNode(concreteNode.questionToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken)this.ConvertFromNode(concreteNode.exclamationToken));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ParenthesizedExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ParenthesizedExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParenthesizedExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.QualifiedName)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.QualifiedName)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQualifiedName((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName)this.ConvertFromNode(concreteNode.left), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.right));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ComputedPropertyName)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ComputedPropertyName)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StComputedPropertyName((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PrivateIdentifier)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PrivateIdentifier)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrivateIdentifier((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (System.String)concreteNode.escapedText);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.Decorator)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.VariableDeclarationList)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.VariableDeclarationList)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclarationList((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclaration>(concreteNode.declarations));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ObjectBindingPattern)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ObjectBindingPattern)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StObjectBindingPattern((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBindingElement>(concreteNode.elements));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ArrayBindingPattern)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ArrayBindingPattern)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrayBindingPattern((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStArrayBindingElement>(concreteNode.elements));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TemplateSpan)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TemplateSpan)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateSpan((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTemplateLiteralLikeNode)this.ConvertFromNode(concreteNode.literal));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxClosingElement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxClosingElement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxClosingElement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxTagNameExpression)this.ConvertFromNode(concreteNode.tagName));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.CaseBlock)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CaseBlock)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseBlock((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStCaseOrDefaultClause>(concreteNode.clauses));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.CaseClause)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CaseClause)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseClause((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement>(concreteNode.statements));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.DefaultClause)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.DefaultClause)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDefaultClause((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement>(concreteNode.statements));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.CatchClause)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CatchClause)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclaration)this.ConvertFromNode(concreteNode.variableDeclaration), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock)this.ConvertFromNode(concreteNode.block));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.HeritageClause)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.HeritageClause)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StHeritageClause((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind)concreteNode.token, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExpressionWithTypeArguments>(concreteNode.types));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ExternalModuleReference)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExternalModuleReference)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExternalModuleReference((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NamedImports)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NamedImports)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedImports((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportSpecifier>(concreteNode.elements));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NamedExports)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NamedExports)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamedExports((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportSpecifier>(concreteNode.elements));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocComment)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDoc)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDoc((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJSDocTag>(concreteNode.tags), (System.String)concreteNode.comment);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.InputFiles)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.InputFiles)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInputFiles((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (System.String)concreteNode.javascriptPath, (System.String)concreteNode.javascriptText, (System.String)concreteNode.javascriptMapPath, (System.String)concreteNode.javascriptMapText, (System.String)concreteNode.declarationPath, (System.String)concreteNode.declarationText, (System.String)concreteNode.declarationMapPath, (System.String)concreteNode.declarationMapText);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ThisType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ThisTypeNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StThisTypeNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TypePredicate)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypePredicateNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypePredicateNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAssertsKeywordToken)this.ConvertFromNode(concreteNode.assertsModifier), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode)this.ConvertFromNode(concreteNode.parameterName), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TypeQuery)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeQueryNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeQueryNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName)this.ConvertFromNode(concreteNode.exprName));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ArrayType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ArrayTypeNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrayTypeNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.elementType));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TupleType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TupleTypeNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTupleTypeNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode>(concreteNode.elementTypes));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.OptionalType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.OptionalTypeNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StOptionalTypeNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.RestType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.RestTypeNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StRestTypeNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.UnionType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.UnionTypeNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StUnionTypeNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode>(concreteNode.types));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.IntersectionType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IntersectionTypeNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIntersectionTypeNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode>(concreteNode.types));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ConditionalType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ConditionalTypeNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalTypeNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.checkType), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.extendsType), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.trueType), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.falseType));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.InferType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.InferTypeNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInferTypeNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration)this.ConvertFromNode(concreteNode.typeParameter));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ParenthesizedType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ParenthesizedTypeNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParenthesizedTypeNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TypeOperator)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeOperatorNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeOperatorNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind)concreteNode.@operator, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.IndexedAccessType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IndexedAccessTypeNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIndexedAccessTypeNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.objectType), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.indexType));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.LiteralType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.LiteralTypeNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLiteralTypeNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode)this.ConvertFromNode(concreteNode.literal));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.OmittedExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.OmittedExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StOmittedExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.YieldExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.YieldExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StYieldExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken)this.ConvertFromNode(concreteNode.asteriskToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ConditionalExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ConditionalExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConditionalExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.condition), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken)this.ConvertFromNode(concreteNode.questionToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.whenTrue), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StColonTokenToken)this.ConvertFromNode(concreteNode.colonToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.whenFalse));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.SpreadElement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SpreadElement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSpreadElement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.AsExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AsExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxOpeningElement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxOpeningElement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxTagNameExpression)this.ConvertFromNode(concreteNode.tagName), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode>(concreteNode.typeArguments), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttributes)this.ConvertFromNode(concreteNode.attributes));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxOpeningFragment)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxOpeningFragment)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningFragment((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxClosingFragment)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxClosingFragment)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxClosingFragment((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDotDotDotTokenToken)this.ConvertFromNode(concreteNode.dotDotDotToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxText)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxText)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxText((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (System.String)concreteNode.text, (System.Nullable<System.Boolean>)concreteNode.isUnterminated, (System.Nullable<System.Boolean>)concreteNode.hasExtendedUnicodeEscape, (System.Boolean)concreteNode.containsOnlyTriviaWhiteSpaces);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.CommaListExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CommaListExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCommaListExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression>(concreteNode.elements));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.EmptyStatement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.EmptyStatement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEmptyStatement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.DebuggerStatement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.DebuggerStatement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDebuggerStatement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.Block)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Block)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement>(concreteNode.statements));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.IfStatement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IfStatement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIfStatement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement)this.ConvertFromNode(concreteNode.thenStatement), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement)this.ConvertFromNode(concreteNode.elseStatement));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.BreakStatement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BreakStatement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBreakStatement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.label));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ContinueStatement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ContinueStatement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StContinueStatement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.label));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ReturnStatement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ReturnStatement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StReturnStatement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.WithStatement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.WithStatement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWithStatement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement)this.ConvertFromNode(concreteNode.statement));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.SwitchStatement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SwitchStatement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSwitchStatement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaseBlock)this.ConvertFromNode(concreteNode.caseBlock), (System.Nullable<System.Boolean>)concreteNode.possiblyExhaustive);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ThrowStatement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ThrowStatement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StThrowStatement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TryStatement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TryStatement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTryStatement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock)this.ConvertFromNode(concreteNode.tryBlock), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCatchClause)this.ConvertFromNode(concreteNode.catchClause), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBlock)this.ConvertFromNode(concreteNode.finallyBlock));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ImportDeclaration)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ImportDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportClause)this.ConvertFromNode(concreteNode.importClause), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.moduleSpecifier));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocTypeExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocTypeExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocTag)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocUnknownTag)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocUnknownTag((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.tagName), (System.String)concreteNode.comment);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocAuthorTag)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocAuthorTag)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocAuthorTag((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.tagName), (System.String)concreteNode.comment);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocClassTag)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocClassTag)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocClassTag((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.tagName), (System.String)concreteNode.comment);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocPublicTag)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocPublicTag)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocPublicTag((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.tagName), (System.String)concreteNode.comment);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocPrivateTag)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocPrivateTag)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocPrivateTag((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.tagName), (System.String)concreteNode.comment);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocProtectedTag)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocProtectedTag)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocProtectedTag((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.tagName), (System.String)concreteNode.comment);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocReadonlyTag)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocReadonlyTag)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReadonlyTag((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.tagName), (System.String)concreteNode.comment);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocThisTag)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocThisTag)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocThisTag((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.tagName), (System.String)concreteNode.comment, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression)this.ConvertFromNode(concreteNode.typeExpression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocTemplateTag)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocTemplateTag)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTemplateTag((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.tagName), (System.String)concreteNode.comment, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression)this.ConvertFromNode(concreteNode.constraint), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(concreteNode.typeParameters));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocReturnTag)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocReturnTag)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocReturnTag((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.tagName), (System.String)concreteNode.comment, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression)this.ConvertFromNode(concreteNode.typeExpression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocTypeTag)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocTypeTag)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeTag((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.tagName), (System.String)concreteNode.comment, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression)this.ConvertFromNode(concreteNode.typeExpression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TypeParameter)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeParameterDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.name), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.constraint), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.@default), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.VariableDeclaration)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.VariableDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVariableDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStBindingName)this.ConvertFromNode(concreteNode.name), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken)this.ConvertFromNode(concreteNode.exclamationToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.initializer));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.BindingElement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BindingElement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBindingElement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStBindingName)this.ConvertFromNode(concreteNode.name), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName)this.ConvertFromNode(concreteNode.propertyName), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDotDotDotTokenToken)this.ConvertFromNode(concreteNode.dotDotDotToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.initializer));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ImportType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ImportTypeNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportTypeNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode>(concreteNode.typeArguments), (System.Nullable<System.Boolean>)concreteNode.isTypeOf, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.argument), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName)this.ConvertFromNode(concreteNode.qualifier));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.FunctionType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.FunctionTypeNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StFunctionTypeNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName)this.ConvertFromNode(concreteNode.name), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(concreteNode.typeParameters), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration>(concreteNode.parameters), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ConstructorType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ConstructorTypeNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConstructorTypeNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStPropertyName)this.ConvertFromNode(concreteNode.name), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeParameterDeclaration>(concreteNode.typeParameters), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StParameterDeclaration>(concreteNode.parameters), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TypeReference)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeReferenceNode)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeReferenceNode((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode>(concreteNode.typeArguments), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName)this.ConvertFromNode(concreteNode.typeName));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.DeleteExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.DeleteExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDeleteExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TypeOfExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeOfExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeOfExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.VoidExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.VoidExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StVoidExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.AwaitExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AwaitExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAwaitExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.RegularExpressionLiteral)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.RegularExpressionLiteral)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StRegularExpressionLiteral((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (System.String)concreteNode.text, (System.Nullable<System.Boolean>)concreteNode.isUnterminated, (System.Nullable<System.Boolean>)concreteNode.hasExtendedUnicodeEscape);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.BigIntLiteral)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BigIntLiteral)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBigIntLiteral((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (System.String)concreteNode.text, (System.Nullable<System.Boolean>)concreteNode.isUnterminated, (System.Nullable<System.Boolean>)concreteNode.hasExtendedUnicodeEscape);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TemplateHead)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TemplateHead)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (System.String)concreteNode.text, (System.Nullable<System.Boolean>)concreteNode.isUnterminated, (System.Nullable<System.Boolean>)concreteNode.hasExtendedUnicodeEscape, (System.String)concreteNode.rawText);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TemplateMiddle)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TemplateMiddle)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateMiddle((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (System.String)concreteNode.text, (System.Nullable<System.Boolean>)concreteNode.isUnterminated, (System.Nullable<System.Boolean>)concreteNode.hasExtendedUnicodeEscape, (System.String)concreteNode.rawText);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TemplateTail)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TemplateTail)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateTail((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (System.String)concreteNode.text, (System.Nullable<System.Boolean>)concreteNode.isUnterminated, (System.Nullable<System.Boolean>)concreteNode.hasExtendedUnicodeEscape, (System.String)concreteNode.rawText);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ObjectLiteralExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ObjectLiteralExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StObjectLiteralExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStObjectLiteralElementLike>(concreteNode.properties));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ExpressionWithTypeArguments)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExpressionWithTypeArguments)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExpressionWithTypeArguments((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode>(concreteNode.typeArguments), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TypeAssertionExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeAssertion)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTypeAssertion((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxAttributes)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxAttributes)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttributes((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxAttributeLike>(concreteNode.properties));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.DoStatement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.DoStatement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDoStatement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement)this.ConvertFromNode(concreteNode.statement), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.WhileStatement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.WhileStatement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StWhileStatement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement)this.ConvertFromNode(concreteNode.statement), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ForStatement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ForStatement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForStatement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement)this.ConvertFromNode(concreteNode.statement), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStForInitializer)this.ConvertFromNode(concreteNode.initializer), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.condition), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.incrementor));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ForInStatement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ForInStatement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForInStatement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement)this.ConvertFromNode(concreteNode.statement), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStForInitializer)this.ConvertFromNode(concreteNode.initializer), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ForOfStatement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ForOfStatement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StForOfStatement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStStatement)this.ConvertFromNode(concreteNode.statement), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAwaitKeywordToken)this.ConvertFromNode(concreteNode.awaitModifier), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStForInitializer)this.ConvertFromNode(concreteNode.initializer), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ImportClause)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ImportClause)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportClause((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.name), (System.Boolean)concreteNode.isTypeOnly, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNamedImportBindings)this.ConvertFromNode(concreteNode.namedBindings));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NamespaceImport)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NamespaceImport)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamespaceImport((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.name));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NamespaceExport)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NamespaceExport)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamespaceExport((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.name));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NamespaceExportDeclaration)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NamespaceExportDeclaration)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNamespaceExportDeclaration((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.name));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ImportSpecifier)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ImportSpecifier)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportSpecifier((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.name), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.propertyName));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ExportSpecifier)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExportSpecifier)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportSpecifier((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.name), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.propertyName));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ExportAssignment)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExportAssignment)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportAssignment((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName)this.ConvertFromNode(concreteNode.name), (System.Nullable<System.Boolean>)concreteNode.isExportEquals, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocAllType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocAllType)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocAllType((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocUnknownType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocUnknownType)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocUnknownType((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocNonNullableType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocNonNullableType)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocNonNullableType((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocNullableType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocNullableType)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocNullableType((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocOptionalType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocOptionalType)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocOptionalType((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocVariadicType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocVariadicType)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocVariadicType((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocNamepathType)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocNamepathType)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocNamepathType((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode)this.ConvertFromNode(concreteNode.type));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocPropertyTag)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocPropertyTag)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocPropertyTag((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.tagName), (System.String)concreteNode.comment, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName)this.ConvertFromNode(concreteNode.name), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression)this.ConvertFromNode(concreteNode.typeExpression), (System.Boolean)concreteNode.isNameFirst, (System.Boolean)concreteNode.isBracketed);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocParameterTag)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocParameterTag)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocParameterTag((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.tagName), (System.String)concreteNode.comment, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStEntityName)this.ConvertFromNode(concreteNode.name), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeExpression)this.ConvertFromNode(concreteNode.typeExpression), (System.Boolean)concreteNode.isNameFirst, (System.Boolean)concreteNode.isBracketed);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JSDocTypeLiteral)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocTypeLiteral)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocTypeLiteral((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJSDocPropertyLikeTag>(concreteNode.jsDocPropertyTags), (System.Nullable<System.Boolean>)concreteNode.isArrayType);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.SemicolonClassElement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SemicolonClassElement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSemicolonClassElement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName)this.ConvertFromNode(concreteNode.name), (System.Object)concreteNode._classElementBrand);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PrefixUnaryExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PrefixUnaryExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrefixUnaryExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind)concreteNode.@operator, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression)this.ConvertFromNode(concreteNode.operand));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PostfixUnaryExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PostfixUnaryExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPostfixUnaryExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression)this.ConvertFromNode(concreteNode.operand), (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind)concreteNode.@operator);
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxAttribute)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxAttribute)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttribute((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.name), (System.Object)concreteNode._objectLiteralBrand, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode)this.ConvertFromNode(concreteNode.initializer));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxSpreadAttribute)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxSpreadAttribute)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSpreadAttribute((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStDeclarationName)this.ConvertFromNode(concreteNode.name), (System.Object)concreteNode._objectLiteralBrand, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.NonNullExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NonNullExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StNonNullExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.expression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PrefixUnaryExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsonMinusNumericLiteral)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsonMinusNumericLiteral((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind)concreteNode.@operator, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStUnaryExpression)this.ConvertFromNode(concreteNode.operand));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ElementAccessExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ElementAccessExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StElementAccessExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression)this.ConvertFromNode(concreteNode.expression), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionDotTokenToken)this.ConvertFromNode(concreteNode.questionDotToken), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression)this.ConvertFromNode(concreteNode.argumentExpression));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TaggedTemplateExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TaggedTemplateExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTaggedTemplateExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStLeftHandSideExpression)this.ConvertFromNode(concreteNode.tag), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode>(concreteNode.typeArguments), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTemplateLiteral)this.ConvertFromNode(concreteNode.template));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.SuperKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SuperExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSuperExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ImportKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ImportExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StImportExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.TemplateExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TemplateExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateHead)this.ConvertFromNode(concreteNode.head), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StTemplateSpan>(concreteNode.templateSpans));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ArrayLiteralExpression)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ArrayLiteralExpression)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StArrayLiteralExpression((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStExpression>(concreteNode.elements));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.MetaProperty)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.MetaProperty)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMetaProperty((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind)concreteNode.keywordToken, (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StIdentifier)this.ConvertFromNode(concreteNode.name));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxElement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxElement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxElement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningElement)this.ConvertFromNode(concreteNode.openingElement), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxChild>(concreteNode.children), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxClosingElement)this.ConvertFromNode(concreteNode.closingElement));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxSelfClosingElement)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxSelfClosingElement)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxSelfClosingElement((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxTagNameExpression)this.ConvertFromNode(concreteNode.tagName), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStTypeNode>(concreteNode.typeArguments), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxAttributes)this.ConvertFromNode(concreteNode.attributes));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.JsxFragment)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxFragment)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxFragment((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxOpeningFragment)this.ConvertFromNode(concreteNode.openingFragment), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStJsxChild>(concreteNode.children), (ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StJsxClosingFragment)this.ConvertFromNode(concreteNode.closingFragment));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.AbstractKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AbstractKeywordToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAbstractKeywordToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.AsyncKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AsyncKeywordToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsyncKeywordToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ConstKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ConstKeywordToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StConstKeywordToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.DeclareKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.DeclareKeywordToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDeclareKeywordToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.DefaultKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.DefaultKeywordToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDefaultKeywordToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ExportKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExportKeywordToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExportKeywordToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PublicKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PublicKeywordToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPublicKeywordToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PrivateKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PrivateKeywordToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPrivateKeywordToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ProtectedKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ProtectedKeywordToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StProtectedKeywordToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ReadonlyKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ReadonlyKeywordToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StReadonlyKeywordToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.StaticKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.StaticKeywordToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StStaticKeywordToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PlusToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PlusTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPlusTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.MinusToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.MinusTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMinusTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.QuestionToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.QuestionTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.QuestionQuestionToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.QuestionQuestionTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionQuestionTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.AsteriskAsteriskToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AsteriskAsteriskTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskAsteriskTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.AsteriskToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AsteriskTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.SlashToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SlashTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSlashTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PercentToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PercentTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPercentTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.LessThanLessThanToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.LessThanLessThanTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLessThanLessThanTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.GreaterThanGreaterThanToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.GreaterThanGreaterThanTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGreaterThanGreaterThanTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.GreaterThanGreaterThanGreaterThanToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.GreaterThanGreaterThanGreaterThanTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGreaterThanGreaterThanGreaterThanTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.LessThanToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.LessThanTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLessThanTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.LessThanEqualsToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.LessThanEqualsTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLessThanEqualsTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.GreaterThanToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.GreaterThanTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGreaterThanTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.GreaterThanEqualsToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.GreaterThanEqualsTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGreaterThanEqualsTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.InstanceOfKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.InstanceOfKeywordToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInstanceOfKeywordToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.InKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.InKeywordToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StInKeywordToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.EqualsEqualsToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.EqualsEqualsTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsEqualsTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.EqualsEqualsEqualsToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.EqualsEqualsEqualsTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsEqualsEqualsTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ExclamationEqualsEqualsToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExclamationEqualsEqualsTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationEqualsEqualsTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ExclamationEqualsToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExclamationEqualsTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationEqualsTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.AmpersandToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AmpersandTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAmpersandTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.BarToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BarTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBarTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.CaretToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CaretTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaretTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.AmpersandAmpersandToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AmpersandAmpersandTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAmpersandAmpersandTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.BarBarToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BarBarTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBarBarTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.EqualsToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.EqualsTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PlusEqualsToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PlusEqualsTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPlusEqualsTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.MinusEqualsToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.MinusEqualsTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StMinusEqualsTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.AsteriskAsteriskEqualsToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AsteriskAsteriskEqualsTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskAsteriskEqualsTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.AsteriskEqualsToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AsteriskEqualsTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAsteriskEqualsTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.SlashEqualsToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SlashEqualsTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StSlashEqualsTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.PercentEqualsToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PercentEqualsTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StPercentEqualsTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.AmpersandEqualsToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AmpersandEqualsTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAmpersandEqualsTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.BarEqualsToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BarEqualsTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StBarEqualsTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.CaretEqualsToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CaretEqualsTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCaretEqualsTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.LessThanLessThanEqualsToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.LessThanLessThanEqualsTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StLessThanLessThanEqualsTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.GreaterThanGreaterThanGreaterThanEqualsToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.GreaterThanGreaterThanGreaterThanEqualsTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGreaterThanGreaterThanGreaterThanEqualsTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.GreaterThanGreaterThanEqualsToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.GreaterThanGreaterThanEqualsTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StGreaterThanGreaterThanEqualsTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.CommaToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CommaTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StCommaTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ExclamationToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExclamationTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StExclamationTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.EqualsGreaterThanToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.EqualsGreaterThanTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StEqualsGreaterThanTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.QuestionDotToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.QuestionDotTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StQuestionDotTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.DotDotDotToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.DotDotDotTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDotDotDotTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.AssertsKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AssertsKeywordToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAssertsKeywordToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.ColonToken)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ColonTokenToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StColonTokenToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            if (node.kind == ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SyntaxKind.AwaitKeyword)
            {
                var concreteNode = (ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AwaitKeywordToken)node;
                var result = new ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StAwaitKeywordToken((ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NodeFlags)concreteNode.flags, this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.StDecorator>(concreteNode.decorators), this.ConvertFromNodeCollection<ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStModifier>(concreteNode.modifiers));
                return result;
            }

            throw new System.InvalidOperationException("Unable to convert node.");
        }

        public System.Collections.Generic.List<T> ConvertFromNodeCollection<T>(System.Collections.Generic.IEnumerable<ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.INode> nodes)
            where T : ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel.IStNode
        {
            if (nodes == null)
                return null;
            System.Collections.Generic.List<T> result = new System.Collections.Generic.List<T>();
            foreach (var node in nodes)
            {
                result.Add((T)this.ConvertFromNode(node));
            }

            return result;
        }
    }
}