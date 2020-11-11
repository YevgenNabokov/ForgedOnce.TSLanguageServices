import * as T from "typescript";
export class TypeMarker {
    public Mark(node: any): boolean { if (node.kind == T.SyntaxKind.ModuleBlock) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ModuleBlock, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.Identifier) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Identifier, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.TypeLiteral) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeLiteralNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.MappedType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.MappedTypeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.StringLiteral) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.StringLiteral, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.NullKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NullLiteral, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.TrueKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BooleanLiteralTrueKeyword, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.FalseKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BooleanLiteralFalseKeyword, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.BinaryExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BinaryExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ArrowFunction) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ArrowFunction, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.NoSubstitutionTemplateLiteral) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NoSubstitutionTemplateLiteral, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.NumericLiteral) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NumericLiteral, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.CallExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CallExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.NewExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NewExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.VariableStatement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.VariableStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ExpressionStatement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExpressionStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.LabeledStatement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.LabeledStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocEnumTag) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocEnumTag, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocTypedefTag) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocTypedefTag, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocCallbackTag) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocCallbackTag, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocSignature) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocSignature, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.Parameter) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ParameterDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.FunctionDeclaration) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.FunctionDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.AnyKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeAnyKeyword, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.UnknownKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeUnknownKeyword, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.NumberKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeNumberKeyword, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.BigIntKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeBigIntKeyword, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ObjectKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeObjectKeyword, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.BooleanKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeBooleanKeyword, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.StringKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeStringKeyword, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.SymbolKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeSymbolKeyword, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.VoidKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeVoidKeyword, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.UndefinedKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeUndefinedKeyword, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.NullKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeNullKeyword, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.NeverKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.KeywordTypeNodeNeverKeyword, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ThisKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ThisExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.PropertyAccessExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PropertyAccessExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ClassDeclaration) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ClassDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.InterfaceDeclaration) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.InterfaceDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.TypeAliasDeclaration) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeAliasDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.EnumMember) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.EnumMember, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.EnumDeclaration) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.EnumDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ModuleDeclaration) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ModuleDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ImportEqualsDeclaration) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ImportEqualsDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ExportDeclaration) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExportDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocFunctionType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocFunctionType, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.CallSignature) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CallSignatureDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ConstructSignature) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ConstructSignatureDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.PropertySignature) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PropertySignature, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.PropertyDeclaration) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PropertyDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.PropertyAssignment) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PropertyAssignment, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ShorthandPropertyAssignment) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ShorthandPropertyAssignment, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.SpreadAssignment) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SpreadAssignment, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.MethodSignature) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.MethodSignature, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.MethodDeclaration) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.MethodDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.Constructor) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ConstructorDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.GetAccessor) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.GetAccessorDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.SetAccessor) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SetAccessorDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.IndexSignature) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IndexSignatureDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ClassExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ClassExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.FunctionExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.FunctionExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ParenthesizedExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ParenthesizedExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.QualifiedName) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.QualifiedName, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ComputedPropertyName) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ComputedPropertyName, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.PrivateIdentifier) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PrivateIdentifier, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.Decorator) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Decorator, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.VariableDeclarationList) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.VariableDeclarationList, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ObjectBindingPattern) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ObjectBindingPattern, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ArrayBindingPattern) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ArrayBindingPattern, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.TemplateSpan) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TemplateSpan, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JsxClosingElement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxClosingElement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.CaseBlock) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CaseBlock, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.CaseClause) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CaseClause, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.DefaultClause) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.DefaultClause, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.CatchClause) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CatchClause, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.HeritageClause) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.HeritageClause, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ExternalModuleReference) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExternalModuleReference, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.NamedImports) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NamedImports, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.NamedExports) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NamedExports, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocComment) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDoc, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.InputFiles) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.InputFiles, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ThisType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ThisTypeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.TypePredicate) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypePredicateNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.TypeQuery) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeQueryNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ArrayType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ArrayTypeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.TupleType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TupleTypeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.OptionalType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.OptionalTypeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.RestType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.RestTypeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.UnionType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.UnionTypeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.IntersectionType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IntersectionTypeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ConditionalType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ConditionalTypeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.InferType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.InferTypeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ParenthesizedType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ParenthesizedTypeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.TypeOperator) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeOperatorNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.IndexedAccessType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IndexedAccessTypeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.LiteralType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.LiteralTypeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.OmittedExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.OmittedExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.YieldExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.YieldExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ConditionalExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ConditionalExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.SpreadElement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SpreadElement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.AsExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AsExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JsxOpeningElement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxOpeningElement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JsxOpeningFragment) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxOpeningFragment, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JsxClosingFragment) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxClosingFragment, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JsxExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JsxText) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxText, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.CommaListExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CommaListExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.EmptyStatement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.EmptyStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.DebuggerStatement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.DebuggerStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.Block) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Block, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.IfStatement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.IfStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.BreakStatement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BreakStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ContinueStatement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ContinueStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ReturnStatement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ReturnStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.WithStatement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.WithStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.SwitchStatement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SwitchStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ThrowStatement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ThrowStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.TryStatement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TryStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ImportDeclaration) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ImportDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocTypeExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocTypeExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocTag) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocUnknownTag, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocAuthorTag) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocAuthorTag, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocClassTag) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocClassTag, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocPublicTag) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocPublicTag, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocPrivateTag) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocPrivateTag, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocProtectedTag) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocProtectedTag, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocReadonlyTag) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocReadonlyTag, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocThisTag) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocThisTag, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocTemplateTag) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocTemplateTag, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocReturnTag) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocReturnTag, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocTypeTag) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocTypeTag, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.TypeParameter) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeParameterDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.VariableDeclaration) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.VariableDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.BindingElement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BindingElement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ImportType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ImportTypeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.FunctionType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.FunctionTypeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ConstructorType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ConstructorTypeNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.TypeReference) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeReferenceNode, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.DeleteExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.DeleteExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.TypeOfExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeOfExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.VoidExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.VoidExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.AwaitExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AwaitExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.RegularExpressionLiteral) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.RegularExpressionLiteral, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.BigIntLiteral) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BigIntLiteral, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.TemplateHead) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TemplateHead, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.TemplateMiddle) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TemplateMiddle, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.TemplateTail) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TemplateTail, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ObjectLiteralExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ObjectLiteralExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ExpressionWithTypeArguments) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExpressionWithTypeArguments, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.TypeAssertionExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TypeAssertion, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JsxAttributes) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxAttributes, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.DoStatement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.DoStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.WhileStatement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.WhileStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ForStatement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ForStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ForInStatement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ForInStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ForOfStatement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ForOfStatement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ImportClause) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ImportClause, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.NamespaceImport) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NamespaceImport, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.NamespaceExport) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NamespaceExport, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.NamespaceExportDeclaration) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NamespaceExportDeclaration, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ImportSpecifier) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ImportSpecifier, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ExportSpecifier) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExportSpecifier, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ExportAssignment) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExportAssignment, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocAllType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocAllType, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocUnknownType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocUnknownType, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocNonNullableType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocNonNullableType, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocNullableType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocNullableType, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocOptionalType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocOptionalType, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocVariadicType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocVariadicType, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocNamepathType) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocNamepathType, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocPropertyTag) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocPropertyTag, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocParameterTag) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocParameterTag, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JSDocTypeLiteral) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JSDocTypeLiteral, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.SemicolonClassElement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SemicolonClassElement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.PrefixUnaryExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PrefixUnaryExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.PostfixUnaryExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PostfixUnaryExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JsxAttribute) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxAttribute, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JsxSpreadAttribute) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxSpreadAttribute, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.NonNullExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.NonNullExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.PrefixUnaryExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsonMinusNumericLiteral, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ElementAccessExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ElementAccessExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.TaggedTemplateExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TaggedTemplateExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.SuperKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SuperExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ImportKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ImportExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.TemplateExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.TemplateExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ArrayLiteralExpression) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ArrayLiteralExpression, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.MetaProperty) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.MetaProperty, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JsxElement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxElement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JsxSelfClosingElement) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxSelfClosingElement, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.JsxFragment) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.JsxFragment, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.AbstractKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AbstractKeywordToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.AsyncKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AsyncKeywordToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ConstKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ConstKeywordToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.DeclareKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.DeclareKeywordToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.DefaultKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.DefaultKeywordToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ExportKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExportKeywordToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.PublicKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PublicKeywordToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.PrivateKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PrivateKeywordToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ProtectedKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ProtectedKeywordToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ReadonlyKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ReadonlyKeywordToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.StaticKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.StaticKeywordToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.PlusToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PlusTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.MinusToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.MinusTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.QuestionToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.QuestionTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.QuestionQuestionToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.QuestionQuestionTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.AsteriskAsteriskToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AsteriskAsteriskTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.AsteriskToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AsteriskTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.SlashToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SlashTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.PercentToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PercentTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.LessThanLessThanToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.LessThanLessThanTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.GreaterThanGreaterThanToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.GreaterThanGreaterThanTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.GreaterThanGreaterThanGreaterThanToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.GreaterThanGreaterThanGreaterThanTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.LessThanToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.LessThanTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.LessThanEqualsToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.LessThanEqualsTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.GreaterThanToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.GreaterThanTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.GreaterThanEqualsToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.GreaterThanEqualsTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.InstanceOfKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.InstanceOfKeywordToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.InKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.InKeywordToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.EqualsEqualsToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.EqualsEqualsTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.EqualsEqualsEqualsToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.EqualsEqualsEqualsTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ExclamationEqualsEqualsToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExclamationEqualsEqualsTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ExclamationEqualsToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExclamationEqualsTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.AmpersandToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AmpersandTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.BarToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BarTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.CaretToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CaretTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.AmpersandAmpersandToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AmpersandAmpersandTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.BarBarToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BarBarTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.EqualsToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.EqualsTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.PlusEqualsToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PlusEqualsTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.MinusEqualsToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.MinusEqualsTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.AsteriskAsteriskEqualsToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AsteriskAsteriskEqualsTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.AsteriskEqualsToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AsteriskEqualsTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.SlashEqualsToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.SlashEqualsTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.PercentEqualsToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.PercentEqualsTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.AmpersandEqualsToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AmpersandEqualsTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.BarEqualsToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.BarEqualsTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.CaretEqualsToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CaretEqualsTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.LessThanLessThanEqualsToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.LessThanLessThanEqualsTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.GreaterThanGreaterThanGreaterThanEqualsToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.GreaterThanGreaterThanGreaterThanEqualsTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.GreaterThanGreaterThanEqualsToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.GreaterThanGreaterThanEqualsTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.CommaToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.CommaTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ExclamationToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ExclamationTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.EqualsGreaterThanToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.EqualsGreaterThanTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.QuestionDotToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.QuestionDotTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.DotDotDotToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.DotDotDotTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.AssertsKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AssertsKeywordToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.ColonToken) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.ColonTokenToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.AwaitKeyword) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.AwaitKeywordToken, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } if (node.kind == T.SyntaxKind.Unknown) {
        node.$type = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel.Root, ForgedOnce.TsLanguageServices.FullSyntaxTree";
        return true;
    } return false; }
}
