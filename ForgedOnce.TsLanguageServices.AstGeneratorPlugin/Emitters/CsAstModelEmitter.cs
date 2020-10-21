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
using System.Linq.Expressions;
using System.Text;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.Emitters
{
    public class CsAstModelEmitter
    {
        private readonly Settings settings;

        private readonly string baseNodeType = "StNodeBase";

        private readonly string baseNodeTypeInterface = "IStNodeBase";

        public CsAstModelEmitter(Settings settings)
        {
            this.settings = settings;
        }

        public void Emit(Parameters parameters, ICodeStream output)
        {
            foreach (var entityModel in parameters.TransportModel.TransportModelEntities)
            {
                this.EmitEntity(entityModel.Value, output);
            }

            foreach (var interfaceModel in parameters.TransportModel.TransportModelInterfaces)
            {
                this.EmitInterface(interfaceModel.Value, output);
            }
        }

        private void EmitInterface(TransportModelInterface model, ICodeStream output)
        {
            var outputFile = (CodeFileCSharp)output.CreateCodeFile($"{CsEmitterHelper.GetCSharpModelShortName(model, ModelType.Ast)}.cs");

            var unit = CompilationUnit();
            unit = unit.AddUsings(
                UsingDirective(ParseName(nameof(System))));

            var entityInterface = InterfaceDeclaration(CsEmitterHelper.GetCSharpModelShortName(model, ModelType.Ast));
            entityInterface = entityInterface.AddModifiers(Token(SyntaxKind.PublicKeyword));

            if (model.GenericParameters.Count > 0)
            {
                entityInterface = entityInterface.WithTypeParameterList(TypeParameterList(SeparatedList<TypeParameterSyntax>(model.GenericParameters.Select(p => TypeParameter(p.Key)))));

                entityInterface = entityInterface.WithConstraintClauses(List<TypeParameterConstraintClauseSyntax>(
                    model.GenericParameters.Select(p =>
                    TypeParameterConstraintClause(
                    IdentifierName(p.Key),
                    SeparatedList<TypeParameterConstraintSyntax>(new[] { TypeConstraint(ParseTypeName(CsEmitterHelper.GetModelGenericParameterConstraintTypeName(p.Value, ModelType.Ast))) })))));
            }

            List<string> baseTypes = new List<string>();

            if (model.Name == this.settings.AstNodeBaseTypeQualified.Split('.').Last())
            {
                baseTypes.Add($"{settings.CsAstModelNamespace}.{baseNodeTypeInterface}");
            }

            foreach (var interfaceModel in model.Interfaces)
            {
                baseTypes.Add(CsEmitterHelper.GetCSharpModelFullyQualifiedName(interfaceModel, this.settings, ModelType.Ast));
            }

            if (baseTypes.Count > 0)
            {
                entityInterface = entityInterface.WithBaseList(BaseList(SeparatedList<BaseTypeSyntax>(baseTypes.Select(t => SimpleBaseType(ParseTypeName(t))))));
            }

            entityInterface = entityInterface.WithMembers(List<MemberDeclarationSyntax>(model.Members.Select(m =>
                PropertyDeclaration(ParseTypeName(this.GetTypeName(m.Value)), NameHelper.GetSafeVariableName(m.Value.Name))
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

            var nsContainer = NamespaceDeclaration(ParseName(this.settings.CsAstModelNamespace));
            nsContainer = nsContainer.AddMembers(entityInterface);
            unit = unit.AddMembers(nsContainer);
            outputFile.SyntaxTree = unit.SyntaxTree;
        }

        private void EmitEntity(TransportModelEntity entityModel, ICodeStream output)
        {
            var outputFile = (CodeFileCSharp)output.CreateCodeFile($"{CsEmitterHelper.GetCSharpModelShortName(entityModel, ModelType.Ast)}.cs");

            var unit = CompilationUnit();
            unit = unit.AddUsings(
                UsingDirective(ParseName(nameof(System))));

            var entityClass = ClassDeclaration(CsEmitterHelper.GetCSharpModelShortName(entityModel, ModelType.Ast));
            entityClass = entityClass.AddModifiers(Token(SyntaxKind.PublicKeyword));

            if (entityModel.TsDiscriminant == null || !(entityModel.TsDiscriminant is TransportModelEntityTsDiscriminantSyntaxKind))
            {
                entityClass = entityClass.AddModifiers(Token(SyntaxKind.AbstractKeyword));
            }

            List<StatementSyntax> propertyInitializers = null;
            List<ArgumentSyntax> baseConstructorArguments = null;

            var constructorDeclaration =
                ConstructorDeclaration(CsEmitterHelper.GetCSharpModelShortName(entityModel, ModelType.Ast))
                .AddModifiers(Token(SyntaxKind.PublicKeyword))
                .WithParameterList(ParameterList(SeparatedList<ParameterSyntax>(this.GetConstructorParameters(entityModel, out propertyInitializers, out baseConstructorArguments))));

            if (baseConstructorArguments != null && baseConstructorArguments.Count > 0)
            {
                constructorDeclaration = constructorDeclaration.WithInitializer(
                    ConstructorInitializer(SyntaxKind.BaseConstructorInitializer)
                    .AddArgumentListArguments(baseConstructorArguments.ToArray()));
            }

            var constructorBody = Block();

            if (entityModel.TsDiscriminant is TransportModelEntityTsDiscriminantSyntaxKind kindDiscriminant)
            {
                constructorBody = constructorBody.AddStatements(
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
                                IdentifierName(kindDiscriminant.SyntaxKindValueName)))));
            }

            foreach (var property in entityModel.Members)
            {
                if (property.Value.Type.IsCollection
                    && property.Value.Type is ITransportModelTypeReferenceTransportModelItem<TransportModelItem> modelItemReference
                    && !(modelItemReference.TransportModelItem is TransportModelEnum))
                {
                    constructorBody = constructorBody.AddStatements(
                        ExpressionStatement(
                            AssignmentExpression(
                                SyntaxKind.SimpleAssignmentExpression,
                                MemberAccessExpression(
                                    SyntaxKind.SimpleMemberAccessExpression,
                                    ThisExpression(),
                                    IdentifierName(NameHelper.GetSafeVariableName(property.Key))),
                                ObjectCreationExpression(
                                    ParseTypeName(this.GetTypeName(property.Value)),
                                    ArgumentList(SeparatedList<ArgumentSyntax>(new[] { Argument(ThisExpression()) })),
                                    null))));
                }
            }

            if (propertyInitializers != null && propertyInitializers.Count > 0)
            {
                constructorBody = constructorBody.AddStatements(propertyInitializers.ToArray());
            }

            constructorDeclaration = constructorDeclaration.WithBody(constructorBody);
            entityClass = entityClass.AddMembers(constructorDeclaration);

            if (entityModel.GenericParameters.Count > 0)
            {
                entityClass = entityClass.WithTypeParameterList(TypeParameterList(SeparatedList<TypeParameterSyntax>(entityModel.GenericParameters.Select(p => TypeParameter(p.Key)))));

                entityClass = entityClass.WithConstraintClauses(List<TypeParameterConstraintClauseSyntax>(
                    entityModel.GenericParameters.Select(p =>
                    TypeParameterConstraintClause(
                    IdentifierName(p.Key),
                    SeparatedList<TypeParameterConstraintSyntax>(new[] { TypeConstraint(ParseTypeName(CsEmitterHelper.GetModelGenericParameterConstraintTypeName(p.Value, ModelType.Ast))) })))));
            }

            List<string> baseTypes = new List<string>();

            if (entityModel.Name == this.settings.AstNodeBaseTypeQualified.Split('.').Last())
            {
                baseTypes.Add($"{settings.CsAstModelNamespace}.{baseNodeType}");
            }

            if (entityModel.BaseEntity != null)
            {
                baseTypes.Add(CsEmitterHelper.GetCSharpModelReferenceName(entityModel.BaseEntity, this.settings, ModelType.Ast));
            }

            foreach (var interfaceModel in entityModel.Interfaces)
            {
                baseTypes.Add(CsEmitterHelper.GetCSharpModelFullyQualifiedName(interfaceModel, this.settings, ModelType.Ast));
            }

            if (baseTypes.Count > 0)
            {
                entityClass = entityClass.WithBaseList(BaseList(SeparatedList<BaseTypeSyntax>(baseTypes.Select(t => SimpleBaseType(ParseTypeName(t))))));
            }

            entityClass = entityClass.AddMembers(entityModel.Members.Select(m =>
                PropertyDeclaration(ParseTypeName(this.GetTypeName(m.Value)), NameHelper.GetSafeVariableName(m.Value.Name))
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

            if (entityModel.TsDiscriminant is TransportModelEntityTsDiscriminantSyntaxKind)
            {
                entityClass = entityClass.AddMembers(this.GenerateConversionMethod(entityModel));
            }

            var nsContainer = NamespaceDeclaration(ParseName(this.settings.CsAstModelNamespace));
            nsContainer = nsContainer.AddMembers(entityClass);
            unit = unit.AddMembers(nsContainer);
            outputFile.SyntaxTree = unit.SyntaxTree;
        }

        private MethodDeclarationSyntax GenerateConversionMethod(TransportModelEntity entityModel)
        {
            var members = this.GetMembers(entityModel, null, true);

            List<ExpressionSyntax> initializers = new List<ExpressionSyntax>();

            foreach (var member in members)
            {
                var propertyName = NameHelper.GetSafeVariableName(member.Key);

                if (member.Value.Type is ITransportModelTypeReferenceTransportModelItem<TransportModelItem> itemReference
                    && !(itemReference.TransportModelItem is TransportModelEnum))
                {
                    if (itemReference.IsCollection)
                    {
                        initializers.Add(
                            AssignmentExpression(
                                SyntaxKind.SimpleAssignmentExpression,
                                IdentifierName(propertyName),
                                InvocationExpression(
                                    MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        ThisExpression(),
                                        GenericName(
                                            Identifier("GetTransportModelNodes"),
                                            TypeArgumentList(
                                                SeparatedList<TypeSyntax>(
                                                    new[] 
                                                    {
                                                        ParseTypeName(CsEmitterHelper.GetCSharpModelFullyQualifiedName(itemReference.TransportModelItem, this.settings, ModelType.Transport))
                                                    })))))
                                .WithArgumentList(ArgumentList(SeparatedList<ArgumentSyntax>(new[] { Argument(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ThisExpression(), IdentifierName(propertyName))) })))
                                ));
                    }
                    else
                    {
                        initializers.Add(
                            AssignmentExpression(
                                SyntaxKind.SimpleAssignmentExpression,
                                IdentifierName(propertyName),
                                ConditionalExpression(
                                    BinaryExpression(SyntaxKind.NotEqualsExpression, MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ThisExpression(), IdentifierName(propertyName)), IdentifierName("null")), 
                                    CastExpression(ParseTypeName(CsEmitterHelper.GetPropertyTypeName(member.Value, this.settings, ModelType.Transport)),
                                    InvocationExpression(
                                        MemberAccessExpression(
                                            SyntaxKind.SimpleMemberAccessExpression,
                                            MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ThisExpression(), IdentifierName(propertyName)),
                                            IdentifierName("GetTransportModelNode")))
                                    .WithArgumentList(ArgumentList())),
                                    IdentifierName("null")
                                )));
                    }
                }
                else
                {
                    initializers.Add(
                            AssignmentExpression(
                                SyntaxKind.SimpleAssignmentExpression,
                                IdentifierName(propertyName),
                                MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ThisExpression(), IdentifierName(propertyName))));
                }
            }

            return MethodDeclaration(ParseTypeName(typeof(object).FullName), "GetTransportModelNode")
                .WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.OverrideKeyword)))
                .WithParameterList(ParameterList())
                .WithBody(
                    Block(
                        List<StatementSyntax>(
                            new[] { 
                                ReturnStatement(
                                    ObjectCreationExpression(ParseTypeName(CsEmitterHelper.GetCSharpModelFullyQualifiedName(entityModel, this.settings, ModelType.Transport)))
                                    .WithArgumentList(ArgumentList())
                                    .WithInitializer(
                                        InitializerExpression(SyntaxKind.ObjectInitializerExpression, SeparatedList<ExpressionSyntax>(initializers))))
                            })));
        }

        private bool IsNodeCollection(TransportModelTypeReference reference)
        {
            return reference.IsCollection
                && reference is ITransportModelTypeReferenceTransportModelItem<TransportModelItem> itemReference
                && !(itemReference.TransportModelItem is TransportModelEnum);
        }

        private IEnumerable<ParameterSyntax> GetConstructorParameters(TransportModelEntity entityModel, out List<StatementSyntax> propertyInitializers, out List<ArgumentSyntax> baseConstructorArguments)
        {
            List<ParameterSyntax> result = new List<ParameterSyntax>();
            List<StatementSyntax> initializers = new List<StatementSyntax>();
            List<ArgumentSyntax> baseArgs = new List<ArgumentSyntax>();

            var members = this.GetMembers(entityModel);
            var baseMembers = entityModel.BaseEntity != null 
                ? this.GetMembers(entityModel.BaseEntity.TransportModelItem, entityModel.BaseEntity.GenericArguments)
                : new Dictionary<string, TransportModelEntityMember>();

            foreach (var member in members)
            {
                if (member.Key != "kind")
                {
                    result.Add(Parameter(List<AttributeListSyntax>(), TokenList(), ParseTypeName(this.GetTypeName(member.Value, true)), Identifier(NameHelper.GetSafeVariableName(member.Key)), null));

                    if (baseMembers.ContainsKey(member.Key))
                    {
                        baseArgs.Add(Argument(IdentifierName(NameHelper.GetSafeVariableName(member.Key))));
                    }
                    else
                    {
                        if (this.IsNodeCollection(member.Value.Type))
                        {
                            initializers.Add(
                            ExpressionStatement(
                                    InvocationExpression(
                                    MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ThisExpression(), IdentifierName(NameHelper.GetSafeVariableName(member.Key))),
                                        IdentifierName("AddRange")),
                                    ArgumentList(SeparatedList<ArgumentSyntax>(new[] { Argument(IdentifierName(NameHelper.GetSafeVariableName(member.Key))) })))));
                        }
                        else
                        {
                            initializers.Add(
                            ExpressionStatement(
                                AssignmentExpression(
                                    SyntaxKind.SimpleAssignmentExpression,
                                    MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ThisExpression(), IdentifierName(NameHelper.GetSafeVariableName(member.Key))),
                                    IdentifierName(NameHelper.GetSafeVariableName(member.Key)))));
                        }
                    }
                }
            }

            if (entityModel.TsDiscriminant is TransportModelEntityTsDiscriminantBrand brandDiscriminant)
            {
                var member = entityModel.GetMemberByName(brandDiscriminant.BrandPropertyName);
                if (member != null)
                {
                    initializers.Add(
                            ExpressionStatement(
                                AssignmentExpression(
                                    SyntaxKind.SimpleAssignmentExpression,
                                    MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ThisExpression(), IdentifierName(NameHelper.GetSafeVariableName(member.Name))),
                                    ObjectCreationExpression(ParseTypeName(this.GetTypeName(member)), ArgumentList(), null))));
                }
            }

            propertyInitializers = initializers;
            baseConstructorArguments = baseArgs;
            return result;
        }

        private Dictionary<string, TransportModelEntityMember> GetMembers(TransportModelEntity entityModel, List<TransportModelTypeReference> genericArgumentsInScope = null, bool allMembers = false)
        {
            Dictionary<string, TransportModelEntityMember> result = new Dictionary<string, TransportModelEntityMember>();

            if (entityModel.BaseEntity != null)
            {
                result = this.GetMembers(entityModel.BaseEntity.TransportModelItem, entityModel.BaseEntity.GenericArguments, allMembers);
            }

            var members = entityModel.Members.Keys.Select(m => genericArgumentsInScope == null ? entityModel.GetMemberByName(m) : entityModel.GetMemberByNameAndResolveGenericArguments(m, genericArgumentsInScope));

            foreach (var member in members)
            {
                var finalMember = member;

                if (entityModel.MemberTypeLimiters.ContainsKey(member.Name))
                {
                    finalMember = entityModel.MemberTypeLimiters[member.Name];
                }

                if (result.ContainsKey(member.Name))
                {
                    result[member.Name] = finalMember;
                }
                else
                {
                    result.Add(member.Name, finalMember);
                }
            }

            if (!allMembers && entityModel.TsDiscriminant is TransportModelEntityTsDiscriminantBrand brandDiscriminant && result.ContainsKey(brandDiscriminant.BrandPropertyName))
            {
                result.Remove(brandDiscriminant.BrandPropertyName);
            }

            return result;
        }

        private string GetTypeName(TransportModelEntityMember member, bool useSimpleCollections = false)
        {
            if (member.Type is ITransportModelTypeReferenceTransportModelItem<TransportModelItem> itemReference && itemReference.TransportModelItem is TransportModelEnum)
            {
                return CsEmitterHelper.CreateModelTypeName(itemReference, this.settings, ModelType.Transport, useSimpleCollections);
            }
            else
            {
                return CsEmitterHelper.GetPropertyTypeName(member, this.settings, ModelType.Ast, useSimpleCollections);
            }
        }
    }
}
