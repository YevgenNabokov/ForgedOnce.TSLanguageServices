using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin
{
    public class Settings
    {
        public const string AstDescriptionJsonFilePathKey = "astDescriptionJsonFilePath";

        public const string AstNodeBaseTypeQualifiedKey = "astNodeBaseTypeQualified";

        public const string ExcludedAstNodesKey = "excludedAstNodes";

        public const string OtherExcludedTypesKey = "otherExcludedTypes";

        public const string TypesRepresentedAsInterfaceKey = "typesRepresentedAsInterface";

        public const string ExcludedPropertiesKey = "excludedProperties";

        public const string CsTransportModelNamespaceKey = "csTransportModelNamespace";

        public const string CsTransportModelCollectionTypeKey = "csTransportModelCollectionType";

        public string AstDescriptionJsonFilePath;

        public string AstNodeBaseTypeQualified;

        public string ExcludedAstNodes = "ts.TransientIdentifier,ts.SyntaxList,ts.PropertyLikeDeclaration,ts.SuperCall,ts.ImportCall,ts.JsonObjectExpressionStatement,ts.ObjectDestructuringAssignment"+
            ",ts.ArrayDestructuringAssignment,ts.PropertyAccessChain,ts.SuperPropertyAccessExpression,ts.SuperElementAccessExpression,ts.TsConfigSourceFile,ts.NonNullChain,ts.ElementAccessChain"+
            ",ts.AssignmentExpression,ts.CallChain,ts.JsonSourceFile,ts.BindingOrAssignmentElement,ts.SyntheticExpression,ts.Bundle,ts.UnparsedSource,ts.UnparsedPrepend,ts.UnparsedTextLike,ts.UnparsedSection"+
            ",ts.UnparsedSyntheticReference,ts.UnparsedPrologue,ts.JSDocAugmentsTag,ts.JSDocImplementsTag,ts.NotEmittedStatement,ts.SourceFile,ts.PartiallyEmittedExpression,ts.MissingDeclaration";

        public string OtherExcludedTypes = "ts.UnscopedEmitHelper,ts.TextRange,ts.JSDocAugmentsTag,ts.JSDocImplementsTag,ts.SourceFile";

        public string TypesRepresentedAsInterface = "ts.Node";

        public string ExcludedProperties = "parent";

        public string BasePath;

        public string CsTransportModelNamespace = "ForgedOnce.TsLanguageServices.FullSyntaxTree.TransportModel";

        public string CsTransportModelCollectionType = "System.Collections.Generic.List";
    }
}
