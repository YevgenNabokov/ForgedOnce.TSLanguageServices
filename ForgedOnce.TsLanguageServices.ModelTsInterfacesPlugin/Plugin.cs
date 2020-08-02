using ForgedOnce.Core;
using ForgedOnce.Core.Interfaces;
using ForgedOnce.Core.Metadata.Interfaces;
using ForgedOnce.Core.Plugins;
using ForgedOnce.CSharp;
using ForgedOnce.TypeScript;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using ForgedOnce.TsLanguageServices.Model.TypeData;
using ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree;
using ForgedOnce.CSharp.Helpers.SemanticAnalysis;
using ForgedOnce.TsLanguageServices.ModelBuilder.Interfaces;

namespace ForgedOnce.TsLanguageServices.ModelTsInterfacesPlugin
{
    public class Plugin : CodeGenerationFromCSharpPlugin<Settings, Parameters>
    {
        public const string OutStreamName = "PassThrough";

        public TypeMappings TypeMappingsDefault = new TypeMappings()
        {
            PrimitiveTypeMappings = new Dictionary<Type, string>()
            {
                { typeof(string), "string" },
                { typeof(bool), "boolean" },
                { typeof(int), "number" },
                { typeof(float), "number" },
            },
            ComplexTypeMappings = new Dictionary<Type, Func<ILtsTypeRepository, string>>()
            {
                { typeof(int?), (r) => r.RegisterTypeReferenceUnion(new[] { r.RegisterTypeReferenceBuiltin("number"), r.RegisterTypeReferenceBuiltin("null") }) },
                { typeof(float?), (r) => r.RegisterTypeReferenceUnion(new[] { r.RegisterTypeReferenceBuiltin("number"), r.RegisterTypeReferenceBuiltin("null") }) },
            }
        };

        protected ICodeStream outputStream;

        protected CodeFileTsModel singleOutputFile;

        public Plugin()
        {
            this.Signature = new PluginSignature()
            {
                Id = "A6CCB00A-D9AC-4C2A-B9D1-973B34192D78",
                InputLanguage = Languages.CSharp,
                Name = typeof(Plugin).FullName
            };
        }

        protected virtual TypeMappings CreateTypeMappings()
        {
            var result = new TypeMappings();
            foreach (var mapping in this.TypeMappingsDefault.PrimitiveTypeMappings)
            {
                if (mapping.Key == typeof(string) && this.Settings.NullableStrings)
                {
                    continue;
                }

                result.PrimitiveTypeMappings.Add(mapping.Key, mapping.Value);
            }

            foreach (var mapping in this.TypeMappingsDefault.ComplexTypeMappings)
            {
                result.ComplexTypeMappings.Add(mapping.Key, mapping.Value);
            }

            if (this.Settings.NullableStrings)
            {
                result.ComplexTypeMappings.Add(typeof(string), (r) => r.RegisterTypeReferenceUnion(new[] { r.RegisterTypeReferenceBuiltin("string"), r.RegisterTypeReferenceBuiltin("null") }));
            }

            return result;
        }

        protected override List<ICodeStream> CreateOutputs(ICodeStreamFactory codeStreamFactory)
        {
            List<ICodeStream> result = new List<ICodeStream>();
            this.outputStream = codeStreamFactory.CreateCodeStream(Languages.LimitedTypeScript, OutStreamName);
            result.Add(this.outputStream);
            return result;
        }

        protected override void Implementation(CodeFileCSharp input, Parameters parameters, IMetadataRecorder metadataRecorder, ILogger logger)
        {
            var mappings = this.CreateTypeMappings();

            foreach (var enumDeclaration in input.SyntaxTree.GetRoot().DescendantNodes().OfType<EnumDeclarationSyntax>())
            {
                this.GenerateForEnum(input, enumDeclaration);
            }

            foreach (var classDeclaration in input.SyntaxTree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>())
            {
                var declaredSymbol = input.SemanticModel.GetDeclaredSymbol(classDeclaration);
                if (this.HasBaseModelNamespace(declaredSymbol))
                {
                    this.GenerateForClass(input, declaredSymbol, mappings);
                }
            }
        }

        protected void GenerateForClass(CodeFileCSharp input, INamedTypeSymbol classSymbol, TypeMappings typeMappings)
        {
            var members = classSymbol.GetMembers()
                .Where(m => m.DeclaredAccessibility == Accessibility.Public && !m.IsStatic && m.Kind == SymbolKind.Field)
                .OfType<IFieldSymbol>()
                .ToArray();

            var interfaceDefinition = new InterfaceDefinition();
            interfaceDefinition.Modifiers.Add(Model.DefinitionTree.Modifier.Export);
            interfaceDefinition.Name = new Identifier() { Name = classSymbol.Name };
            interfaceDefinition.TypeKey = this.OutputFile.TypeRepository.RegisterTypeDefinition(classSymbol.Name, string.Empty, this.OutputFile.Name, Array.Empty<TypeParameter>());

            if (classSymbol.BaseType != null && typeof(object).FullName != classSymbol.BaseType.GetFullMetadataName())
            {
                var mappedKey = this.MapTypeReference(classSymbol.BaseType, typeMappings);
                if (mappedKey != null)
                {
                    interfaceDefinition.Implements.Add(new TypeReferenceId() { ReferenceKey = mappedKey });
                }
            }

            foreach (var member in members)
            {
                interfaceDefinition.Fields.Add(new FieldDeclaration()
                {
                    Name = new Identifier() { Name = member.Name },
                    TypeReference = new TypeReferenceId() { ReferenceKey = this.MapTypeReference(member.Type, typeMappings) }
                });
            }

            this.OutputFile.Model.Items.Add(interfaceDefinition);
        }

        protected string MapTypeReference(ITypeSymbol typeSymbol, TypeMappings typeMappings)
        {
            var arraySymbol = typeSymbol as IArrayTypeSymbol;
            if (arraySymbol != null)
            {
                return this.OutputFile.TypeRepository.RegisterTypeReferenceBuiltin("Array", new string[] { this.MapTypeReference(arraySymbol.ElementType, typeMappings) });
            }

            foreach (var mapping in typeMappings.PrimitiveTypeMappings)
            {
                if (this.TypeMatches(typeSymbol, mapping.Key))
                {
                    return this.OutputFile.TypeRepository.RegisterTypeReferenceBuiltin(mapping.Value);
                }
            }

            foreach (var mapping in typeMappings.ComplexTypeMappings)
            {
                if (this.TypeMatches(typeSymbol, mapping.Key))
                {
                    return mapping.Value(this.OutputFile.TypeRepository);
                }
            }

            var dictionaryInterface = typeSymbol
            .Interfaces
            .FirstOrDefault(i => i.IsGenericType
                && i.ConstructedFrom.GetFullMetadataName() == typeof(IDictionary<,>).FullName
                && i.TypeArguments[0].GetFullMetadataName() == typeof(string).FullName);
            if (dictionaryInterface != null)
            {
                return this.OutputFile.TypeRepository.RegisterTypeReferenceInlineIndexer("key", this.MapTypeReference(dictionaryInterface.TypeArguments[1], typeMappings));
            }

            var collectionInterface = typeSymbol.Interfaces.FirstOrDefault(i => i.IsGenericType && i.ConstructedFrom.GetFullMetadataName() == typeof(IEnumerable<>).FullName);
            if (collectionInterface != null)
            {
                return this.OutputFile.TypeRepository.RegisterTypeReferenceBuiltin("Array", new string[] { this.MapTypeReference(collectionInterface.TypeArguments[0], typeMappings) });
            }

            if (this.HasBaseModelNamespace(typeSymbol))
            {
                var definedId = this.OutputFile.TypeRepository.RegisterTypeDefinition(typeSymbol.Name, string.Empty, this.OutputFile.Name, Array.Empty<TypeParameter>());
                return this.OutputFile.TypeRepository.RegisterTypeReferenceDefined(definedId);
            }

            if (this.Settings.SkipUnmappedTypeReferences)
            {
                return null;
            }
            else
            {
                throw new InvalidOperationException($"Type {typeSymbol.ToDisplayString()} cannot be mapped.");
            }
        }

        protected bool TypeMatches(ITypeSymbol typeSymbol, Type type)
        {
            if (type.IsGenericType)
            {
                if (typeSymbol.GetFullMetadataName() != type.GetGenericTypeDefinition().FullName)
                {
                    return false;
                }

                if (typeSymbol is INamedTypeSymbol namedSymbol)
                {
                    if (namedSymbol.TypeArguments.Length != type.GenericTypeArguments.Length)
                    {
                        return false;
                    }

                    for (var i = 0; i < namedSymbol.TypeArguments.Length; i++)
                    {
                        if (!this.TypeMatches(namedSymbol.TypeArguments[i], type.GenericTypeArguments[i]))
                        {
                            return false;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return typeSymbol.GetFullMetadataName() == type.FullName;
            }
        }

        protected void GenerateForEnum(CodeFileCSharp input, EnumDeclarationSyntax enumSyntax)
        {
            var declaredSymbol = input.SemanticModel.GetDeclaredSymbol(enumSyntax);

            var enumDefinition = new EnumDefinition();
            enumDefinition.Modifiers.Add(Model.DefinitionTree.Modifier.Export);
            enumDefinition.Name = new Identifier() { Name = declaredSymbol.Name };

            var members = declaredSymbol.GetMembers()
                .Where(m => m.DeclaredAccessibility == Accessibility.Public && m.IsStatic && m.Kind == SymbolKind.Field)
                .OfType<IFieldSymbol>()
                .Where(f => f.IsConst && f.IsDefinition)
                .ToArray();

            foreach (var member in members)
            {
                enumDefinition.Members.Add(new EnumMember() { Name = new Identifier() { Name = member.Name } });
            }

            enumDefinition.TypeKey = this.OutputFile.TypeRepository.RegisterTypeDefinition(declaredSymbol.Name, string.Empty, this.OutputFile.Name, Array.Empty<TypeParameter>());

            this.OutputFile.Model.Items.Add(enumDefinition);
        }

        protected bool HasBaseModelNamespace(ITypeSymbol symbol)
        {
            return string.IsNullOrEmpty(this.Settings.ModelBaseNamespace) || symbol.ContainingNamespace.ToDisplayString().StartsWith(this.Settings.ModelBaseNamespace);
        }

        protected CodeFileTsModel OutputFile
        {
            get
            {
                if (this.singleOutputFile == null)
                {
                    this.singleOutputFile = (CodeFileTsModel)this.outputStream.CreateCodeFile(
                        string.IsNullOrEmpty(this.Settings.OutputFileName) ? $"IntermediateModelGenerated.ts" : this.Settings.OutputFileName);
                }

                return this.singleOutputFile;
            }
        }
    }
}
