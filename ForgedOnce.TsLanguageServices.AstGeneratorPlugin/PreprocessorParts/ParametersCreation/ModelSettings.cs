using ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.PreprocessorParts.ParametersCreation
{
    public class ModelSettings
    {
        public Dictionary<string, TransportModelPrimitiveType> InterfacesMappedToPrimitiveTypes = new Dictionary<string, TransportModelPrimitiveType>()
        {
            { "__String", TransportModelPrimitiveType.String }
        };

        public HashSet<string> InterfacesMappedAsCollection = new HashSet<string>()
        {
            "NodeArray"
        };

        public Dictionary<string, TransportModelPrimitiveType> PrimitiveTypesMappings = new Dictionary<string, TransportModelPrimitiveType>()
        {
            { "string", TransportModelPrimitiveType.String },
            { "number", TransportModelPrimitiveType.Int },
            { "boolean", TransportModelPrimitiveType.Boolean },
            { "any", TransportModelPrimitiveType.Object },
        };

        public HashSet<string> VoidPrimitiveTypes = new HashSet<string>()
        {
            "undefined"
        };

        public Dictionary<string, string[]> ExcludedByEntityProperties = new Dictionary<string, string[]>()
        {
            { "SignatureDeclarationBase", new[] { "kind" } },
            { "FunctionOrConstructorTypeNodeBase", new[] { "kind" } },
            { "BooleanLiteral", new[] { "kind" } },
            { "FunctionLikeDeclarationBase", new[] { "body" } },
            { "ArrowFunction", new[] { "name" } },
            { "ClassLikeDeclarationBase", new[] { "kind" } },
            { "KeywordTypeNode", new[] { "kind" } },
        };

        public Dictionary<string, KeyValuePair<string, Dictionary<string, string>>> CreationFunctionParametersToPropertyBindings = new Dictionary<string, KeyValuePair<string, Dictionary<string, string>>>()
        {
            { "Identifier", new KeyValuePair<string, Dictionary<string, string>>("createIdentifier", new Dictionary<string, string>() { { "text", "escapedText" } }) },
            { "NumericLiteral", new KeyValuePair<string, Dictionary<string, string>>("createNumericLiteral", new Dictionary<string, string>()
            {
                { "value", "text" },
                { "numericLiteralFlags", "flags" }
            }) },
            { "PrivateIdentifier", new KeyValuePair<string, Dictionary<string, string>>("createPrivateIdentifier", new Dictionary<string, string>() { { "text", "escapedText" } }) },
            { "TypeParameterDeclaration", new KeyValuePair<string, Dictionary<string, string>>("createTypeParameterDeclaration", new Dictionary<string, string>() { { "defaultType", "default" } }) },
            { "BigIntLiteral", new KeyValuePair<string, Dictionary<string, string>>("createBigIntLiteral", new Dictionary<string, string>() { { "value", "text" } }) },
            { "Token", new KeyValuePair<string, Dictionary<string, string>>("createToken", new Dictionary<string, string>() { { "token", "kind" } }) },
            { "NullLiteral", new KeyValuePair<string, Dictionary<string, string>>("createNull", new Dictionary<string, string>()) },
            { "BooleanLiteralTrueKeyword", new KeyValuePair<string, Dictionary<string, string>>("createTrue", new Dictionary<string, string>()) },
            { "BooleanLiteralFalseKeyword", new KeyValuePair<string, Dictionary<string, string>>("createFalse", new Dictionary<string, string>()) },
            { "BinaryExpression", new KeyValuePair<string, Dictionary<string, string>>("createBinary", new Dictionary<string, string>() { { "operator", "operatorToken" } }) },
            { "CallExpression", new KeyValuePair<string, Dictionary<string, string>>("createCall", new Dictionary<string, string>() { { "argumentsArray", "arguments" } }) },
            { "NewExpression", new KeyValuePair<string, Dictionary<string, string>>("createNew", new Dictionary<string, string>() { { "argumentsArray", "arguments" } }) },
            { "ElementAccessExpression", new KeyValuePair<string, Dictionary<string, string>>("createElementAccess", new Dictionary<string, string>() { { "index", "argumentExpression" } }) },
            { "ImportExpression", new KeyValuePair<string, Dictionary<string, string>>("createElementAccess", new Dictionary<string, string>() { { "index", "argumentExpression" } }) },
        };

        public Dictionary<string, KeyValuePair<string, Dictionary<string, string[]>>> CreationFunctionParametersToOneOfPropertiesBindings = new Dictionary<string, KeyValuePair<string, Dictionary<string, string[]>>>()
        {
            { "PropertyDeclaration", new KeyValuePair<string, Dictionary<string, string[]>>("createProperty", new Dictionary<string, string[]>() { { "questionOrExclamationToken", new[] { "questionToken", "exclamationToken" } } }) },
        };

        public Dictionary<string, Dictionary<string, HashSet<string>>> SkippedCreationFunctionOptionalParameters = new Dictionary<string, Dictionary<string, HashSet<string>>>()
        {
            { "Block", new Dictionary<string, HashSet<string>>() { { "createBlock", new HashSet<string>() { "multiLine" } } } },
            { "ObjectLiteralExpression", new Dictionary<string, HashSet<string>>() { { "createObjectLiteral", new HashSet<string>() { "multiLine" } } } },
            { "ArrayLiteralExpression", new Dictionary<string, HashSet<string>>() { { "createArrayLiteral", new HashSet<string>() { "multiLine" } } } },
        };

        public HashSet<string> EntitiesWithSkippedCreationFunctions = new HashSet<string>()
        {
            "JSDoc[a-zA-Z0-9]*",
            "JsonMinusNumericLiteral",
            "ImportExpression"
        };

        public HashSet<string> OtherExcludedTypes;

        public HashSet<string> ExcludedAstNodes;

        public HashSet<string> TypesRepresentedAsInterface;

        public HashSet<string> ExcludedProperties;

        public ModelSettings(Settings settings)
        {
            this.OtherExcludedTypes = new HashSet<string>(settings.OtherExcludedTypes.Split(','));
            this.ExcludedAstNodes = new HashSet<string>(settings.ExcludedAstNodes.Split(','));
            this.TypesRepresentedAsInterface = new HashSet<string>(settings.TypesRepresentedAsInterface.Split(','));
            this.ExcludedProperties = new HashSet<string>(settings.ExcludedProperties.Split(','));
        }
    }
}
