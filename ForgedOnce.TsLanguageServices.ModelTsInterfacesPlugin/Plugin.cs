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
using ForgedOnce.CSharp.Helpers.SemanticAnalysis;
using ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel;
using ForgedOnce.TsLanguageServices.FullSyntaxTree.AstBuilder;

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
                { typeof(decimal), "number" },
                { typeof(float), "number" },
                { typeof(Guid), "string" },
                { typeof(DateTime), "Date" },
            },
            ComplexTypeMappings = new Dictionary<Type, Func<IStTypeNode>>()
            {
                { typeof(int?), () => new StUnionTypeNode().WithType(new StKeywordTypeNodeNumberKeyword()).WithType(new StKeywordTypeNodeNullKeyword()) },
                { typeof(float?), () => new StUnionTypeNode().WithType(new StKeywordTypeNodeNumberKeyword()).WithType(new StKeywordTypeNodeNullKeyword()) },
                { typeof(bool?), () => new StUnionTypeNode().WithType(new StKeywordTypeNodeBooleanKeyword()).WithType(new StKeywordTypeNodeNullKeyword()) },
                { typeof(DateTime?), () => new StUnionTypeNode().WithType(new StExpressionWithTypeArguments().WithExpression(new StIdentifier().WithEscapedText("Date"))).WithType(new StKeywordTypeNodeNullKeyword()) },
            }
        };

        protected ICodeStream outputStream;

        protected CodeFileTs singleOutputFile;

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
                result.ComplexTypeMappings.Add(typeof(string), () => new StUnionTypeNode().WithType(new StKeywordTypeNodeStringKeyword()).WithType(new StKeywordTypeNodeNullKeyword()));
            }

            return result;
        }

        protected override List<ICodeStream> CreateOutputs(ICodeStreamFactory codeStreamFactory)
        {
            List<ICodeStream> result = new List<ICodeStream>();
            this.outputStream = codeStreamFactory.CreateCodeStream(Languages.TypeScript, OutStreamName);
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

            var heritage = new StHeritageClause()
                .WithToken(FullSyntaxTree.TransportModel.SyntaxKind.ExtendsKeyword);

            var interfaceDefinition = new StInterfaceDeclaration()
                .WithModifier(new StExportKeywordToken())
                .WithName(new StIdentifier().WithEscapedText(classSymbol.Name));

            var addHeritage = false;
            if (classSymbol.BaseType != null && typeof(object).FullName != classSymbol.BaseType.GetFullMetadataName())
            {
                var baseType = this.MapTypeReference(classSymbol.BaseType, typeMappings);
                if (baseType != null && baseType is StExpressionWithTypeArguments expressionWithTypeArguments)
                {
                    heritage.WithType(t => expressionWithTypeArguments);
                    addHeritage = true;
                }
            }

            if (addHeritage)
            {
                interfaceDefinition.WithHeritageClaus(b => heritage);
            }

            foreach (var member in members)
            {
                interfaceDefinition.WithMember(
                    new StPropertySignature()
                    .WithName(new StIdentifier().WithEscapedText(member.Name))
                    .WithType(this.MapTypeReference(member.Type, typeMappings, true)));
            }

            this.OutputFile.Model.statements.Add(interfaceDefinition);
        }

        protected IStTypeNode MapTypeReference(ITypeSymbol typeSymbol, TypeMappings typeMappings, bool forField = false)
        {
            var arraySymbol = typeSymbol as IArrayTypeSymbol;
            if (arraySymbol != null)
            {
                return new StExpressionWithTypeArguments()
                    .WithExpression(new StIdentifier().WithEscapedText("Array"))
                    .WithTypeArgument(this.MapTypeReference(arraySymbol.ElementType, typeMappings));
            }

            foreach (var mapping in typeMappings.PrimitiveTypeMappings)
            {
                if (this.TypeMatches(typeSymbol, mapping.Key))
                {
                    return new StExpressionWithTypeArguments().WithExpression(new StIdentifier().WithEscapedText(mapping.Value));
                }
            }

            foreach (var mapping in typeMappings.ComplexTypeMappings)
            {
                if (this.TypeMatches(typeSymbol, mapping.Key))
                {
                    return mapping.Value();
                }
            }

            var dictionaryInterface = typeSymbol
            .Interfaces
            .FirstOrDefault(i => i.IsGenericType
                && i.ConstructedFrom.GetFullMetadataName() == typeof(IDictionary<,>).FullName
                && i.TypeArguments[0].GetFullMetadataName() == typeof(string).FullName);
            if (dictionaryInterface != null)
            {
                return
                    new StTypeLiteralNode()
                    .WithMember(
                        new StIndexSignatureDeclaration()
                        .WithParameter(p => p.WithName(new StIdentifier().WithEscapedText("key")).WithType(new StKeywordTypeNodeStringKeyword()))
                        .WithType(this.MapTypeReference(dictionaryInterface.TypeArguments[1], typeMappings)));
            }

            var collectionInterface = typeSymbol.Interfaces.FirstOrDefault(i => i.IsGenericType && i.ConstructedFrom.GetFullMetadataName() == typeof(IEnumerable<>).FullName);
            if (collectionInterface != null)
            {
                return new StExpressionWithTypeArguments()
                    .WithExpression(new StIdentifier().WithEscapedText("Array"))
                    .WithTypeArgument(this.MapTypeReference(collectionInterface.TypeArguments[0], typeMappings));
            }

            if (this.HasBaseModelNamespace(typeSymbol))
            {
                if ((this.Settings.NullableNodes || this.Settings.OptionalNodes) && forField)
                {
                    var union = new StUnionTypeNode()
                        .WithType(new StExpressionWithTypeArguments()
                    .WithExpression(new StIdentifier().WithEscapedText(typeSymbol.Name)));

                    if (this.Settings.NullableNodes)
                    {
                        union.types.Add(new StKeywordTypeNodeNullKeyword());
                    }

                    if (this.Settings.OptionalNodes)
                    {
                        union.types.Add(new StKeywordTypeNodeUndefinedKeyword());
                    }

                    return union;
                }
                else
                {
                    return new StExpressionWithTypeArguments()
                    .WithExpression(new StIdentifier().WithEscapedText(typeSymbol.Name));
                }
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

            var enumDefinition = new StEnumDeclaration()
                .WithModifier(new StExportKeywordToken())
                .WithName(new StIdentifier().WithEscapedText(declaredSymbol.Name));

            var members = declaredSymbol.GetMembers()
                .Where(m => m.DeclaredAccessibility == Accessibility.Public && m.IsStatic && m.Kind == SymbolKind.Field)
                .OfType<IFieldSymbol>()
                .Where(f => f.IsConst && f.IsDefinition)
                .ToArray();

            foreach (var member in members)
            {
                enumDefinition.WithMember(m =>
                    m
                    .WithName(new StIdentifier().WithEscapedText(member.Name)));
            }

            this.OutputFile.Model.statements.Add(enumDefinition);
        }

        protected bool HasBaseModelNamespace(ITypeSymbol symbol)
        {
            return string.IsNullOrEmpty(this.Settings.ModelBaseNamespace) || symbol.ContainingNamespace.ToDisplayString().StartsWith(this.Settings.ModelBaseNamespace);
        }

        protected CodeFileTs OutputFile
        {
            get
            {
                if (this.singleOutputFile == null)
                {
                    this.singleOutputFile = (CodeFileTs)this.outputStream.CreateCodeFile(
                        string.IsNullOrEmpty(this.Settings.OutputFileName) ? $"IntermediateModelGenerated.ts" : this.Settings.OutputFileName);
                    this.singleOutputFile.Model = new StRoot();
                }

                return this.singleOutputFile;
            }
        }
    }
}
