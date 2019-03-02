using Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Interfaces;
using Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Parser
{
    public class PartParser
    {
        private readonly string[] binaryOperators = new[] { "&", "|", "^", "~", "<<", ">>", ">>>" };

        public IPartParser<TsModel> Root => new PartParserShell<TsModel>(ParserContext.FileRoot, (s) =>
        {
            TsModel result = new TsModel();

            if (s.SkipUntilAny(true, "{") != null)
            {
                var mod = s.ProcessEmptyAndComments();

                var token = s.SkipUntilAny(true, "type", "interface", "enum", "class");

                while (token != null)
                {
                    switch (token)
                    {
                        case "enum": var en = this.Enum.Parse(s); en.Modifiers = mod != null ? new[] { mod.Value } : new Modifier[0]; result.Enums.Add(en.Name, en);  break;
                        case "type": var ty = this.Type.Parse(s); ty.Modifiers = mod != null ? new[] { mod.Value } : new Modifier[0]; result.Types.Add(ty.Name.Name, ty); break;
                        case "interface": var i = this.Interface.Parse(s); i.Modifiers = mod != null ? new[] { mod.Value } : new Modifier[0]; result.Interfaces.Add(i.Name.Name, i); break;
                        case "class": this.SkipClass(s); break;
                    }

                    mod = s.ProcessEmptyAndComments();
                    token = s.SkipUntilAny(true, "type", "interface", "enum", "class");
                }
            }

            return result;
        });

        public IPartParser<TsEnum> Enum => new PartParserShell<TsEnum>(ParserContext.Enum, (s) => 
        {
            s.ProcessEmptyAndComments();
            TsEnum result = new TsEnum();
            result.Name = s.TakeToken();
            s.SkipUntilAny(true, "{");

            var mod = s.ProcessEmptyAndComments();
            while (s.PeekToken() != "}")
            {
                TsEnumMember member = new TsEnumMember();
                member.Name = s.TakeToken();
                member.Modifiers = mod.HasValue ? new Modifier[] { mod.Value } : null;
                s.ProcessEmptyAndComments();
                if (s.PeekToken() == "=")
                {
                    s.TakeToken();
                    s.ProcessEmptyAndComments();
                    Expression val = new ExpressionValue() { Value = s.TakeToken() };
                    s.ProcessEmptyAndComments();
                    while (s.PeekToken() != "," && s.PeekToken() != "}")
                    {
                        var binary = new ExpressionBinary()
                        {
                            Left = val,
                            Operator = s.TakeToken()
                        };
                        s.ProcessEmptyAndComments();
                        binary.Right = new ExpressionValue() { Value = s.TakeToken() };
                        val = binary;
                        s.ProcessEmptyAndComments();
                    }

                    member.Value = val;
                }

                result.Members.Add(member.Name, member);

                if (s.PeekToken() == ",") { s.TakeToken(); }
                mod = s.ProcessEmptyAndComments();
            }

            s.TakeToken();
            return result;
        });

        public IPartParser<Model.TypeDeclaration> Type => new PartParserShell<Model.TypeDeclaration>(ParserContext.Type, (s) =>
        {
            s.ProcessEmptyAndComments();
            Model.TypeDeclaration result = new Model.TypeDeclaration();
            result.Name = ParseTypeNameDeclaration(s);
            s.SkipUntilAny(true, "=");
            s.ProcessEmptyAndComments();
            Expression currentExpression = new ExpressionTypeReference() { Reference = this.ParseTypeReference(s) };
            s.ProcessEmptyAndComments();
            while (s.PeekToken() != ";")
            {
                s.TakeToken();
                currentExpression = this.ParseTypeBinaryExpression(currentExpression, s);
                s.ProcessEmptyAndComments();
            }

            s.TakeToken();
            result.Constraint = currentExpression;
            return result;
        });

        public IPartParser<TsInterface> Interface => new PartParserShell<TsInterface>(ParserContext.Interface, (s) =>
        {
            s.ProcessEmptyAndComments();
            TsInterface result = new TsInterface();
            result.Name = ParseTypeNameDeclaration(s);

            if (s.PeekToken() == "extends")
            {
                s.TakeToken();
                s.ProcessEmptyAndComments();
                result.Extends = this.ParseList<TypeReference>(s, this.ParseTypeReference);
                s.ProcessEmptyAndComments();
            }

            s.SkipUntilAny(true, "{");
            var mod = s.ProcessEmptyAndComments();
            while (s.PeekToken() != "}")
            {
                var member = new TsInterfaceMember();
                member.Name = s.TakeToken();
                member.Modifiers = mod.HasValue ? new Modifier[] { mod.Value } : null;
                s.ProcessEmptyAndComments();
                if (s.PeekToken() == "?")
                {
                    s.TakeToken();
                    member.IsOptional = true;
                }

                s.ProcessEmptyAndComments();
                if (s.PeekToken() != ":")
                {
                    s.RaiseParsingError("Expecting interface member definition", expectedTokens: ":");
                }

                s.TakeToken();
                s.ProcessEmptyAndComments();
                member.TypeConstraint = this.ParseTypeReference(s);
                s.ProcessEmptyAndComments();
                if (s.PeekToken() != ";")
                {
                    s.RaiseParsingError("Expecting semicolon", expectedTokens: ";");
                }

                result.Members.Add(member);
            }

            s.TakeToken();
            return result;
        });

        private ExpressionBinary ParseTypeBinaryExpression(Expression left, ParserState state)
        {
            var next = state.TakeToken();
            for (var i = 0; i < this.binaryOperators.Length; i++)
            {
                if (next == this.binaryOperators[i])
                {
                    var result = new ExpressionBinary();
                    result.Left = left;
                    result.Operator = next;
                    state.ProcessEmptyAndComments();
                    result.Right = new ExpressionTypeReference() { Reference = this.ParseTypeReference(state) };
                    return result;
                }
            }

            state.RaiseParsingError("Unknown binary operator", next);
            return null;
        }

        private TypeNameDeclaration ParseTypeNameDeclaration(ParserState state)
        {
            TypeNameDeclaration result = new TypeNameDeclaration();
            result.Name = state.TakeToken();
            state.ProcessEmptyAndComments();
            if (state.PeekToken() == "<")
            {
                state.TakeToken();
                state.ProcessEmptyAndComments();
                result.Parameters = this.ParseList<TypeParameterDeclaration>(state, ParseTypeParameterDeclaration);
                state.ProcessEmptyAndComments();
                state.TakeToken();
            }

            return result;
        }

        private TypeParameterDeclaration ParseTypeParameterDeclaration(ParserState state)
        {
            TypeParameterDeclaration parameterDeclaration = new TypeParameterDeclaration();
            parameterDeclaration.Name = state.TakeToken();
            state.ProcessEmptyAndComments();
            if (state.PeekToken() == "extends")
            {
                state.TakeToken();
                state.ProcessEmptyAndComments();
                parameterDeclaration.Extends = this.ParseList<TypeReference>(state, ParseTypeReference);
            }

            state.ProcessEmptyAndComments();
            return parameterDeclaration;
        }

        private List<T> ParseList<T>(ParserState state, Func<ParserState, T> itemParser)
        {
            List<T> result = new List<T>();
            result.Add(itemParser(state));
            state.ProcessEmptyAndComments();
            while (state.PeekToken() == ",")
            {
                state.TakeToken();
                result.Add(itemParser(state));
                state.ProcessEmptyAndComments();
            }

            return result;
        }

        private TypeReference ParseTypeReference(ParserState state)
        {
            TypeReference result = new TypeReference();
            result.Name = ParseIdentifier(state);
            state.ProcessEmptyAndComments();
            if (state.PeekToken() == "<")
            {
                
                state.TakeToken();
                state.ProcessEmptyAndComments();
                result.TypeParameters = this.ParseList<TypeReference>(state, this.ParseTypeReference);
                state.TakeToken();
            }

            if (state.PeekToken() == "[")
            {
                state.TakeToken();
                state.ProcessEmptyAndComments();
                if (state.PeekToken() == "]")
                {
                    state.TakeToken();
                    result.IsArray = true;
                }
                else
                {
                    throw new InvalidOperationException($"Unexpected token.");
                }
            }

            return result;
        }

        private Identifier ParseIdentifier(ParserState state)
        {
            var result = new Identifier();
            result.Parts.Add(state.TakeToken());
            while (state.PeekToken() == ".")
            {
                state.TakeToken();
                result.Parts.Add(state.TakeToken());
            }

            return result;
        }

        private void SkipClass(ParserState state)
        {
            int b = 0;
            var nextBracket = state.SkipUntilAny(true, "{");
            while (nextBracket != null)
            {
                if (nextBracket == "{")
                {
                    b++;
                }

                if (nextBracket == "}")
                {
                    b--;
                    if (b == 0)
                    {
                        return;
                    }
                }

                nextBracket = state.SkipUntilAny(true, "{", "}");
            }
        }
    }
}
