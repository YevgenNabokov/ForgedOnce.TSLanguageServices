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
                CsEmitterHelper.IsNodeCollection(m.Value.Type) ?
                PropertyDeclaration(ParseTypeName(CsEmitterHelper.GetAstModelPropertyTypeName(m.Value, this.settings)), NameHelper.GetSafeVariableName(m.Value.Name))
                .WithAccessorList(
                            SyntaxFactory.AccessorList(
                                SyntaxFactory.List<AccessorDeclarationSyntax>(new AccessorDeclarationSyntax[]
                                {
                                    SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                                })))
                :
                PropertyDeclaration(ParseTypeName(CsEmitterHelper.GetAstModelPropertyTypeName(m.Value, this.settings)), NameHelper.GetSafeVariableName(m.Value.Name))
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
                if (CsEmitterHelper.IsNodeCollection(property.Value.Type))
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
                                    ParseTypeName(CsEmitterHelper.GetAstModelPropertyTypeName(property.Value, this.settings)),
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

            entityClass = entityClass.AddMembers(
                entityModel
                .Members
                .Where(m => !CsEmitterHelper.IsNodeCollection(m.Value.Type))
                .Select(m =>
                FieldDeclaration(VariableDeclaration(ParseTypeName(CsEmitterHelper.GetAstModelPropertyTypeName(m.Value, this.settings)), SeparatedList<VariableDeclaratorSyntax>(new[] { VariableDeclarator(this.GetFieldName(m.Key)) })))
                    ).ToArray<MemberDeclarationSyntax>());

            entityClass = entityClass.AddMembers(entityModel.Members.Select(m => this.CreatePropertyDeclaration(m.Value)).ToArray<MemberDeclarationSyntax>());

            if (entityModel.TsDiscriminant is TransportModelEntityTsDiscriminantSyntaxKind)
            {
                entityClass = entityClass.AddMembers(this.GenerateConversionMethod(entityModel));
            }

            var nsContainer = NamespaceDeclaration(ParseName(this.settings.CsAstModelNamespace));
            nsContainer = nsContainer.AddMembers(entityClass);
            unit = unit.AddMembers(nsContainer);
            outputFile.SyntaxTree = unit.SyntaxTree;
        }

        private MemberDeclarationSyntax CreatePropertyDeclaration(TransportModelEntityMember member)
        {
            if (CsEmitterHelper.IsNode(member.Type))
            {
                if (member.Type.IsCollection)
                {
                    return PropertyDeclaration(ParseTypeName(CsEmitterHelper.GetAstModelPropertyTypeName(member, this.settings)), NameHelper.GetSafeVariableName(member.Name))
                        .WithAccessorList(
                                    SyntaxFactory.AccessorList(
                                        SyntaxFactory.List<AccessorDeclarationSyntax>(new AccessorDeclarationSyntax[]
                                        {
                                            SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                            .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                                            SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                                            .WithModifiers(TokenList(CsEmitterHelper.IsNodeCollection(member.Type) ? new [] { Token(SyntaxKind.PrivateKeyword) } : new SyntaxToken[0]))
                                            .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                                        })))
                        .AddModifiers(Token(SyntaxKind.PublicKeyword));
                }
                else
                {
                    return PropertyDeclaration(ParseTypeName(CsEmitterHelper.GetAstModelPropertyTypeName(member, this.settings)), NameHelper.GetSafeVariableName(member.Name))
                        .WithAccessorList(
                                    SyntaxFactory.AccessorList(
                                        SyntaxFactory.List<AccessorDeclarationSyntax>(new AccessorDeclarationSyntax[]
                                        {
                                            SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                            .WithBody(Block(List<StatementSyntax>(new [] { ReturnStatement(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ThisExpression(), IdentifierName(this.GetFieldName(member.Name)))) }))),
                                            SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                                            .WithBody(
                                                Block(
                                                    List<StatementSyntax>(new [] 
                                                    {
                                                        ExpressionStatement(
                                                            InvocationExpression(
                                                                MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ThisExpression(), IdentifierName("SetAsParentFor")),
                                                                ArgumentList(SeparatedList<ArgumentSyntax>(new [] 
                                                                { 
                                                                    Argument(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ThisExpression(), IdentifierName(this.GetFieldName(member.Name)))),
                                                                    Argument(IdentifierName("value"))
                                                                })))),
                                                        ExpressionStatement(
                                                            AssignmentExpression(
                                                                SyntaxKind.SimpleAssignmentExpression,
                                                                MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ThisExpression(), IdentifierName(this.GetFieldName(member.Name))),
                                                                IdentifierName("value")))
                                                    })))
                                        })))
                        .AddModifiers(Token(SyntaxKind.PublicKeyword));
                }
            }
            else
            {
                if (member.Type.IsCollection)
                {
                    throw new InvalidOperationException("Non-node collections are not supported yet.");
                }

                return PropertyDeclaration(ParseTypeName(CsEmitterHelper.GetAstModelPropertyTypeName(member, this.settings)), NameHelper.GetSafeVariableName(member.Name))
                        .WithAccessorList(
                                    SyntaxFactory.AccessorList(
                                        SyntaxFactory.List<AccessorDeclarationSyntax>(new AccessorDeclarationSyntax[]
                                        {
                                            SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                            .WithBody(Block(List<StatementSyntax>(new [] { ReturnStatement(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ThisExpression(), IdentifierName(this.GetFieldName(member.Name)))) }))),
                                            SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                                            .WithBody(
                                                Block(
                                                    List<StatementSyntax>(new []
                                                    {
                                                        ExpressionStatement(
                                                            InvocationExpression(
                                                                MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ThisExpression(), IdentifierName("EnsureIsEditable")),
                                                                ArgumentList(SeparatedList<ArgumentSyntax>()))),
                                                        ExpressionStatement(
                                                            AssignmentExpression(
                                                                SyntaxKind.SimpleAssignmentExpression,
                                                                MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ThisExpression(), IdentifierName(this.GetFieldName(member.Name))),
                                                                IdentifierName("value")))
                                                    })))
                                        })))
                        .AddModifiers(Token(SyntaxKind.PublicKeyword));
            }
        }

        private string GetFieldName(string propertyName)
        {
            return NameHelper.GetSafeVariableName($"_{propertyName}");
        }

        private MethodDeclarationSyntax GenerateConversionMethod(TransportModelEntity entityModel)
        {
            var members = CsEmitterHelper.GetMembers(entityModel, null, true);

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

        private IEnumerable<ParameterSyntax> GetConstructorParameters(TransportModelEntity entityModel, out List<StatementSyntax> propertyInitializers, out List<ArgumentSyntax> baseConstructorArguments)
        {
            List<ParameterSyntax> result = new List<ParameterSyntax>();
            List<StatementSyntax> initializers = new List<StatementSyntax>();
            List<ArgumentSyntax> baseArgs = new List<ArgumentSyntax>();

            var members = CsEmitterHelper.GetMembers(entityModel);
            var baseMembers = entityModel.BaseEntity != null 
                ? CsEmitterHelper.GetMembers(entityModel.BaseEntity.TransportModelItem, entityModel.BaseEntity.GenericArguments)
                : new Dictionary<string, TransportModelEntityMember>();

            foreach (var member in members)
            {
                if (member.Key != "kind")
                {
                    result.Add(Parameter(List<AttributeListSyntax>(), TokenList(), ParseTypeName(CsEmitterHelper.GetAstModelPropertyTypeName(member.Value, this.settings, true)), Identifier(NameHelper.GetSafeVariableName(member.Key)), null));

                    if (baseMembers.ContainsKey(member.Key))
                    {
                        baseArgs.Add(Argument(IdentifierName(NameHelper.GetSafeVariableName(member.Key))));
                    }
                    else
                    {
                        if (CsEmitterHelper.IsNodeCollection(member.Value.Type))
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
                                    ObjectCreationExpression(ParseTypeName(CsEmitterHelper.GetAstModelPropertyTypeName(member, this.settings)), ArgumentList(), null))));
                }
            }

            propertyInitializers = initializers;
            baseConstructorArguments = baseArgs;
            return result;
        }
    }
}
