using ForgedOnce.Core.Interfaces;
using ForgedOnce.CSharp;
using ForgedOnce.CSharp.Helpers.Syntax.Generation;
using ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.Emitters
{
    public class CsTransportModelEmitter
    {
        private readonly Settings settings;

        public CsTransportModelEmitter(Settings settings)
        {
            this.settings = settings;
        }

        public void Emit(Parameters parameters, ICodeStream output)
        {
            foreach (var enumModel in parameters.TransportModel.TransportModelEnums)
            {
                this.EmitEnum(enumModel.Value, output);
            }

            foreach (var entityModel in parameters.TransportModel.TransportModelEntities)
            {
                this.EmitEntity(entityModel.Value, output);
            }

            foreach (var interfaceModel in parameters.TransportModel.TransportModelInterfaces)
            {
                this.EmitInterface(interfaceModel.Value, output);
            }
        }

        private void EmitEnum(TransportModelEnum enumModel, ICodeStream output)
        {
            var outputFile = (CodeFileCSharp)output.CreateCodeFile($"{EmitterHelper.GetCSharpTransportModelShortName(enumModel)}.cs");

            var unit = CompilationUnit();
            unit = unit.AddUsings(
                UsingDirective(ParseName(nameof(System))));

            var enumDeclaration = EnumDeclaration(EmitterHelper.GetCSharpTransportModelShortName(enumModel));
            enumDeclaration = enumDeclaration.AddModifiers(Token(SyntaxKind.PublicKeyword));

            enumDeclaration = enumDeclaration.WithMembers(SeparatedList<EnumMemberDeclarationSyntax>(enumModel.Members.Values.Select(EmitEnumMember)));

            if (enumModel.IsFlags)
            {
                enumDeclaration = enumDeclaration.WithAttributeLists(
                    List<AttributeListSyntax>(
                        new[] { AttributeList(
                            SingletonSeparatedList<AttributeSyntax>(
                                Attribute(
                                    IdentifierName(typeof(System.FlagsAttribute).FullName)))) 
                        }));
            }

            var nsContainer = NamespaceDeclaration(ParseName(this.settings.CsTransportModelNamespace));
            nsContainer = nsContainer.AddMembers(enumDeclaration);
            unit = unit.AddMembers(nsContainer);
            outputFile.SyntaxTree = unit.SyntaxTree;
        }

        private EnumMemberDeclarationSyntax EmitEnumMember(TransportModelEnumMember member)
        {
            var result = EnumMemberDeclaration(member.Name);

            if (member.Value != null)
            {
                result = result.WithEqualsValue(EqualsValueClause(LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(member.Value.Value))));
            }

            return result;
        }

        private void EmitEntity(TransportModelEntity entityModel, ICodeStream output)
        {
            var outputFile = (CodeFileCSharp)output.CreateCodeFile($"{EmitterHelper.GetCSharpTransportModelShortName(entityModel)}.cs");

            var unit = CompilationUnit();
            unit = unit.AddUsings(
                UsingDirective(ParseName(nameof(System))));

            var entityClass = ClassDeclaration(EmitterHelper.GetCSharpTransportModelShortName(entityModel));
            entityClass = entityClass.AddModifiers(Token(SyntaxKind.PublicKeyword));

            if (entityModel.TsDiscriminant is TransportModelEntityTsDiscriminantSyntaxKind kindDiscriminant)
            {
                entityClass = entityClass.AddMembers(
                    ConstructorDeclaration(EmitterHelper.GetCSharpTransportModelShortName(entityModel))
                    .AddModifiers(Token(SyntaxKind.PublicKeyword))
                    .WithBody(Block().AddStatements(
                        ExpressionStatement(
                        AssignmentExpression(
                            SyntaxKind.SimpleAssignmentExpression,
                            MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                ThisExpression(),
                                IdentifierName("kind")),
                            MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                IdentifierName($"{this.settings.CsTransportModelNamespace}.SyntaxKind"),
                                IdentifierName(kindDiscriminant.SyntaxKindValueName)))))));
            }

            if (entityModel.GenericParameters.Count > 0)
            {
                entityClass = entityClass.WithTypeParameterList(TypeParameterList(SeparatedList<TypeParameterSyntax>(entityModel.GenericParameters.Select(p => TypeParameter(p.Key)))));

                entityClass = entityClass.WithConstraintClauses(List<TypeParameterConstraintClauseSyntax>(
                    entityModel.GenericParameters.Select(p => 
                    TypeParameterConstraintClause(
                    IdentifierName(p.Key),
                    SeparatedList<TypeParameterConstraintSyntax>(new[] { TypeConstraint(ParseTypeName(EmitterHelper.GetGenericParameterConstraintTypeName(p.Value))) })))));
            }

            List<string> baseTypes = new List<string>();

            if (entityModel.BaseEntity != null)
            {
                baseTypes.Add(EmitterHelper.GetCSharpTransportModelReferenceName(entityModel.BaseEntity, this.settings));
            }

            foreach (var interfaceModel in entityModel.Interfaces)
            {
                baseTypes.Add(EmitterHelper.GetCSharpTransportModelFullyQualifiedName(interfaceModel, this.settings));
            }

            if (baseTypes.Count > 0)
            {
                entityClass = entityClass.WithBaseList(BaseList(SeparatedList<BaseTypeSyntax>(baseTypes.Select(t => SimpleBaseType(ParseTypeName(t))))));
            }

            entityClass = entityClass.AddMembers(entityModel.Members.Select(m => 
                PropertyDeclaration(ParseTypeName(this.GetPropertyTypeName(m.Value)), NameHelper.GetSafeVariableName(m.Value.Name))
                .WithAccessorList(
                            SyntaxFactory.AccessorList(
                                SyntaxFactory.List<AccessorDeclarationSyntax>(new AccessorDeclarationSyntax[]
                                {
                                    SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                                    SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                                })))
                .AddModifiers(Token(SyntaxKind.PublicKeyword))
                ).ToArray<MemberDeclarationSyntax>());

            var nsContainer = NamespaceDeclaration(ParseName(this.settings.CsTransportModelNamespace));
            nsContainer = nsContainer.AddMembers(entityClass);
            unit = unit.AddMembers(nsContainer);
            outputFile.SyntaxTree = unit.SyntaxTree;
        }

        private void EmitInterface(TransportModelInterface model, ICodeStream output)
        {
            var outputFile = (CodeFileCSharp)output.CreateCodeFile($"{EmitterHelper.GetCSharpTransportModelShortName(model)}.cs");

            var unit = CompilationUnit();
            unit = unit.AddUsings(
                UsingDirective(ParseName(nameof(System))));

            var entityInterface = InterfaceDeclaration(EmitterHelper.GetCSharpTransportModelShortName(model));
            entityInterface = entityInterface.AddModifiers(Token(SyntaxKind.PublicKeyword));

            if (model.GenericParameters.Count > 0)
            {
                entityInterface = entityInterface.WithTypeParameterList(TypeParameterList(SeparatedList<TypeParameterSyntax>(model.GenericParameters.Select(p => TypeParameter(p.Key)))));

                entityInterface = entityInterface.WithConstraintClauses(List<TypeParameterConstraintClauseSyntax>(
                    model.GenericParameters.Select(p =>
                    TypeParameterConstraintClause(
                    IdentifierName(p.Key),
                    SeparatedList<TypeParameterConstraintSyntax>(new[] { TypeConstraint(ParseTypeName(EmitterHelper.GetGenericParameterConstraintTypeName(p.Value))) })))));
            }

            List<string> baseTypes = new List<string>();

            foreach (var interfaceModel in model.Interfaces)
            {
                baseTypes.Add(EmitterHelper.GetCSharpTransportModelFullyQualifiedName(interfaceModel, this.settings));
            }

            if (baseTypes.Count > 0)
            {
                entityInterface = entityInterface.WithBaseList(BaseList(SeparatedList<BaseTypeSyntax>(baseTypes.Select(t => SimpleBaseType(ParseTypeName(t))))));
            }

            entityInterface = entityInterface.WithMembers(List<MemberDeclarationSyntax>(model.Members.Select(m =>
                PropertyDeclaration(ParseTypeName(this.GetPropertyTypeName(m.Value)), NameHelper.GetSafeVariableName(m.Value.Name))
                .WithAccessorList(
                            SyntaxFactory.AccessorList(
                                SyntaxFactory.List<AccessorDeclarationSyntax>(new AccessorDeclarationSyntax[]
                                {
                                    SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                                    SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                                })))
                )));

            var nsContainer = NamespaceDeclaration(ParseName(this.settings.CsTransportModelNamespace));
            nsContainer = nsContainer.AddMembers(entityInterface);
            unit = unit.AddMembers(nsContainer);
            outputFile.SyntaxTree = unit.SyntaxTree;
        }

        private string GetPropertyTypeName(TransportModelEntityMember member)
        {
            if (member.IsNullable 
                && member.Type is TransportModelTypeReferencePrimitive primitiveReference
                && primitiveReference.PrimitiveType != TransportModelPrimitiveType.String
                && primitiveReference.PrimitiveType != TransportModelPrimitiveType.Object
                && !member.Type.IsCollection)
            {
                var name = EmitterHelper.CreatePrimitiveTypeName(primitiveReference, this.settings);

                return $"System.Nullable<{name}>";
            }

            return EmitterHelper.GetCSharpTransportModelReferenceName(member.Type, this.settings);
        }
    }
}
