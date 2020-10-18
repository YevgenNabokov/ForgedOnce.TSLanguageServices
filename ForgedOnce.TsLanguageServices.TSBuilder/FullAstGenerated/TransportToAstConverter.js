"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const T = require("typescript");
class Converter {
    ConvertNode(node) {
        if (node == null) {
            return undefined;
        }
        if (node.kind == T.SyntaxKind.ModuleBlock) {
            var paramVar0 = this.ConvertNodes(node.statements);
            return T.createModuleBlock(paramVar0);
        }
        if (node.kind == T.SyntaxKind.Identifier) {
            return T.createIdentifier(node.escapedText);
        }
        if (node.kind == T.SyntaxKind.TypeLiteral) {
            var paramVar0 = this.ConvertNodes(node.members);
            return T.createTypeLiteralNode(paramVar0);
        }
        if (node.kind == T.SyntaxKind.MappedType) {
            var paramVar0 = this.ConvertNode(node.readonlyToken);
            var paramVar1 = this.ConvertNode(node.typeParameter);
            var paramVar2 = this.ConvertNode(node.questionToken);
            var paramVar3 = this.ConvertNode(node.type);
            return T.createMappedTypeNode(paramVar0, paramVar1, paramVar2, paramVar3);
        }
        if (node.kind == T.SyntaxKind.StringLiteral) {
            return T.createStringLiteral(node.text);
        }
        if (node.kind == T.SyntaxKind.NullKeyword) {
            return T.createNull();
        }
        if (node.kind == T.SyntaxKind.TrueKeyword) {
            return T.createTrue();
        }
        if (node.kind == T.SyntaxKind.FalseKeyword) {
            return T.createFalse();
        }
        if (node.kind == T.SyntaxKind.BinaryExpression) {
            var paramVar0 = this.ConvertNode(node.left);
            var paramVar1 = this.ConvertNode(node.operatorToken);
            var paramVar2 = this.ConvertNode(node.right);
            return T.createBinary(paramVar0, paramVar1, paramVar2);
        }
        if (node.kind == T.SyntaxKind.ArrowFunction) {
            var paramVar0 = this.ConvertNodes(node.modifiers);
            var paramVar1 = this.ConvertNodes(node.typeParameters);
            var paramVar2 = this.ConvertNodes(node.parameters);
            var paramVar3 = this.ConvertNode(node.type);
            var paramVar4 = this.ConvertNode(node.equalsGreaterThanToken);
            var paramVar5 = this.ConvertNode(node.body);
            return T.createArrowFunction(paramVar0, paramVar1, paramVar2, paramVar3, paramVar4, paramVar5);
        }
        if (node.kind == T.SyntaxKind.NoSubstitutionTemplateLiteral) {
            return T.createNoSubstitutionTemplateLiteral(node.text, node.rawText);
        }
        if (node.kind == T.SyntaxKind.NumericLiteral) {
            return T.createNumericLiteral(node.text, node.flags);
        }
        if (node.kind == T.SyntaxKind.CallExpression) {
            var paramVar0 = this.ConvertNode(node.expression);
            var paramVar1 = this.ConvertNodes(node.typeArguments);
            var paramVar2 = this.ConvertNodes(node.arguments);
            return T.createCall(paramVar0, paramVar1, paramVar2);
        }
        if (node.kind == T.SyntaxKind.NewExpression) {
            var paramVar0 = this.ConvertNode(node.expression);
            var paramVar1 = this.ConvertNodes(node.typeArguments);
            var paramVar2 = this.ConvertNodes(node.arguments);
            return T.createNew(paramVar0, paramVar1, paramVar2);
        }
        if (node.kind == T.SyntaxKind.VariableStatement) {
            var paramVar0 = this.ConvertNodes(node.modifiers);
            var paramVar1 = this.ConvertNode(node.declarationList);
            return T.createVariableStatement(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.ExpressionStatement) {
            var paramVar0 = this.ConvertNode(node.expression);
            return T.createExpressionStatement(paramVar0);
        }
        if (node.kind == T.SyntaxKind.LabeledStatement) {
            var paramVar0 = this.ConvertNode(node.label);
            var paramVar1 = this.ConvertNode(node.statement);
            return T.createLabel(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.Parameter) {
            var paramVar0 = this.ConvertNodes(node.decorators);
            var paramVar1 = this.ConvertNodes(node.modifiers);
            var paramVar2 = this.ConvertNode(node.dotDotDotToken);
            var paramVar3 = this.ConvertNode(node.name);
            var paramVar4 = this.ConvertNode(node.questionToken);
            var paramVar5 = this.ConvertNode(node.type);
            var paramVar6 = this.ConvertNode(node.initializer);
            return T.createParameter(paramVar0, paramVar1, paramVar2, paramVar3, paramVar4, paramVar5, paramVar6);
        }
        if (node.kind == T.SyntaxKind.FunctionDeclaration) {
            var paramVar0 = this.ConvertNodes(node.decorators);
            var paramVar1 = this.ConvertNodes(node.modifiers);
            var paramVar2 = this.ConvertNode(node.asteriskToken);
            var paramVar3 = this.ConvertNode(node.name);
            var paramVar4 = this.ConvertNodes(node.typeParameters);
            var paramVar5 = this.ConvertNodes(node.parameters);
            var paramVar6 = this.ConvertNode(node.type);
            var paramVar7 = this.ConvertNode(node.body);
            return T.createFunctionDeclaration(paramVar0, paramVar1, paramVar2, paramVar3, paramVar4, paramVar5, paramVar6, paramVar7);
        }
        if (node.kind == T.SyntaxKind.AnyKeyword) {
            return T.createKeywordTypeNode(node.kind);
        }
        if (node.kind == T.SyntaxKind.UnknownKeyword) {
            return T.createKeywordTypeNode(node.kind);
        }
        if (node.kind == T.SyntaxKind.NumberKeyword) {
            return T.createKeywordTypeNode(node.kind);
        }
        if (node.kind == T.SyntaxKind.BigIntKeyword) {
            return T.createKeywordTypeNode(node.kind);
        }
        if (node.kind == T.SyntaxKind.ObjectKeyword) {
            return T.createKeywordTypeNode(node.kind);
        }
        if (node.kind == T.SyntaxKind.BooleanKeyword) {
            return T.createKeywordTypeNode(node.kind);
        }
        if (node.kind == T.SyntaxKind.StringKeyword) {
            return T.createKeywordTypeNode(node.kind);
        }
        if (node.kind == T.SyntaxKind.SymbolKeyword) {
            return T.createKeywordTypeNode(node.kind);
        }
        if (node.kind == T.SyntaxKind.VoidKeyword) {
            return T.createKeywordTypeNode(node.kind);
        }
        if (node.kind == T.SyntaxKind.UndefinedKeyword) {
            return T.createKeywordTypeNode(node.kind);
        }
        if (node.kind == T.SyntaxKind.NullKeyword) {
            return T.createKeywordTypeNode(node.kind);
        }
        if (node.kind == T.SyntaxKind.NeverKeyword) {
            return T.createKeywordTypeNode(node.kind);
        }
        if (node.kind == T.SyntaxKind.ThisKeyword) {
            return T.createThis();
        }
        if (node.kind == T.SyntaxKind.PropertyAccessExpression) {
            var paramVar0 = this.ConvertNode(node.expression);
            var paramVar1 = this.ConvertNode(node.name);
            return T.createPropertyAccess(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.ClassDeclaration) {
            var paramVar0 = this.ConvertNodes(node.decorators);
            var paramVar1 = this.ConvertNodes(node.modifiers);
            var paramVar2 = this.ConvertNode(node.name);
            var paramVar3 = this.ConvertNodes(node.typeParameters);
            var paramVar4 = this.ConvertNodes(node.heritageClauses);
            var paramVar5 = this.ConvertNodes(node.members);
            return T.createClassDeclaration(paramVar0, paramVar1, paramVar2, paramVar3, paramVar4, paramVar5);
        }
        if (node.kind == T.SyntaxKind.InterfaceDeclaration) {
            var paramVar0 = this.ConvertNodes(node.decorators);
            var paramVar1 = this.ConvertNodes(node.modifiers);
            var paramVar2 = this.ConvertNode(node.name);
            var paramVar3 = this.ConvertNodes(node.typeParameters);
            var paramVar4 = this.ConvertNodes(node.heritageClauses);
            var paramVar5 = this.ConvertNodes(node.members);
            return T.createInterfaceDeclaration(paramVar0, paramVar1, paramVar2, paramVar3, paramVar4, paramVar5);
        }
        if (node.kind == T.SyntaxKind.TypeAliasDeclaration) {
            var paramVar0 = this.ConvertNodes(node.decorators);
            var paramVar1 = this.ConvertNodes(node.modifiers);
            var paramVar2 = this.ConvertNode(node.name);
            var paramVar3 = this.ConvertNodes(node.typeParameters);
            var paramVar4 = this.ConvertNode(node.type);
            return T.createTypeAliasDeclaration(paramVar0, paramVar1, paramVar2, paramVar3, paramVar4);
        }
        if (node.kind == T.SyntaxKind.EnumMember) {
            var paramVar0 = this.ConvertNode(node.name);
            var paramVar1 = this.ConvertNode(node.initializer);
            return T.createEnumMember(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.EnumDeclaration) {
            var paramVar0 = this.ConvertNodes(node.decorators);
            var paramVar1 = this.ConvertNodes(node.modifiers);
            var paramVar2 = this.ConvertNode(node.name);
            var paramVar3 = this.ConvertNodes(node.members);
            return T.createEnumDeclaration(paramVar0, paramVar1, paramVar2, paramVar3);
        }
        if (node.kind == T.SyntaxKind.ModuleDeclaration) {
            var paramVar0 = this.ConvertNodes(node.decorators);
            var paramVar1 = this.ConvertNodes(node.modifiers);
            var paramVar2 = this.ConvertNode(node.name);
            var paramVar3 = this.ConvertNode(node.body);
            return T.createModuleDeclaration(paramVar0, paramVar1, paramVar2, paramVar3, node.flags);
        }
        if (node.kind == T.SyntaxKind.ImportEqualsDeclaration) {
            var paramVar0 = this.ConvertNodes(node.decorators);
            var paramVar1 = this.ConvertNodes(node.modifiers);
            var paramVar2 = this.ConvertNode(node.name);
            var paramVar3 = this.ConvertNode(node.moduleReference);
            return T.createImportEqualsDeclaration(paramVar0, paramVar1, paramVar2, paramVar3);
        }
        if (node.kind == T.SyntaxKind.ExportDeclaration) {
            var paramVar0 = this.ConvertNodes(node.decorators);
            var paramVar1 = this.ConvertNodes(node.modifiers);
            var paramVar2 = this.ConvertNode(node.exportClause);
            var paramVar3 = this.ConvertNode(node.moduleSpecifier);
            return T.createExportDeclaration(paramVar0, paramVar1, paramVar2, paramVar3, node.isTypeOnly);
        }
        if (node.kind == T.SyntaxKind.CallSignature) {
            var paramVar0 = this.ConvertNodes(node.typeParameters);
            var paramVar1 = this.ConvertNodes(node.parameters);
            var paramVar2 = this.ConvertNode(node.type);
            return T.createCallSignature(paramVar0, paramVar1, paramVar2);
        }
        if (node.kind == T.SyntaxKind.ConstructSignature) {
            var paramVar0 = this.ConvertNodes(node.typeParameters);
            var paramVar1 = this.ConvertNodes(node.parameters);
            var paramVar2 = this.ConvertNode(node.type);
            return T.createConstructSignature(paramVar0, paramVar1, paramVar2);
        }
        if (node.kind == T.SyntaxKind.PropertySignature) {
            var paramVar0 = this.ConvertNodes(node.modifiers);
            var paramVar1 = this.ConvertNode(node.name);
            var paramVar2 = this.ConvertNode(node.questionToken);
            var paramVar3 = this.ConvertNode(node.type);
            var paramVar4 = this.ConvertNode(node.initializer);
            return T.createPropertySignature(paramVar0, paramVar1, paramVar2, paramVar3, paramVar4);
        }
        if (node.kind == T.SyntaxKind.PropertyDeclaration) {
            var paramVar0 = this.ConvertNodes(node.decorators);
            var paramVar1 = this.ConvertNodes(node.modifiers);
            var paramVar2 = this.ConvertNode(node.name);
            var paramVar3 = this.ConvertNode(node.questionToken);
            var paramVar4 = this.ConvertNode(node.type);
            var paramVar5 = this.ConvertNode(node.initializer);
            return T.createProperty(paramVar0, paramVar1, paramVar2, paramVar3, paramVar4, paramVar5);
        }
        if (node.kind == T.SyntaxKind.PropertyAssignment) {
            var paramVar0 = this.ConvertNode(node.name);
            var paramVar1 = this.ConvertNode(node.initializer);
            return T.createPropertyAssignment(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.ShorthandPropertyAssignment) {
            var paramVar0 = this.ConvertNode(node.name);
            var paramVar1 = this.ConvertNode(node.objectAssignmentInitializer);
            return T.createShorthandPropertyAssignment(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.SpreadAssignment) {
            var paramVar0 = this.ConvertNode(node.expression);
            return T.createSpreadAssignment(paramVar0);
        }
        if (node.kind == T.SyntaxKind.MethodSignature) {
            var paramVar0 = this.ConvertNodes(node.typeParameters);
            var paramVar1 = this.ConvertNodes(node.parameters);
            var paramVar2 = this.ConvertNode(node.type);
            var paramVar3 = this.ConvertNode(node.name);
            var paramVar4 = this.ConvertNode(node.questionToken);
            return T.createMethodSignature(paramVar0, paramVar1, paramVar2, paramVar3, paramVar4);
        }
        if (node.kind == T.SyntaxKind.MethodDeclaration) {
            var paramVar0 = this.ConvertNodes(node.decorators);
            var paramVar1 = this.ConvertNodes(node.modifiers);
            var paramVar2 = this.ConvertNode(node.asteriskToken);
            var paramVar3 = this.ConvertNode(node.name);
            var paramVar4 = this.ConvertNode(node.questionToken);
            var paramVar5 = this.ConvertNodes(node.typeParameters);
            var paramVar6 = this.ConvertNodes(node.parameters);
            var paramVar7 = this.ConvertNode(node.type);
            var paramVar8 = this.ConvertNode(node.body);
            return T.createMethod(paramVar0, paramVar1, paramVar2, paramVar3, paramVar4, paramVar5, paramVar6, paramVar7, paramVar8);
        }
        if (node.kind == T.SyntaxKind.Constructor) {
            var paramVar0 = this.ConvertNodes(node.decorators);
            var paramVar1 = this.ConvertNodes(node.modifiers);
            var paramVar2 = this.ConvertNodes(node.parameters);
            var paramVar3 = this.ConvertNode(node.body);
            return T.createConstructor(paramVar0, paramVar1, paramVar2, paramVar3);
        }
        if (node.kind == T.SyntaxKind.GetAccessor) {
            var paramVar0 = this.ConvertNodes(node.decorators);
            var paramVar1 = this.ConvertNodes(node.modifiers);
            var paramVar2 = this.ConvertNode(node.name);
            var paramVar3 = this.ConvertNodes(node.parameters);
            var paramVar4 = this.ConvertNode(node.type);
            var paramVar5 = this.ConvertNode(node.body);
            return T.createGetAccessor(paramVar0, paramVar1, paramVar2, paramVar3, paramVar4, paramVar5);
        }
        if (node.kind == T.SyntaxKind.SetAccessor) {
            var paramVar0 = this.ConvertNodes(node.decorators);
            var paramVar1 = this.ConvertNodes(node.modifiers);
            var paramVar2 = this.ConvertNode(node.name);
            var paramVar3 = this.ConvertNodes(node.parameters);
            var paramVar4 = this.ConvertNode(node.body);
            return T.createSetAccessor(paramVar0, paramVar1, paramVar2, paramVar3, paramVar4);
        }
        if (node.kind == T.SyntaxKind.IndexSignature) {
            var paramVar0 = this.ConvertNodes(node.decorators);
            var paramVar1 = this.ConvertNodes(node.modifiers);
            var paramVar2 = this.ConvertNodes(node.parameters);
            var paramVar3 = this.ConvertNode(node.type);
            return T.createIndexSignature(paramVar0, paramVar1, paramVar2, paramVar3);
        }
        if (node.kind == T.SyntaxKind.ClassExpression) {
            var paramVar0 = this.ConvertNodes(node.modifiers);
            var paramVar1 = this.ConvertNode(node.name);
            var paramVar2 = this.ConvertNodes(node.typeParameters);
            var paramVar3 = this.ConvertNodes(node.heritageClauses);
            var paramVar4 = this.ConvertNodes(node.members);
            return T.createClassExpression(paramVar0, paramVar1, paramVar2, paramVar3, paramVar4);
        }
        if (node.kind == T.SyntaxKind.FunctionExpression) {
            var paramVar0 = this.ConvertNodes(node.modifiers);
            var paramVar1 = this.ConvertNode(node.asteriskToken);
            var paramVar2 = this.ConvertNode(node.name);
            var paramVar3 = this.ConvertNodes(node.typeParameters);
            var paramVar4 = this.ConvertNodes(node.parameters);
            var paramVar5 = this.ConvertNode(node.type);
            var paramVar6 = this.ConvertNode(node.body);
            return T.createFunctionExpression(paramVar0, paramVar1, paramVar2, paramVar3, paramVar4, paramVar5, paramVar6);
        }
        if (node.kind == T.SyntaxKind.ParenthesizedExpression) {
            var paramVar0 = this.ConvertNode(node.expression);
            return T.createParen(paramVar0);
        }
        if (node.kind == T.SyntaxKind.QualifiedName) {
            var paramVar0 = this.ConvertNode(node.left);
            var paramVar1 = this.ConvertNode(node.right);
            return T.createQualifiedName(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.ComputedPropertyName) {
            var paramVar0 = this.ConvertNode(node.expression);
            return T.createComputedPropertyName(paramVar0);
        }
        if (node.kind == T.SyntaxKind.PrivateIdentifier) {
            return T.createPrivateIdentifier(node.escapedText);
        }
        if (node.kind == T.SyntaxKind.Decorator) {
            var paramVar0 = this.ConvertNode(node.expression);
            return T.createDecorator(paramVar0);
        }
        if (node.kind == T.SyntaxKind.VariableDeclarationList) {
            var paramVar0 = this.ConvertNodes(node.declarations);
            return T.createVariableDeclarationList(paramVar0, node.flags);
        }
        if (node.kind == T.SyntaxKind.ObjectBindingPattern) {
            var paramVar0 = this.ConvertNodes(node.elements);
            return T.createObjectBindingPattern(paramVar0);
        }
        if (node.kind == T.SyntaxKind.ArrayBindingPattern) {
            var paramVar0 = this.ConvertNodes(node.elements);
            return T.createArrayBindingPattern(paramVar0);
        }
        if (node.kind == T.SyntaxKind.TemplateSpan) {
            var paramVar0 = this.ConvertNode(node.expression);
            var paramVar1 = this.ConvertNode(node.literal);
            return T.createTemplateSpan(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.JsxClosingElement) {
            var paramVar0 = this.ConvertNode(node.tagName);
            return T.createJsxClosingElement(paramVar0);
        }
        if (node.kind == T.SyntaxKind.CaseBlock) {
            var paramVar0 = this.ConvertNodes(node.clauses);
            return T.createCaseBlock(paramVar0);
        }
        if (node.kind == T.SyntaxKind.CaseClause) {
            var paramVar0 = this.ConvertNode(node.expression);
            var paramVar1 = this.ConvertNodes(node.statements);
            return T.createCaseClause(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.DefaultClause) {
            var paramVar0 = this.ConvertNodes(node.statements);
            return T.createDefaultClause(paramVar0);
        }
        if (node.kind == T.SyntaxKind.CatchClause) {
            var paramVar0 = this.ConvertNode(node.variableDeclaration);
            var paramVar1 = this.ConvertNode(node.block);
            return T.createCatchClause(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.HeritageClause) {
            var paramVar1 = this.ConvertNodes(node.types);
            return T.createHeritageClause(node.token, paramVar1);
        }
        if (node.kind == T.SyntaxKind.ExternalModuleReference) {
            var paramVar0 = this.ConvertNode(node.expression);
            return T.createExternalModuleReference(paramVar0);
        }
        if (node.kind == T.SyntaxKind.NamedImports) {
            var paramVar0 = this.ConvertNodes(node.elements);
            return T.createNamedImports(paramVar0);
        }
        if (node.kind == T.SyntaxKind.NamedExports) {
            var paramVar0 = this.ConvertNodes(node.elements);
            return T.createNamedExports(paramVar0);
        }
        if (node.kind == T.SyntaxKind.InputFiles) {
            return T.createInputFiles(node.javascriptText, node.declarationText);
        }
        if (node.kind == T.SyntaxKind.ThisType) {
            return T.createThisTypeNode();
        }
        if (node.kind == T.SyntaxKind.TypePredicate) {
            var paramVar0 = this.ConvertNode(node.parameterName);
            var paramVar1 = this.ConvertNode(node.type);
            return T.createTypePredicateNode(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.TypeQuery) {
            var paramVar0 = this.ConvertNode(node.exprName);
            return T.createTypeQueryNode(paramVar0);
        }
        if (node.kind == T.SyntaxKind.ArrayType) {
            var paramVar0 = this.ConvertNode(node.elementType);
            return T.createArrayTypeNode(paramVar0);
        }
        if (node.kind == T.SyntaxKind.TupleType) {
            var paramVar0 = this.ConvertNodes(node.elementTypes);
            return T.createTupleTypeNode(paramVar0);
        }
        if (node.kind == T.SyntaxKind.OptionalType) {
            var paramVar0 = this.ConvertNode(node.type);
            return T.createOptionalTypeNode(paramVar0);
        }
        if (node.kind == T.SyntaxKind.RestType) {
            var paramVar0 = this.ConvertNode(node.type);
            return T.createRestTypeNode(paramVar0);
        }
        if (node.kind == T.SyntaxKind.UnionType) {
            var paramVar0 = this.ConvertNodes(node.types);
            return T.createUnionTypeNode(paramVar0);
        }
        if (node.kind == T.SyntaxKind.IntersectionType) {
            var paramVar0 = this.ConvertNodes(node.types);
            return T.createIntersectionTypeNode(paramVar0);
        }
        if (node.kind == T.SyntaxKind.ConditionalType) {
            var paramVar0 = this.ConvertNode(node.checkType);
            var paramVar1 = this.ConvertNode(node.extendsType);
            var paramVar2 = this.ConvertNode(node.trueType);
            var paramVar3 = this.ConvertNode(node.falseType);
            return T.createConditionalTypeNode(paramVar0, paramVar1, paramVar2, paramVar3);
        }
        if (node.kind == T.SyntaxKind.InferType) {
            var paramVar0 = this.ConvertNode(node.typeParameter);
            return T.createInferTypeNode(paramVar0);
        }
        if (node.kind == T.SyntaxKind.ParenthesizedType) {
            var paramVar0 = this.ConvertNode(node.type);
            return T.createParenthesizedType(paramVar0);
        }
        if (node.kind == T.SyntaxKind.TypeOperator) {
            var paramVar0 = this.ConvertNode(node.type);
            return T.createTypeOperatorNode(paramVar0);
        }
        if (node.kind == T.SyntaxKind.IndexedAccessType) {
            var paramVar0 = this.ConvertNode(node.objectType);
            var paramVar1 = this.ConvertNode(node.indexType);
            return T.createIndexedAccessTypeNode(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.LiteralType) {
            var paramVar0 = this.ConvertNode(node.literal);
            return T.createLiteralTypeNode(paramVar0);
        }
        if (node.kind == T.SyntaxKind.OmittedExpression) {
            return T.createOmittedExpression();
        }
        if (node.kind == T.SyntaxKind.YieldExpression) {
            var paramVar0 = this.ConvertNode(node.expression);
            return T.createYield(paramVar0);
        }
        if (node.kind == T.SyntaxKind.ConditionalExpression) {
            var paramVar0 = this.ConvertNode(node.condition);
            var paramVar1 = this.ConvertNode(node.whenTrue);
            var paramVar2 = this.ConvertNode(node.whenFalse);
            return T.createConditional(paramVar0, paramVar1, paramVar2);
        }
        if (node.kind == T.SyntaxKind.SpreadElement) {
            var paramVar0 = this.ConvertNode(node.expression);
            return T.createSpread(paramVar0);
        }
        if (node.kind == T.SyntaxKind.AsExpression) {
            var paramVar0 = this.ConvertNode(node.expression);
            var paramVar1 = this.ConvertNode(node.type);
            return T.createAsExpression(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.JsxOpeningElement) {
            var paramVar0 = this.ConvertNode(node.tagName);
            var paramVar1 = this.ConvertNodes(node.typeArguments);
            var paramVar2 = this.ConvertNode(node.attributes);
            return T.createJsxOpeningElement(paramVar0, paramVar1, paramVar2);
        }
        if (node.kind == T.SyntaxKind.JsxOpeningFragment) {
            return T.createJsxOpeningFragment();
        }
        if (node.kind == T.SyntaxKind.JsxClosingFragment) {
            return T.createJsxJsxClosingFragment();
        }
        if (node.kind == T.SyntaxKind.JsxExpression) {
            var paramVar0 = this.ConvertNode(node.dotDotDotToken);
            var paramVar1 = this.ConvertNode(node.expression);
            return T.createJsxExpression(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.JsxText) {
            return T.createJsxText(node.text, node.containsOnlyTriviaWhiteSpaces);
        }
        if (node.kind == T.SyntaxKind.CommaListExpression) {
            var paramVar0 = this.ConvertNodes(node.elements);
            return T.createCommaList(paramVar0);
        }
        if (node.kind == T.SyntaxKind.EmptyStatement) {
            return T.createEmptyStatement();
        }
        if (node.kind == T.SyntaxKind.DebuggerStatement) {
            return T.createDebuggerStatement();
        }
        if (node.kind == T.SyntaxKind.Block) {
            var paramVar0 = this.ConvertNodes(node.statements);
            return T.createBlock(paramVar0);
        }
        if (node.kind == T.SyntaxKind.IfStatement) {
            var paramVar0 = this.ConvertNode(node.expression);
            var paramVar1 = this.ConvertNode(node.thenStatement);
            var paramVar2 = this.ConvertNode(node.elseStatement);
            return T.createIf(paramVar0, paramVar1, paramVar2);
        }
        if (node.kind == T.SyntaxKind.BreakStatement) {
            var paramVar0 = this.ConvertNode(node.label);
            return T.createBreak(paramVar0);
        }
        if (node.kind == T.SyntaxKind.ContinueStatement) {
            var paramVar0 = this.ConvertNode(node.label);
            return T.createContinue(paramVar0);
        }
        if (node.kind == T.SyntaxKind.ReturnStatement) {
            var paramVar0 = this.ConvertNode(node.expression);
            return T.createReturn(paramVar0);
        }
        if (node.kind == T.SyntaxKind.WithStatement) {
            var paramVar0 = this.ConvertNode(node.expression);
            var paramVar1 = this.ConvertNode(node.statement);
            return T.createWith(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.SwitchStatement) {
            var paramVar0 = this.ConvertNode(node.expression);
            var paramVar1 = this.ConvertNode(node.caseBlock);
            return T.createSwitch(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.ThrowStatement) {
            var paramVar0 = this.ConvertNode(node.expression);
            return T.createThrow(paramVar0);
        }
        if (node.kind == T.SyntaxKind.TryStatement) {
            var paramVar0 = this.ConvertNode(node.tryBlock);
            var paramVar1 = this.ConvertNode(node.catchClause);
            var paramVar2 = this.ConvertNode(node.finallyBlock);
            return T.createTry(paramVar0, paramVar1, paramVar2);
        }
        if (node.kind == T.SyntaxKind.ImportDeclaration) {
            var paramVar0 = this.ConvertNodes(node.decorators);
            var paramVar1 = this.ConvertNodes(node.modifiers);
            var paramVar2 = this.ConvertNode(node.importClause);
            var paramVar3 = this.ConvertNode(node.moduleSpecifier);
            return T.createImportDeclaration(paramVar0, paramVar1, paramVar2, paramVar3);
        }
        if (node.kind == T.SyntaxKind.TypeParameter) {
            var paramVar0 = this.ConvertNode(node.name);
            var paramVar1 = this.ConvertNode(node.constraint);
            var paramVar2 = this.ConvertNode(node.default);
            return T.createTypeParameterDeclaration(paramVar0, paramVar1, paramVar2);
        }
        if (node.kind == T.SyntaxKind.VariableDeclaration) {
            var paramVar0 = this.ConvertNode(node.name);
            var paramVar1 = this.ConvertNode(node.type);
            var paramVar2 = this.ConvertNode(node.initializer);
            return T.createVariableDeclaration(paramVar0, paramVar1, paramVar2);
        }
        if (node.kind == T.SyntaxKind.BindingElement) {
            var paramVar0 = this.ConvertNode(node.dotDotDotToken);
            var paramVar1 = this.ConvertNode(node.propertyName);
            var paramVar2 = this.ConvertNode(node.name);
            var paramVar3 = this.ConvertNode(node.initializer);
            return T.createBindingElement(paramVar0, paramVar1, paramVar2, paramVar3);
        }
        if (node.kind == T.SyntaxKind.ImportType) {
            var paramVar0 = this.ConvertNode(node.argument);
            var paramVar1 = this.ConvertNode(node.qualifier);
            var paramVar2 = this.ConvertNodes(node.typeArguments);
            return T.createImportTypeNode(paramVar0, paramVar1, paramVar2, node.isTypeOf);
        }
        if (node.kind == T.SyntaxKind.FunctionType) {
            var paramVar0 = this.ConvertNodes(node.typeParameters);
            var paramVar1 = this.ConvertNodes(node.parameters);
            var paramVar2 = this.ConvertNode(node.type);
            return T.createFunctionTypeNode(paramVar0, paramVar1, paramVar2);
        }
        if (node.kind == T.SyntaxKind.ConstructorType) {
            var paramVar0 = this.ConvertNodes(node.typeParameters);
            var paramVar1 = this.ConvertNodes(node.parameters);
            var paramVar2 = this.ConvertNode(node.type);
            return T.createConstructorTypeNode(paramVar0, paramVar1, paramVar2);
        }
        if (node.kind == T.SyntaxKind.TypeReference) {
            var paramVar0 = this.ConvertNode(node.typeName);
            var paramVar1 = this.ConvertNodes(node.typeArguments);
            return T.createTypeReferenceNode(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.DeleteExpression) {
            var paramVar0 = this.ConvertNode(node.expression);
            return T.createDelete(paramVar0);
        }
        if (node.kind == T.SyntaxKind.TypeOfExpression) {
            var paramVar0 = this.ConvertNode(node.expression);
            return T.createTypeOf(paramVar0);
        }
        if (node.kind == T.SyntaxKind.VoidExpression) {
            var paramVar0 = this.ConvertNode(node.expression);
            return T.createVoid(paramVar0);
        }
        if (node.kind == T.SyntaxKind.AwaitExpression) {
            var paramVar0 = this.ConvertNode(node.expression);
            return T.createAwait(paramVar0);
        }
        if (node.kind == T.SyntaxKind.RegularExpressionLiteral) {
            return T.createRegularExpressionLiteral(node.text);
        }
        if (node.kind == T.SyntaxKind.BigIntLiteral) {
            return T.createBigIntLiteral(node.text);
        }
        if (node.kind == T.SyntaxKind.TemplateHead) {
            return T.createTemplateHead(node.text, node.rawText);
        }
        if (node.kind == T.SyntaxKind.TemplateMiddle) {
            return T.createTemplateMiddle(node.text, node.rawText);
        }
        if (node.kind == T.SyntaxKind.TemplateTail) {
            return T.createTemplateTail(node.text, node.rawText);
        }
        if (node.kind == T.SyntaxKind.ObjectLiteralExpression) {
            var paramVar0 = this.ConvertNode(node.properties);
            return T.createObjectLiteral(paramVar0);
        }
        if (node.kind == T.SyntaxKind.ExpressionWithTypeArguments) {
            var paramVar0 = this.ConvertNodes(node.typeArguments);
            var paramVar1 = this.ConvertNode(node.expression);
            return T.createExpressionWithTypeArguments(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.TypeAssertionExpression) {
            var paramVar0 = this.ConvertNode(node.type);
            var paramVar1 = this.ConvertNode(node.expression);
            return T.createTypeAssertion(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.JsxAttributes) {
            var paramVar0 = this.ConvertNode(node.properties);
            return T.createJsxAttributes(paramVar0);
        }
        if (node.kind == T.SyntaxKind.DoStatement) {
            var paramVar0 = this.ConvertNode(node.statement);
            var paramVar1 = this.ConvertNode(node.expression);
            return T.createDo(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.WhileStatement) {
            var paramVar0 = this.ConvertNode(node.expression);
            var paramVar1 = this.ConvertNode(node.statement);
            return T.createWhile(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.ForStatement) {
            var paramVar0 = this.ConvertNode(node.initializer);
            var paramVar1 = this.ConvertNode(node.condition);
            var paramVar2 = this.ConvertNode(node.incrementor);
            var paramVar3 = this.ConvertNode(node.statement);
            return T.createFor(paramVar0, paramVar1, paramVar2, paramVar3);
        }
        if (node.kind == T.SyntaxKind.ForInStatement) {
            var paramVar0 = this.ConvertNode(node.initializer);
            var paramVar1 = this.ConvertNode(node.expression);
            var paramVar2 = this.ConvertNode(node.statement);
            return T.createForIn(paramVar0, paramVar1, paramVar2);
        }
        if (node.kind == T.SyntaxKind.ForOfStatement) {
            var paramVar0 = this.ConvertNode(node.awaitModifier);
            var paramVar1 = this.ConvertNode(node.initializer);
            var paramVar2 = this.ConvertNode(node.expression);
            var paramVar3 = this.ConvertNode(node.statement);
            return T.createForOf(paramVar0, paramVar1, paramVar2, paramVar3);
        }
        if (node.kind == T.SyntaxKind.ImportClause) {
            var paramVar0 = this.ConvertNode(node.name);
            var paramVar1 = this.ConvertNode(node.namedBindings);
            return T.createImportClause(paramVar0, paramVar1, node.isTypeOnly);
        }
        if (node.kind == T.SyntaxKind.NamespaceImport) {
            var paramVar0 = this.ConvertNode(node.name);
            return T.createNamespaceImport(paramVar0);
        }
        if (node.kind == T.SyntaxKind.NamespaceExport) {
            var paramVar0 = this.ConvertNode(node.name);
            return T.createNamespaceExport(paramVar0);
        }
        if (node.kind == T.SyntaxKind.NamespaceExportDeclaration) {
            var paramVar0 = this.ConvertNode(node.name);
            return T.createNamespaceExportDeclaration(paramVar0);
        }
        if (node.kind == T.SyntaxKind.ImportSpecifier) {
            var paramVar0 = this.ConvertNode(node.propertyName);
            var paramVar1 = this.ConvertNode(node.name);
            return T.createImportSpecifier(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.ExportSpecifier) {
            var paramVar0 = this.ConvertNode(node.propertyName);
            var paramVar1 = this.ConvertNode(node.name);
            return T.createExportSpecifier(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.ExportAssignment) {
            var paramVar0 = this.ConvertNodes(node.decorators);
            var paramVar1 = this.ConvertNodes(node.modifiers);
            var paramVar3 = this.ConvertNode(node.expression);
            return T.createExportAssignment(paramVar0, paramVar1, node.isExportEquals, paramVar3);
        }
        if (node.kind == T.SyntaxKind.SemicolonClassElement) {
            return T.createSemicolonClassElement();
        }
        if (node.kind == T.SyntaxKind.PrefixUnaryExpression) {
            var paramVar1 = this.ConvertNode(node.operand);
            return T.createPrefix(node.operator, paramVar1);
        }
        if (node.kind == T.SyntaxKind.PostfixUnaryExpression) {
            var paramVar0 = this.ConvertNode(node.operand);
            return T.createPostfix(paramVar0, node.operator);
        }
        if (node.kind == T.SyntaxKind.JsxAttribute) {
            var paramVar0 = this.ConvertNode(node.name);
            var paramVar1 = this.ConvertNode(node.initializer);
            return T.createJsxAttribute(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.JsxSpreadAttribute) {
            var paramVar0 = this.ConvertNode(node.expression);
            return T.createJsxSpreadAttribute(paramVar0);
        }
        if (node.kind == T.SyntaxKind.NonNullExpression) {
            var paramVar0 = this.ConvertNode(node.expression);
            return T.createNonNullExpression(paramVar0);
        }
        if (node.kind == T.SyntaxKind.ElementAccessExpression) {
            var paramVar0 = this.ConvertNode(node.expression);
            var paramVar1 = this.ConvertNode(node.argumentExpression);
            return T.createElementAccess(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.TaggedTemplateExpression) {
            var paramVar0 = this.ConvertNode(node.tag);
            var paramVar1 = this.ConvertNode(node.template);
            return T.createTaggedTemplate(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.SuperKeyword) {
            return T.createSuper();
        }
        if (node.kind == T.SyntaxKind.TemplateExpression) {
            var paramVar0 = this.ConvertNode(node.head);
            var paramVar1 = this.ConvertNodes(node.templateSpans);
            return T.createTemplateExpression(paramVar0, paramVar1);
        }
        if (node.kind == T.SyntaxKind.ArrayLiteralExpression) {
            var paramVar0 = this.ConvertNodes(node.elements);
            return T.createArrayLiteral(paramVar0);
        }
        if (node.kind == T.SyntaxKind.MetaProperty) {
            var paramVar1 = this.ConvertNode(node.name);
            return T.createMetaProperty(node.keywordToken, paramVar1);
        }
        if (node.kind == T.SyntaxKind.JsxElement) {
            var paramVar0 = this.ConvertNode(node.openingElement);
            var paramVar1 = this.ConvertNodes(node.children);
            var paramVar2 = this.ConvertNode(node.closingElement);
            return T.createJsxElement(paramVar0, paramVar1, paramVar2);
        }
        if (node.kind == T.SyntaxKind.JsxSelfClosingElement) {
            var paramVar0 = this.ConvertNode(node.tagName);
            var paramVar1 = this.ConvertNodes(node.typeArguments);
            var paramVar2 = this.ConvertNode(node.attributes);
            return T.createJsxSelfClosingElement(paramVar0, paramVar1, paramVar2);
        }
        if (node.kind == T.SyntaxKind.JsxFragment) {
            var paramVar0 = this.ConvertNode(node.openingFragment);
            var paramVar1 = this.ConvertNodes(node.children);
            var paramVar2 = this.ConvertNode(node.closingFragment);
            return T.createJsxFragment(paramVar0, paramVar1, paramVar2);
        }
        if (node.kind == T.SyntaxKind.AbstractKeyword) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.AsyncKeyword) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.ConstKeyword) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.DeclareKeyword) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.DefaultKeyword) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.ExportKeyword) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.PublicKeyword) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.PrivateKeyword) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.ProtectedKeyword) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.ReadonlyKeyword) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.StaticKeyword) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.PlusToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.MinusToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.QuestionToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.QuestionQuestionToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.AsteriskAsteriskToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.AsteriskToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.SlashToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.PercentToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.LessThanLessThanToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.GreaterThanGreaterThanToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.GreaterThanGreaterThanGreaterThanToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.LessThanToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.LessThanEqualsToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.GreaterThanToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.GreaterThanEqualsToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.InstanceOfKeyword) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.InKeyword) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.EqualsEqualsToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.EqualsEqualsEqualsToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.ExclamationEqualsEqualsToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.ExclamationEqualsToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.AmpersandToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.BarToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.CaretToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.AmpersandAmpersandToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.BarBarToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.EqualsToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.PlusEqualsToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.MinusEqualsToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.AsteriskAsteriskEqualsToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.AsteriskEqualsToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.SlashEqualsToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.PercentEqualsToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.AmpersandEqualsToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.BarEqualsToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.CaretEqualsToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.LessThanLessThanEqualsToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.GreaterThanGreaterThanGreaterThanEqualsToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.GreaterThanGreaterThanEqualsToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.CommaToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.ExclamationToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.EqualsGreaterThanToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.QuestionDotToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.DotDotDotToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.AssertsKeyword) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.ColonToken) {
            return T.createToken(node.kind);
        }
        if (node.kind == T.SyntaxKind.AwaitKeyword) {
            return T.createToken(node.kind);
        }
    }
    ConvertNodes(nodes) {
        if (nodes == null) {
            return undefined;
        }
        var result = new Array();
        for (var i = 0; i < nodes.length; i++)
            result.push(this.ConvertNode(nodes[i]));
        return result;
    }
}
exports.Converter = Converter;
//# sourceMappingURL=TransportToAstConverter.js.map