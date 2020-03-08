using ForgedOnce.TsLanguageServices.CodeMixer.Core;
using ForgedOnce.TsLanguageServices.CodeMixer.Core.Interfaces;
using ForgedOnce.TsLanguageServices.CodeMixer.Core.Metadata.Interfaces;
using ForgedOnce.TsLanguageServices.CodeMixer.Core.Plugins;
using ForgedOnce.TsLanguageServices.CodeMixer.CSharp;
using ForgedOnce.TsLanguageServices.CodeMixer.CSharp.Helpers.SemanticAnalysis;
using ForgedOnce.TsLanguageServices.CodeMixer.CSharp.Helpers.Syntax.Generation;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ForgedOnce.TsLanguageServices.SyntaxTreeExtensionsPlugin
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

                var declaredSymbol = input.SemanticModel.GetDeclaredSymbol(classDeclaration);
                if (!typesToFold.Contains(declaredSymbol.MetadataName))
                {
                    var props =
                        declaredSymbol.GetAllSymbols<IPropertySymbol>(SymbolKind.Property, Accessibility.Public)
                        .Where(p => !p.IsStatic && !ignoreProperties.Contains(p.Name))
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

            unit = unit.AddUsings(
                SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System")),
                SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Collections.Generic")),
                SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Linq")));

            ////unit = unit.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(declaredSymbol.ContainingNamespace.ToDisplayString())));

            ////foreach (var nsUsage in input.SyntaxTree.GetRoot().DescendantNodes().OfType<UsingDirectiveSyntax>())
            ////{
            ////    unit = unit.AddUsings(nsUsage);
            ////}

            var additionalUsings = new HashSet<string>();

            List<ExtensionMember> members = new List<ExtensionMember>();

            foreach (var p in properties)
            {
                var itemType = p.Type;
                bool isCollection = false;
                var collectionInterface = p.Type.Interfaces.FirstOrDefault(i => i.IsGenericType && i.ConstructedFrom.GetFullMetadataName() == typeof(ICollection<>).FullName);
                
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
                    ItemTypeInheritsRequiredBaseType = itemType.InheritsFromOrImplementsOrEqualsIgnoringConstruction(requiredBaseType),
                    Name = p.Name,
                    SourcePropertySymbol = p,
                    ContainerSymbol = declaredSymbol
                });
            }

            ////foreach (var import in additionalUsings)
            ////{
            ////    unit = unit.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(import)));
            ////}

            var className = $"{declaredSymbol.Name}Extensions";

            var extensionClass = SyntaxFactory.ClassDeclaration(className);
            extensionClass = extensionClass.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.StaticKeyword), SyntaxFactory.Token(SyntaxKind.PartialKeyword));

            extensionClass = extensionClass.WithMembers(SyntaxFactory.List<MemberDeclarationSyntax>(members.Select(m => this.CreateExtensionMethod(m, typesToFold, input.SemanticModel, ignoreProperties))));

            var nsContainer = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(this.Settings.OutputNamespace));
            nsContainer = nsContainer.AddMembers(extensionClass);
            unit = unit.AddMembers(nsContainer);
            output.SyntaxTree = unit.SyntaxTree;
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

        private MethodDeclarationSyntax CreateExtensionMethod(
            ExtensionMember item,
            HashSet<string> typesToFold,
            SemanticModel semanticModel,
            HashSet<string> ignoreProperties)
        {
            var preparedItemName = item.IsCollection && this.Settings.UnpluralizeVariables ? this.UnpluralizeName(item.Name) : item.Name;
            preparedItemName = NameHelper.GetSafeVariableName(preparedItemName);

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
            if (typesToFold.Contains(item.ItemType.GetFullMetadataName()))
            {
                var props = 
                    item.ItemType.GetAllSymbols<IPropertySymbol>(SymbolKind.Property, Accessibility.Public)
                    .Where(p => !p.IsStatic && !ignoreProperties.Contains(p.Name));
                List<ExpressionSyntax> initializerParts = new List<ExpressionSyntax>();
                foreach (var p in props)
                {
                    var propName = p.Name != subjectIdentifier ? NameHelper.FirstCharToLower(p.Name) : $"{item.Name}{p.Name}";

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
                    itemParameterName = $"{NameHelper.FirstCharToLower(preparedItemName)}Builder";
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
                    itemParameterName = NameHelper.FirstCharToLower(preparedItemName);
                    itemParameterName = NameHelper.GetSafeVariableName(itemParameterName);

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
                    SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.StaticKeyword)),
                    containerTypeSyntax,
                    null,
                    SyntaxFactory.Identifier($"With{preparedItemName}"),
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
    }
}
