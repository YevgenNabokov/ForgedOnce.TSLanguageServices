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

        public string AstDescriptionJsonFilePath;

        public string AstNodeBaseTypeQualified;

        public string ExcludedAstNodes = "ts.TransientIdentifier,ts.SyntaxList,ts.PropertyLikeDeclaration,ts.SuperCall,ts.ImportCall,ts.JsonObjectExpressionStatement,ts.ObjectDestructuringAssignment,ts.ArrayDestructuringAssignment,ts.PropertyAccessChain,ts.SuperPropertyAccessExpression,ts.SuperElementAccessExpression,ts.TsConfigSourceFile,ts.NonNullChain,ts.ElementAccessChain,ts.AssignmentExpression,ts.CallChain,ts.JsonSourceFile,ts.BindingOrAssignmentElement";

        public string OtherExcludedTypes = "ts.UnscopedEmitHelper,ts.TextRange";

        public string TypesRepresentedAsInterface = "ts.Node";

        public string ExcludedProperties = "parent";

        public string BasePath;
    }
}
