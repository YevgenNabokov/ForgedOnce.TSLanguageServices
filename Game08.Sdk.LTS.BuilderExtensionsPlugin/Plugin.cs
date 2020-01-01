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
            var typesToFold = this.Settings.TypesToFold != null && this.Settings.TypesToFold.Length > 0
                ? new HashSet<string>(this.Settings.TypesToFold)
                : new HashSet<string>();

            foreach (var classDeclaration in input.SyntaxTree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>())
            {
                if (!string.IsNullOrEmpty(this.Settings.RequiredClassBaseType))
                {
                    INamedTypeSymbol requiredType = input.SemanticModel.Compilation.GetTypeByMetadataName(this.Settings.RequiredClassBaseType);
                    if (requiredType == null)
                    {
                        throw new InvalidOperationException($"Cannot resolve required base type {this.Settings.RequiredClassBaseType} from compilation.");
                    }

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
                    var outputFile = (CodeFileCSharp)this.outputStream.CreateCodeFile($"{declaredSymbol.Name}Extensions.cs");
                    this.GenerateForClass(input, classDeclaration, declaredSymbol, outputFile, typesToFold);
                }
            }
        }

        private void GenerateForClass(
            CodeFileCSharp input,
            ClassDeclarationSyntax classDeclarationSyntax,
            INamedTypeSymbol declaredSymbol,
            CodeFileCSharp output,
            HashSet<string> typesToFold)
        {
            var unit = SyntaxFactory.CompilationUnit();
            
            unit = unit.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(declaredSymbol.ContainingNamespace.ToDisplayString())));

            foreach (var nsUsage in input.SyntaxTree.GetRoot().DescendantNodes().OfType<UsingDirectiveSyntax>())
            {
                unit = unit.AddUsings(nsUsage);
            }

            var props = this.GetAllSymbols<IPropertySymbol>(declaredSymbol, SymbolKind.Property, Accessibility.Public);

            var additionalUsings = new HashSet<string>();

            List<ExtensionMember> members = new List<ExtensionMember>();

            foreach (var p in props)
            {
                var itemType = p.Type;
                bool isCollection = false;
                var collectionInterface = p.Type.Interfaces.FirstOrDefault(i => i.MetadataName == typeof(ICollection<>).FullName);
                
                if (collectionInterface != null)
                {
                    itemType = collectionInterface.TypeArguments.First();
                    isCollection = true;
                    additionalUsings.Add(typeof(ICollection<>).FullName.Substring(0, typeof(ICollection<>).FullName.LastIndexOf('.')));
                }

                if (itemType.ContainingNamespace.ToDisplayString() != declaredSymbol.ContainingNamespace.ToDisplayString())
                {
                    additionalUsings.Add(itemType.ContainingNamespace.ToDisplayString());
                }

                members.Add(new ExtensionMember()
                {
                    IsCollection = isCollection,
                    ItemType = itemType,
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
            extensionClass = extensionClass.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.PartialKeyword), SyntaxFactory.Token(SyntaxKind.StaticKeyword));

            extensionClass = extensionClass.WithMembers(SyntaxFactory.List<MemberDeclarationSyntax>(members.Select(m => this.CreateExtensionMethod(m, typesToFold, input.SemanticModel))));

            var nsContainer = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(this.Settings.OutputNamespace));
            nsContainer = nsContainer.AddMembers(extensionClass);
            unit = unit.AddMembers(nsContainer);
            output.SyntaxTree = unit.SyntaxTree;
        }

        private MethodDeclarationSyntax CreateExtensionMethod(ExtensionMember item, HashSet<string> typesToFold, SemanticModel semanticModel)
        {
            if (!typesToFold.Contains(item.ItemType.MetadataName))
            {
                if (item.IsCollection)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    var subjectIdentifier = "subject";
                    var containerTypeSyntax = SyntaxFactory.ParseTypeName(item.ContainerSymbol.ToMinimalDisplayString(semanticModel, 0, SymbolDisplayFormat.MinimallyQualifiedFormat));
                    var itemTypeString = item.ItemType.ToMinimalDisplayString(semanticModel, 0, SymbolDisplayFormat.MinimallyQualifiedFormat);
                    var itemTypeSyntax = SyntaxFactory.ParseTypeName(itemTypeString);
                    return SyntaxFactory.MethodDeclaration(
                        SyntaxFactory.List<AttributeListSyntax>(),
                        SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.StaticKeyword)),
                        itemTypeSyntax,
                        null,
                        SyntaxFactory.Identifier($"With{item.Name}"),
                        null,
                        SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList<ParameterSyntax>(new ParameterSyntax[] 
                        {
                            SyntaxFactory.Parameter(SyntaxFactory.List<AttributeListSyntax>(),
                                SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.ThisKeyword)),
                                containerTypeSyntax,
                                SyntaxFactory.Identifier(subjectIdentifier),
                                null),
                            SyntaxFactory.Parameter(SyntaxFactory.List<AttributeListSyntax>(),
                                SyntaxFactory.TokenList(),
                                SyntaxFactory.ParseTypeName($"Func<{itemTypeString}, {itemTypeString}>"),
                                SyntaxFactory.Identifier( this.FirstCharToLower(item.Name)),
                                null),
                        })),
                        SyntaxFactory.List<TypeParameterConstraintClauseSyntax>(),
                        SyntaxFactory.Block(
                            //// Implement.
                            ),
                        null);
                }
            }
            else
            {


                throw new NotImplementedException();
            }
        }

        private List<TSymbol> GetAllSymbols<TSymbol>(INamedTypeSymbol symbol, SymbolKind kind, Accessibility accessibility) where TSymbol : ISymbol
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
    }
}
