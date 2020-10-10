using ForgedOnce.Core.Interfaces;
using ForgedOnce.CSharp;
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
    }
}
