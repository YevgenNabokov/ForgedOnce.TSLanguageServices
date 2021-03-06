﻿using ForgedOnce.TsLanguageServices.AstDescription.Model;
using ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.PreprocessorParts.ParametersCreation
{
    public class ParametersBuilder
    {
        private readonly Settings pluginSettings;

        public ParametersBuilder(Settings pluginSettings)
        {
            this.pluginSettings = pluginSettings;
        }

        public Parameters CreateParameters(AstDescription astDescription)
        {
            var nonKindSpecifiedInterfaces = astDescription
                .AstDeclarations
                .Select(g => g.Value)
                .Select(d => d.NamedDeclaration)
                .OfType<InterfaceDescription>()
                .Where(d => !d.Members.Any(m => m.Property != null && m.Property.Name == "kind"))
                .ToArray();

            var nonInheritednonKindSpecifiedInterfaces = nonKindSpecifiedInterfaces
                .Where(nk => !astDescription
                    .AstDeclarations
                    .Select(g => g.Value)
                    .Any(d => d.InheritedTypes.Any(r => r.Named != null && r.Named.Name == nk.Name)))
                .Select(nk => nk.Name)
                .ToArray();

            var referredNonEnums = astDescription
                .ReferredDeclarations
                .Select(g => g.Value)
                .Select(d => d.NamedDeclaration)
                .Where(d => !(d is EnumDescription))
                .Select(nk => nk.Name)
                .ToArray();

            var result = new Parameters();

            var transportModelParametersBuilder = new TransportModelParametersBuilder(new ModelSettings(this.pluginSettings));

            result.TransportModel = transportModelParametersBuilder.Create(astDescription);

            this.AddSurrogateRootNode(result);

            this.Validate(result);

            return result;
        }

        protected void AddSurrogateRootNode(Parameters parameters)
        {
            var statementsPropertyName = "statements";

            TransportModelEntity root = new TransportModelEntity()
            {
                BaseEntity = new TransportModelTypeReferenceTransportModelItem<TransportModelEntity>()
                {
                    TransportModelItem = parameters.TransportModel.TransportModelEntities["Node"]
                },
                Name = "Root",
                Members = new Dictionary<string, TransportModelEntityMember>()
                {
                    {
                        statementsPropertyName,
                        new TransportModelEntityMember()
                        {
                            Name = statementsPropertyName,
                            Type = new TransportModelTypeReferenceTransportModelItem<TransportModelInterface>()
                            {
                                IsCollection = true,
                                TransportModelItem = parameters.TransportModel.TransportModelInterfaces["Statement"]
                            }
                        }
                    }
                },
                TsDiscriminant = new TransportModelEntityTsDiscriminantSyntaxKind() { SyntaxKindValueName = "Unknown" }
            };

            parameters.TransportModel.TransportModelEntities.Add("Root", root);
        }

        protected void Validate(Parameters transportModel)
        {
            this.ValidateUniqueKindDiscriminants(transportModel);
            this.ValidateTypeLimiterInheritsPropertyType(transportModel);
        }

        protected void ValidateUniqueKindDiscriminants(Parameters transportModel)
        {
            Dictionary<string, string> cache = new Dictionary<string, string>();

            foreach (var entity in transportModel.TransportModel.TransportModelEntities.Where(e => e.Value.TsDiscriminant is TransportModelEntityTsDiscriminantSyntaxKind))
            {
                var discriminant = (TransportModelEntityTsDiscriminantSyntaxKind)entity.Value.TsDiscriminant;
                if (cache.ContainsKey(discriminant.SyntaxKindValueName))
                {
                    throw new InvalidOperationException($"Entities {cache[discriminant.SyntaxKindValueName]} and {entity.Key} are conflicting, both have kind discriminant {discriminant.SyntaxKindValueName}");
                }
            }
        }

        protected void ValidateTypeLimiterInheritsPropertyType(Parameters transportModel)
        {
            foreach (var entity in transportModel.TransportModel.TransportModelEntities)
            {
                foreach (var limiter in entity.Value.MemberTypeLimiters)
                {
                    var prop = entity.Value.GetMemberByName(limiter.Key);

                    if (!TransportModelHelper.TypeReferenceInherits(prop.Type, limiter.Value.Type))
                    {
                        throw new InvalidOperationException($"Entity {entity.Key} has type limiter {limiter.Key} that does not inherit property type.");
                    }
                }
            }
        }
    }
}
