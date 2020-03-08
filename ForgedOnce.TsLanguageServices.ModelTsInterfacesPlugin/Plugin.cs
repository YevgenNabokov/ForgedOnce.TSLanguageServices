using ForgedOnce.TsLanguageServices.CodeMixer.Core;
using ForgedOnce.TsLanguageServices.CodeMixer.Core.Interfaces;
using ForgedOnce.TsLanguageServices.CodeMixer.Core.Metadata.Interfaces;
using ForgedOnce.TsLanguageServices.CodeMixer.Core.Plugins;
using ForgedOnce.TsLanguageServices.CodeMixer.CSharp;
using ForgedOnce.TsLanguageServices.CodeMixer.LimitedTypeScript;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using ForgedOnce.TsLanguageServices.LTS.Model.TypeData;
using ForgedOnce.TsLanguageServices.LTS.Builder.DefinitionTree;
using ForgedOnce.TsLanguageServices.CodeMixer.CSharp.Helpers.SemanticAnalysis;

namespace ForgedOnce.TsLanguageServices.LTS.ModelTsInterfacesPlugin
{
    public class Plugin : CodeGenerationFromCSharpPlugin<Settings, Parameters>
    {
        public const string OutStreamName = "PassThrough";
        
        //// Should be of course replaced with some common list and/or easily extendable from Parameters.        
        public Dictionary<string, string> PrimitiveTypeMappings = new Dictionary<string, string>()
        {
            { typeof(string).FullName, "string" },
            { typeof(bool).FullName, "boolean" },
            { typeof(int).FullName, "number" },
            { typeof(float).FullName, "number" }
        };

        protected ICodeStream outputStream;

        protected CodeFileLtsModel singleOutputFile;

        public Plugin()
        {
            this.Signature = new PluginSignature()
            {
                Id = "A6CCB00A-D9AC-4C2A-B9D1-973B34192D78",
                InputLanguage = Languages.CSharp,
                Name = typeof(Plugin).FullName
            };
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
            foreach (var enumDeclaration in input.SyntaxTree.GetRoot().DescendantNodes().OfType<EnumDeclarationSyntax>())
            {
                this.GenerateForEnum(input, enumDeclaration);
            }

            foreach (var classDeclaration in input.SyntaxTree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>())
            {
                var declaredSymbol = input.SemanticModel.GetDeclaredSymbol(classDeclaration);
                if (this.HasBaseModelNamespace(declaredSymbol))
                {
                    this.GenerateForClass(input, declaredSymbol);
                }
            }
        }

        protected void GenerateForClass(CodeFileCSharp input, INamedTypeSymbol classSymbol)
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
                var mappedKey = this.MapTypeReference(classSymbol.BaseType);
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
                    TypeReference = new TypeReferenceId() { ReferenceKey = this.MapTypeReference(member.Type) }
                });
            }

            this.OutputFile.Model.Items.Add(interfaceDefinition);
        }

        protected string MapTypeReference(ITypeSymbol typeSymbol)
        {
            var arraySymbol = typeSymbol as IArrayTypeSymbol;
            if (arraySymbol != null)
            {
                return this.OutputFile.TypeRepository.RegisterTypeReferenceBuiltin("Array", new string[] { this.MapTypeReference(arraySymbol.ElementType) });
            }

            var typeName = typeSymbol.GetFullMetadataName();
            if (this.PrimitiveTypeMappings.ContainsKey(typeName))
            {
                return this.OutputFile.TypeRepository.RegisterTypeReferenceBuiltin(this.PrimitiveTypeMappings[typeName]);
            }

            var dictionaryInterface = typeSymbol
                .Interfaces
                .FirstOrDefault(i => i.IsGenericType 
                    && i.ConstructedFrom.GetFullMetadataName() == typeof(IDictionary<,>).FullName
                    && i.TypeArguments[0].GetFullMetadataName() == typeof(string).FullName);
            if (dictionaryInterface != null)
            {
                return this.OutputFile.TypeRepository.RegisterTypeReferenceInlineIndexer("key", this.MapTypeReference(dictionaryInterface.TypeArguments[1]));
            }

            var collectionInterface = typeSymbol.Interfaces.FirstOrDefault(i => i.IsGenericType && i.ConstructedFrom.GetFullMetadataName() == typeof(IEnumerable<>).FullName);
            if (collectionInterface != null)
            {
                return this.OutputFile.TypeRepository.RegisterTypeReferenceBuiltin("Array", new string[] { this.MapTypeReference(collectionInterface.TypeArguments[0]) });
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

        protected CodeFileLtsModel OutputFile
        {
            get
            {
                if (this.singleOutputFile == null)
                {
                    this.singleOutputFile = (CodeFileLtsModel)this.outputStream.CreateCodeFile(
                        string.IsNullOrEmpty(this.Settings.OutputFileName) ? $"IntermediateModelGenerated.ts" : this.Settings.OutputFileName);
                }

                return this.singleOutputFile;
            }
        }
    }
}
