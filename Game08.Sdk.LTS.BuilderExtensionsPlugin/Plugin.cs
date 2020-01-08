using Game08.Sdk.CodeMixer.Core;
using Game08.Sdk.CodeMixer.Core.Interfaces;
using Game08.Sdk.CodeMixer.Core.Metadata.Interfaces;
using Game08.Sdk.CodeMixer.Core.Plugins;
using Game08.Sdk.CodeMixer.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Game08.Sdk.LTS.BuilderExtensionsPlugin
{
    public class Plugin : CodeGenerationFromCSharpPlugin<Settings, Parameters>
    {
        public const string OutStreamName = "PassThrough";

        protected ICodeStream outputStream;

        public Plugin()
        {
            this.Signature = new PluginSignature()
            {
                Id = "EB407367-5996-431E-8759-3D34ECE4C90C",
                InputLanguage = Languages.CSharp,
                Name = typeof(Plugin).FullName
            };
        }

        protected override List<ICodeStream> CreateOutputs(ICodeStreamFactory codeStreamFactory)
        {
            List<ICodeStream> result = new List<ICodeStream>();
            this.outputStream = codeStreamFactory.CreateCodeStream(Languages.CSharp, OutStreamName);
            result.Add(this.outputStream);
            return result;
        }

        protected override void Implementation(CodeFileCSharp input, Parameters parameters, IMetadataRecorder metadataRecorder, ILogger logger)
        {
            var ignoreProperties = this.Settings.IgnorePropertyNames != null && this.Settings.IgnorePropertyNames.Length > 0
                ? new HashSet<string>(this.Settings.IgnorePropertyNames)
                : new HashSet<string>();

            var typesToFold = this.Settings.TypesToUnfold != null && this.Settings.TypesToUnfold.Length > 0
                ? new HashSet<string>(this.Settings.TypesToUnfold)
                : new HashSet<string>();

            INamedTypeSymbol requiredType = null;
            if (!string.IsNullOrEmpty(this.Settings.RequiredClassBaseType))
            {
                requiredType = input.SemanticModel.Compilation.GetTypeByMetadataName(this.Settings.RequiredClassBaseType);
                if (requiredType == null)
                {
                    throw new InvalidOperationException($"Cannot resolve required base type {this.Settings.RequiredClassBaseType} from compilation.");
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

                        if (InheritsFromOrImplementsOrEqualsIgnoringConstruction(typeInfo.Type, requiredType))
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

                var declaredSymbol = input.SemanticModel.GetDeclaredSymbol(classDeclaration);
                if (!typesToFold.Contains(declaredSymbol.MetadataName))
                {
                    var props =
                        this
                        .GetAllSymbols<IPropertySymbol>(declaredSymbol, SymbolKind.Property, Accessibility.Public)
                        .Where(p => !ignoreProperties.Contains(p.Name))
                        .ToList();

                    if (props.Count > 0)
                    {
                        var outputFile = (CodeFileCSharp)this.outputStream.CreateCodeFile($"{declaredSymbol.Name}Extensions.cs");
                        this.GenerateForClass(props, input, classDeclaration, declaredSymbol, outputFile, typesToFold, requiredType, ignoreProperties);
                    }
                }
            }
        }

        private void GenerateForClass(
            IEnumerable<IPropertySymbol> properties,
            CodeFileCSharp input,
            ClassDeclarationSyntax classDeclarationSyntax,
            INamedTypeSymbol declaredSymbol,
            CodeFileCSharp output,
            HashSet<string> typesToFold,
            INamedTypeSymbol requiredBaseType,
            HashSet<string> ignoreProperties)
        {
            var unit = SyntaxFactory.CompilationUnit();
            
            unit = unit.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(declaredSymbol.ContainingNamespace.ToDisplayString())));

            foreach (var nsUsage in input.SyntaxTree.GetRoot().DescendantNodes().OfType<UsingDirectiveSyntax>())
            {
                unit = unit.AddUsings(nsUsage);
            }

            var additionalUsings = new HashSet<string>();

            List<ExtensionMember> members = new List<ExtensionMember>();

            foreach (var p in properties)
            {
                var itemType = p.Type;
                bool isCollection = false;
                var collectionInterface = p.Type.Interfaces.FirstOrDefault(i => i.IsGenericType && this.GetFullMetadataName(i.ConstructedFrom) == typeof(ICollection<>).FullName);
                
                if (collectionInterface != null)
                {
                    itemType = collectionInterface.TypeArguments.First();
                    isCollection = true;
                    ////additionalUsings.Add(typeof(ICollection<>).FullName.Substring(0, typeof(ICollection<>).FullName.LastIndexOf('.')));
                }

                if (itemType.ContainingNamespace.ToDisplayString() != declaredSymbol.ContainingNamespace.ToDisplayString())
                {
                    additionalUsings.Add(itemType.ContainingNamespace.ToDisplayString());
                }

                members.Add(new ExtensionMember()
                {
                    IsCollection = isCollection,
                    ItemType = itemType,
                    ItemTypeInheritsRequiredBaseType = InheritsFromOrImplementsOrEqualsIgnoringConstruction(itemType, requiredBaseType),
                    Name = p.Name,
                    SourcePropertySymbol = p,
                    ContainerSymbol = declaredSymbol
                });
            }

            foreach (var import in additionalUsings)
            {
                unit = unit.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(import)));
            }

            var className = $"{declaredSymbol.Name}Extensions";

            var extensionClass = SyntaxFactory.ClassDeclaration(className);
            extensionClass = extensionClass.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.StaticKeyword), SyntaxFactory.Token(SyntaxKind.PartialKeyword));

            extensionClass = extensionClass.WithMembers(SyntaxFactory.List<MemberDeclarationSyntax>(members.Select(m => this.CreateExtensionMethod(m, typesToFold, input.SemanticModel, ignoreProperties))));

            var nsContainer = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(this.Settings.OutputNamespace));
            nsContainer = nsContainer.AddMembers(extensionClass);
            unit = unit.AddMembers(nsContainer);
            output.SyntaxTree = unit.SyntaxTree;
        }

        private MethodDeclarationSyntax CreateExtensionMethod(
            ExtensionMember item,
            HashSet<string> typesToFold,
            SemanticModel semanticModel,
            HashSet<string> ignoreProperties)
        {
            var subjectIdentifier = "subject";
            var containerTypeSyntax = SyntaxFactory.ParseTypeName(item.ContainerSymbol.ToMinimalDisplayString(semanticModel, 0, SymbolDisplayFormat.MinimallyQualifiedFormat));
            var itemTypeString = item.ItemType.ToMinimalDisplayString(semanticModel, 0, SymbolDisplayFormat.MinimallyQualifiedFormat);
            var itemTypeSyntax = SyntaxFactory.ParseTypeName(itemTypeString);

            string itemParameterName;
            List<ParameterSyntax> itemParameters = new List<ParameterSyntax>()
                {
                    SyntaxFactory.Parameter(SyntaxFactory.List<AttributeListSyntax>(),
                                SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.ThisKeyword)),
                                containerTypeSyntax,
                                SyntaxFactory.Identifier(subjectIdentifier),
                                null)
                };
            ExpressionSyntax valueSyntax = null;
            if (typesToFold.Contains(this.GetFullMetadataName(item.ItemType)))
            {
                var props = 
                    this
                    .GetAllSymbols<IPropertySymbol>(item.ItemType, SymbolKind.Property, Accessibility.Public)
                    .Where(p => !ignoreProperties.Contains(p.Name));
                List<ExpressionSyntax> initializerParts = new List<ExpressionSyntax>();
                foreach (var p in props)
                {
                    var propName = p.Name != subjectIdentifier ? this.FirstCharToLower(p.Name) : $"{item.Name}{p.Name}";

                    initializerParts.Add(
                        SyntaxFactory.AssignmentExpression(
                            SyntaxKind.SimpleAssignmentExpression,
                            SyntaxFactory.IdentifierName(p.Name),
                            SyntaxFactory.IdentifierName(propName)));

                    itemParameters.Add(SyntaxFactory.Parameter(SyntaxFactory.List<AttributeListSyntax>(),
                            SyntaxFactory.TokenList(),
                            SyntaxFactory.ParseTypeName(p.Type.ToMinimalDisplayString(semanticModel, 0, SymbolDisplayFormat.MinimallyQualifiedFormat)),
                            SyntaxFactory.Identifier(propName),
                            null));
                }

                valueSyntax = SyntaxFactory.ObjectCreationExpression(
                    itemTypeSyntax,
                    null,
                    SyntaxFactory.InitializerExpression(
                        SyntaxKind.ObjectInitializerExpression,
                        SyntaxFactory.SeparatedList<ExpressionSyntax>(initializerParts)));
            }
            else
            {
                if (item.ItemTypeInheritsRequiredBaseType && !item.ItemType.IsAbstract)
                {
                    itemParameterName = $"{this.FirstCharToLower(item.Name)}Builder";
                    itemParameters.Add(SyntaxFactory.Parameter(SyntaxFactory.List<AttributeListSyntax>(),
                            SyntaxFactory.TokenList(),
                            SyntaxFactory.ParseTypeName($"Func<{itemTypeString}, {itemTypeString}>"),
                            SyntaxFactory.Identifier(itemParameterName),
                            null));
                    valueSyntax = SyntaxFactory.InvocationExpression(
                        SyntaxFactory.IdentifierName(itemParameterName),
                        SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList<ArgumentSyntax>(
                            new ArgumentSyntax[] {
                            SyntaxFactory.Argument(SyntaxFactory.ObjectCreationExpression(itemTypeSyntax, SyntaxFactory.ArgumentList(), null))
                            })));
                }
                else
                {
                    itemParameterName = this.FirstCharToLower(item.Name);
                    itemParameters.Add(SyntaxFactory.Parameter(SyntaxFactory.List<AttributeListSyntax>(),
                            SyntaxFactory.TokenList(),
                            itemTypeSyntax,
                            SyntaxFactory.Identifier(itemParameterName),
                            null));
                    valueSyntax = SyntaxFactory.IdentifierName(itemParameterName);
                }
            }

            return SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.List<AttributeListSyntax>(),
                    SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.StaticKeyword)),
                    containerTypeSyntax,
                    null,
                    SyntaxFactory.Identifier($"With{item.Name}"),
                    null,
                    SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList<ParameterSyntax>(itemParameters)),
                    SyntaxFactory.List<TypeParameterConstraintClauseSyntax>(),
                    SyntaxFactory.Block(
                        SyntaxFactory.List<StatementSyntax>(new StatementSyntax[]{
                                SyntaxFactory.ExpressionStatement(
                                item.IsCollection
                                ?
                                (ExpressionSyntax)SyntaxFactory.InvocationExpression(
                                SyntaxFactory.MemberAccessExpression(
                                    SyntaxKind.SimpleMemberAccessExpression,
                                    SyntaxFactory.MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        SyntaxFactory.IdentifierName(subjectIdentifier),
                                        SyntaxFactory.IdentifierName(item.Name)),
                                    SyntaxFactory.IdentifierName("Add")),
                                SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                    new ArgumentSyntax[]{ SyntaxFactory.Argument(valueSyntax) })))
                                :
                                SyntaxFactory.AssignmentExpression(
                                    SyntaxKind.SimpleAssignmentExpression,
                                    SyntaxFactory.MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        SyntaxFactory.IdentifierName(subjectIdentifier),
                                        SyntaxFactory.IdentifierName(item.Name)),
                                    valueSyntax), SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                                SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName(subjectIdentifier))
                        })),
                    null);
        }

        private List<TSymbol> GetAllSymbols<TSymbol>(ITypeSymbol symbol, SymbolKind kind, Accessibility accessibility) where TSymbol : ISymbol
        {
            var result = new Dictionary<string, TSymbol>();

            foreach (var p in symbol
                .GetMembers()
                .Where(m => m.DeclaredAccessibility == accessibility && !m.IsStatic && m.Kind == kind)
                .OfType<TSymbol>())
            {
                result.Add(p.Name, p);
            }

            if (symbol.BaseType != null)
            {
                foreach (var p in this.GetAllSymbols<TSymbol>(symbol.BaseType, kind, accessibility))
                {
                    if (!result.ContainsKey(p.Name))
                    {
                        result.Add(p.Name, p);
                    }
                }
            }

            return result.Values.ToList();
        }

        public static bool InheritsFromOrImplementsOrEqualsIgnoringConstruction(
            ITypeSymbol type, ITypeSymbol baseType)
        {
            var originalBaseType = baseType.OriginalDefinition;
            type = type.OriginalDefinition;

            if (type.MetadataName == originalBaseType.MetadataName)
            {
                return true;
            }

            IEnumerable<ITypeSymbol> baseTypes = (baseType.TypeKind == TypeKind.Interface) ? type.AllInterfaces : GetBaseTypes(type);
            return baseTypes.Any(t => t.OriginalDefinition.MetadataName == originalBaseType.MetadataName);
        }

        public static IEnumerable<INamedTypeSymbol> GetBaseTypes(ITypeSymbol type)
        {
            var current = type.BaseType;
            while (current != null)
            {
                yield return current;
                current = current.BaseType;
            }
        }

        public string FirstCharToLower(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }

            return name.Substring(0, 1).ToLower() + (name.Length > 1 ? name.Substring(1) : string.Empty);
        }

        private string GetFullMetadataName(ITypeSymbol symbol)
        {
            return $"{symbol.ContainingNamespace.ToDisplayString()}.{symbol.MetadataName}";
        }
    }
}
