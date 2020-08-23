using ForgedOnce.TsLanguageServices.AstDescription.Model;
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
                .SelectMany(g => g.Value)
                .Select(d => d.NamedDeclaration)
                .OfType<InterfaceDescription>()
                .Where(d => !d.Members.Any(m => m.Property != null && m.Property.Name == "kind"))
                .ToArray();

            var nonInheritednonKindSpecifiedInterfaces = nonKindSpecifiedInterfaces
                .Where(nk => !astDescription
                    .AstDeclarations
                    .SelectMany(g => g.Value)
                    .Any(d => d.InheritedTypes.Any(r => r.Named != null && r.Named.Name == nk.Name)))
                .Select(nk => nk.Name)
                .ToArray();

            var referredNonEnums = astDescription
                .ReferredDeclarations
                .SelectMany(g => g.Value)
                .Select(d => d.NamedDeclaration)
                .Where(d => !(d is EnumDescription))
                .Select(nk => nk.Name)
                .ToArray();

            var result = new Parameters();

            var transportModelParametersBuilder = new TransportModelParametersBuilder(this.pluginSettings);

            result.TransportModel = transportModelParametersBuilder.Create(astDescription);

            return result;
        }
    }
}
