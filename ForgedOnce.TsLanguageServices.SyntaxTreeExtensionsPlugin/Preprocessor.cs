using ForgedOnce.Core.Interfaces;
using ForgedOnce.Core.Plugins;
using ForgedOnce.CSharp;
using ForgedOnce.CSharp.Helpers.SemanticAnalysis;
using ForgedOnce.TsLanguageServices.SyntaxTreeExtensionsPlugin.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgedOnce.TsLanguageServices.SyntaxTreeExtensionsPlugin
{
    public class Preprocessor : IPluginPreprocessor<CodeFileCSharp, Parameters, Settings>
    {
        public Parameters GenerateParameters(CodeFileCSharp input, Settings pluginSettings, IMetadataReader metadataReader, ILogger logger, IFileGroup<CodeFileCSharp, GroupItemDetails> fileGroup = null)
        {
            var result = new Parameters();

            var ignoreProperties = pluginSettings.IgnorePropertyNames != null && pluginSettings.IgnorePropertyNames.Length > 0
               ? new HashSet<string>(pluginSettings.IgnorePropertyNames)
               : new HashSet<string>();

            var typesToFold = pluginSettings.TypesToUnfold != null && pluginSettings.TypesToUnfold.Length > 0
                ? new HashSet<string>(pluginSettings.TypesToUnfold)
                : new HashSet<string>();

            INamedTypeSymbol requiredType = null;
            if (!string.IsNullOrEmpty(pluginSettings.RequiredClassBaseType))
            {
                requiredType = input.SemanticModel.Compilation.GetTypeByMetadataName(pluginSettings.RequiredClassBaseType);
                if (requiredType == null)
                {
                    throw new InvalidOperationException($"Cannot resolve required base type {pluginSettings.RequiredClassBaseType} from compilation.");
                }
            }

            foreach (var classDeclaration in input.SyntaxTree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>())
            {
                if (requiredType != null && classDeclaration.BaseList != null)
                {
                    bool hasRequiredType = false;
                    foreach (var baseType in classDeclaration.BaseList.Types)
                    {
                        var typeInfo = input.SemanticModel.GetTypeInfo(baseType.Type);

                        if (typeInfo.Type.InheritsFromOrImplementsOrEqualsIgnoringConstruction(requiredType))
                        {
                            hasRequiredType = true;
                            break;
                        }
                    }

                    if (!hasRequiredType)
                    {
                        continue;
                    }
                }

                var extensionClass = new ExtensionClass();
                var declaredSymbol = input.SemanticModel.GetDeclaredSymbol(classDeclaration);
                if (declaredSymbol.IsAbstract)
                {
                    continue;
                }

                extensionClass.ExtensionClassName = $"{declaredSymbol.Name}Extensions";
                extensionClass.RelatedClassSymbol = declaredSymbol;
                extensionClass.RelatedClassDeclaration = classDeclaration;

                var props =
                    declaredSymbol.GetAllSymbols<IPropertySymbol>(SymbolKind.Property, Accessibility.Public)
                    .Where(p => !p.IsStatic)
                    .ToArray();

                if (props.Length > 0)
                {
                    extensionClass.Members.AddRange(this.GetExtensionMembers(props, declaredSymbol, typesToFold, requiredType, ignoreProperties, pluginSettings));
                    ////var outputFile = (CodeFileCSharp)this.outputStream.CreateCodeFile($"{declaredSymbol.Name}Extensions.cs");
                }

                extensionClass.Include = !typesToFold.Contains(declaredSymbol.MetadataName) && extensionClass.Members.Any(m => m.Include);

                result.ExtensionClasses.Add(extensionClass);
            }

            return result;
        }

        private IEnumerable<ExtensionMember> GetExtensionMembers(
            IPropertySymbol[] properties,
            INamedTypeSymbol declaredSymbol,
            HashSet<string> typesToFold,
            INamedTypeSymbol requiredBaseType,
            HashSet<string> ignoreProperties,
            Settings pluginSettings)
        {
            foreach (var p in properties)
            {
                var itemType = p.Type;
                bool isCollection = false;
                var collectionInterface = p.Type.Interfaces.FirstOrDefault(i => i.IsGenericType && i.ConstructedFrom.GetFullMetadataName() == typeof(ICollection<>).FullName);

                if (collectionInterface != null)
                {
                    itemType = collectionInterface.TypeArguments.First();
                    isCollection = true;                    
                }

                var hasRequiredBaseType = requiredBaseType != null && itemType.InheritsFromOrImplementsOrEqualsIgnoringConstruction(requiredBaseType);
                var namedItemType = itemType as INamedTypeSymbol;
                var hasPublicParameterlessConstructor = namedItemType != null && namedItemType.Constructors.Any(m => !m.IsStatic && m.Parameters.Length == 0 && m.DeclaredAccessibility == Accessibility.Public);
                var member = new ExtensionMember()
                {
                    IsCollection = isCollection,
                    ItemType = itemType,
                    ItemTypeInheritsRequiredBaseType = hasRequiredBaseType,
                    GenerateFuncParameterInExtensionMethod = hasRequiredBaseType && !itemType.IsAbstract && hasPublicParameterlessConstructor,
                    Name = p.Name,
                    SourcePropertySymbol = p,
                    ContainerSymbol = declaredSymbol,
                    PreprocessedItemName = isCollection && pluginSettings.UnpluralizeVariables ? this.UnpluralizeName(p.Name) : p.Name,
                    Include = !ignoreProperties.Contains(p.Name)
                };

                if (typesToFold.Contains(itemType.GetFullMetadataName()))
                {
                    member.Unfold = true;
                    var props =
                    itemType.GetAllSymbols<IPropertySymbol>(SymbolKind.Property, Accessibility.Public)
                    .Where(f => !f.IsStatic);
                    foreach (var f in props)
                    {
                        member.UnfoldedProperties.Add(new UnfoldedProperty()
                        {
                            Include = !ignoreProperties.Contains(f.Name),
                            Name = f.Name,
                            PropertySymbol = f
                        });
                    }
                }

                yield return member;
            }
        }

        /// <summary>
        /// Very basic depluralization implementation. But gives some result.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string UnpluralizeName(string name)
        {
            if (name.ToLower().EndsWith("children"))
            {
                return name.Remove(name.Length - 3);
            }

            if (name.EndsWith("zzes"))
            {
                return name.Remove(name.Length - 3);
            }

            if (name.EndsWith("ies"))
            {
                return $"{name.Remove(name.Length - 3)}y";
            }

            if (name.EndsWith("ses")
                || name.EndsWith("sses")
                || name.EndsWith("shes")
                || name.EndsWith("ches")
                || name.EndsWith("xes")
                || name.EndsWith("zes"))
            {
                return name.Remove(name.Length - 2);
            }

            if (name.EndsWith("s"))
            {
                return name.Remove(name.Length - 1);
            }

            return name;
        }
    }
}
