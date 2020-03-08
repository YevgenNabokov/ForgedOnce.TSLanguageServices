using ForgedOnce.TsLanguageServices.CodeMixer.Core.Interfaces;
using ForgedOnce.TsLanguageServices.CodeMixer.Core.Plugins;
using ForgedOnce.TsLanguageServices.CodeMixer.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgedOnce.TsLanguageServices.CodeMixer.CSharp.Helpers.SemanticAnalysis;
using ForgedOnce.TsLanguageServices.CodeMixer.CSharp.Helpers.Syntax.Generation;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ForgedOnce.TsLanguageServices.LTS.BuilderDefinitionTreePlugin
{
    public class Preprocessor : IPluginPreprocessor<CodeFileCSharp, Parameters, Settings>
    {
        public Parameters GenerateMetadata(CodeFileCSharp input, Settings pluginSettings, IMetadataReader metadataReader, ILogger logger, IFileGroup<CodeFileCSharp, GroupItemDetails> fileGroup = null)
        {
            var typesToSkip = pluginSettings.TypesToSkip != null && pluginSettings.TypesToSkip.Length > 0
                ? new HashSet<string>(pluginSettings.TypesToSkip)
                : new HashSet<string>();

            INamedTypeSymbol sourceNodeBaseType = null;
            if (!string.IsNullOrEmpty(pluginSettings.SourceNodeBaseType))
            {
                sourceNodeBaseType = input.SemanticModel.Compilation.GetTypeByMetadataName(pluginSettings.SourceNodeBaseType);
                if (sourceNodeBaseType == null)
                {
                    throw new InvalidOperationException($"Cannot resolve required base type {pluginSettings.SourceNodeBaseType} from compilation.");
                }
            }

            List<NodeTypeInfo> items = new List<NodeTypeInfo>();

            foreach (var classDeclaration in input.SyntaxTree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>())
            {
                var declaredSymbol = input.SemanticModel.GetDeclaredSymbol(classDeclaration);

                var hasRequiredNodeBaseType = declaredSymbol.InheritsFromOrImplementsOrEqualsIgnoringConstruction(sourceNodeBaseType);

                if (hasRequiredNodeBaseType && !typesToSkip.Contains(declaredSymbol.GetFullMetadataName()))
                {
                    items.Add(this.GenerateForClass(declaredSymbol, sourceNodeBaseType, input.SemanticModel, pluginSettings));
                }
            }

            return new Parameters(items);
        }

        public NodeTypeInfo GenerateForClass(INamedTypeSymbol declaredType, INamedTypeSymbol sourceNodeBaseType, SemanticModel semanticModel, Settings pluginSettings)
        {
            List<NodeMember> members = new List<NodeMember>();

            foreach (var f in declaredType.GetMembers()
                .Where(m => m.DeclaredAccessibility == Accessibility.Public && !m.IsStatic && m.Kind == SymbolKind.Field)
                .OfType<IFieldSymbol>())
            {
                members.Add(this.CreateNodeMember(f, sourceNodeBaseType, semanticModel, pluginSettings));
            }

            string baseType = null;

            if (declaredType.BaseType != null)
            {
                if (declaredType.BaseType.InheritsFromOrImplementsOrEqualsIgnoringConstruction(sourceNodeBaseType))
                {
                    baseType = this.GetOutputTypeName(declaredType.BaseType, sourceNodeBaseType, semanticModel, pluginSettings);
                }

                foreach (var f in declaredType.BaseType.GetAllSymbols<IFieldSymbol>(SymbolKind.Field, Accessibility.Public, true, sourceNodeBaseType).Where(s => !s.IsStatic))
                {
                    var member = this.CreateNodeMember(f, sourceNodeBaseType, semanticModel, pluginSettings);
                    member.IsInherited = true;
                    members.Add(member);
                }
            }

            return new NodeTypeInfo()
            {
                BaseTypeString = baseType,
                DeclaredType = declaredType,
                Members = members
            };
        }

        private NodeMember CreateNodeMember(IFieldSymbol fieldSymbol, INamedTypeSymbol sourceNodeBaseType, SemanticModel semanticModel, Settings pluginSettings)
        {
            var member = new NodeMember()
            {
                OriginalField = fieldSymbol,
                DestinationFieldName = NameHelper.GetSafeVariableName(NameHelper.FirstCharToLower(fieldSymbol.Name)),
                FullySpecifiedOutputTypeString = this.GetOutputTypeName(fieldSymbol.Type, sourceNodeBaseType, semanticModel, pluginSettings),
                TypeInheritsFromSourceNodeType = fieldSymbol.Type.InheritsFromOrImplementsOrEqualsIgnoringConstruction(sourceNodeBaseType)
            };

            var collectionInterface = fieldSymbol.Type.Interfaces.FirstOrDefault(i => i.IsGenericType && i.ConstructedFrom.GetFullMetadataName() == typeof(ICollection<>).FullName);

            if (collectionInterface != null)
            {
                member.ItemType = collectionInterface.TypeArguments.First();
                member.IsCollection = true;
                member.ItemTypeInheritsFromSourceNodeType = member.ItemType.InheritsFromOrImplementsOrEqualsIgnoringConstruction(sourceNodeBaseType);

                if (member.ItemType.InheritsFromOrImplementsOrEqualsIgnoringConstruction(sourceNodeBaseType))
                {
                    var itemTypeString = this.GetOutputTypeName(member.ItemType, sourceNodeBaseType, semanticModel, pluginSettings);
                    var collectionTypeString = pluginSettings.TrackingCollectionType.Replace("<", string.Empty).Replace(">", string.Empty);
                    member.CollectionTypeString = $"{collectionTypeString}<{itemTypeString}>";
                }
                else
                {
                    var itemTypeString = member.ItemType.ToMinimalDisplayString(semanticModel, 0, SymbolDisplayFormat.MinimallyQualifiedFormat);
                    member.CollectionTypeString = $"System.Collections.Generic.List<{itemTypeString}>";
                }
            }

            return member;
        }

        private string GetOutputTypeName(ITypeSymbol typeSymbol, INamedTypeSymbol sourceNodeBaseType, SemanticModel semanticModel, Settings pluginSettings)
        {
            if (typeSymbol.InheritsFromOrImplementsOrEqualsIgnoringConstruction(sourceNodeBaseType))
            {
                if (SymbolEqualityComparer.Default.Equals(typeSymbol, sourceNodeBaseType))
                {
                    return pluginSettings.DestinationNodeBaseType;
                }
                else
                {
                    return $"{pluginSettings.OutputNamespace}.{typeSymbol.Name}";
                }
            }

            return typeSymbol.ToMinimalDisplayString(semanticModel, 0, SymbolDisplayFormat.MinimallyQualifiedFormat);
        }
    }
}
