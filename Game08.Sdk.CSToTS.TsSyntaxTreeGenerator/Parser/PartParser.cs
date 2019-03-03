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
                        case "enum":
                            var en = this.Enum.Parse(s);
                            if (en != null)
                            {
                                en.Modifiers = mod != null ? new[] { mod.Value } : new Modifier[0];
                                result.Enums.Add(en.Name, en);
                            }
                            break;
                        case "type":
                            var ty = this.Type.Parse(s);
                            ty.TypeDeclaration.Modifiers = mod != null ? new[] { mod.Value } : new Modifier[0];
                            result.Types.Add(ty.TypeDeclaration.Name.Name, ty.TypeDeclaration);                            
                            break;
                        case "interface":
                            var i = this.Interface.Parse(s);
                            if (i != null)
                            {
                                i.Modifiers = mod != null ? new[] { mod.Value } : new Modifier[0];
                                result.Interfaces.Add(i.Name.Name, i);
                            }
                            break;
                        case "class": this.SkipBodiedDefinition(s); break;
                    }

                    mod = s.ProcessEmptyAndComments();
                    token = s.SkipUntilAny(true, "type", "interface", "enum", "class");
                }
                
                foreach (var ii in s.InlineInterfaces)
                {                    
                    result.Interfaces.Add(ii.Name.Name, ii);
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

        public IPartParser<TypeParserResult> Type => new PartParserShell<TypeParserResult>(ParserContext.Type, (s) =>
        {
            s.ProcessEmptyAndComments();
            TypeParserResult result = new TypeParserResult();
            result.TypeDeclaration = new Model.TypeDeclaration();
            result.TypeDeclaration.Name = ParseTypeNameDeclaration(s);
            s.SkipUntilAny(true, "=");
            s.ProcessEmptyAndComments();
            if (s.PeekToken() == "|")
            {
                s.TakeToken();
            }
            s.ProcessEmptyAndComments();
            result.TypeDeclaration.Constraint = this.ParseTypeExpression(s);
            
            if (s.PeekToken() == ";")
            {
                s.TakeToken();
            }

            return result;
        });

        public IPartParser<TsInterface> Interface => new PartParserShell<TsInterface>(ParserContext.Interface, (s) =>
        {
            s.ProcessEmptyAndComments();
            TsInterface result = new TsInterface();
            result.Name = ParseTypeNameDeclaration(s);

            if (s.SkipDefinitions.Contains(result.Name.Name))
            {
                this.SkipBodiedDefinition(s);
                return null;
            }

            if (s.PeekToken() == "extends")
            {
                s.TakeToken();
                s.ProcessEmptyAndComments();
                result.Extends = this.ParseList<TypeReference>(s, this.ParseTypeReference);
                s.ProcessEmptyAndComments();
            }

            s.SkipUntilAny(true, "{");

            result.Members = this.ParseInterfaceMembers(s);

            s.TakeToken();
            return result;
        });

        private List<TsInterfaceMember> ParseInterfaceMembers(ParserState state)
        {
            List<TsInterfaceMember> result = new List<TsInterfaceMember>();
            var mod = state.ProcessEmptyAndComments();
            while (state.PeekToken() != "}")
            {
                var member = new TsInterfaceMemberProperty();
                //// TODO: proper lookup.
                if (state.PeekToken() == "readonly" && state.PeekToken(1) != ":")
                {
                    member.IsReadonly = true;
                    state.TakeToken();
                    state.ProcessEmptyAndComments();
                }

                if (state.PeekToken() == "[")
                {
                    //// Skipping indexers.
                    state.SkipUntilAny(true, ";");
                    state.ProcessEmptyAndComments();
                    continue;
                }

                member.Name = state.TakeToken();
                member.Modifiers = mod.HasValue ? new Modifier[] { mod.Value } : null;
                state.ProcessEmptyAndComments();
                if (state.PeekToken() == "?")
                {
                    state.TakeToken();
                    member.IsOptional = true;
                }

                state.ProcessEmptyAndComments();

                if (state.PeekToken() == "(" || state.PeekToken() == "<")
                {
                    //// Skipping method details.
                    state.SkipUntilAny(true, ";");
                    result.Add(new TsInterfaceMemberMethod()
                    {
                        Name = member.Name,
                        Modifiers = member.Modifiers,
                        IsOptional = member.IsOptional,
                        IsReadonly = member.IsReadonly
                    });
                    state.ProcessEmptyAndComments();
                    continue;
                }

                if (state.PeekToken() != ":")
                {
                    state.RaiseParsingError("Expecting interface member definition", expectedTokens: ":");
                }                

                state.TakeToken();
                state.ProcessEmptyAndComments();

                if (state.PeekToken() == "(")
                {
                    state.SkipUntilAny(true, ";");
                    state.ProcessEmptyAndComments();
                    continue;
                }

                member.TypeConstraint = this.ParseTypeExpression(state);
                state.ProcessEmptyAndComments();

                if (state.PeekToken() == ";")
                {
                    state.TakeToken();
                    state.ProcessEmptyAndComments();
                }

                if (state.PeekToken() == ",")
                {
                    state.TakeToken();
                    state.ProcessEmptyAndComments();
                }

                result.Add(member);
            }

            return result;
        }

        private Expression ParseTypeExpression(ParserState state)
        {
            Expression result = this.ParseTypeReferenceExpression(state);
            state.ProcessEmptyAndComments();
            while (state.PeekToken() == "|" || state.PeekToken() == "&")
            {
                result = this.ParseTypeBinaryExpression(result, state);
                state.ProcessEmptyAndComments();
            }

            return result;
        }

        private string ParseStringLiteral(ParserState state)
        {
            state.TakeToken();
            StringBuilder builder = new StringBuilder();
            var t = state.TakeToken();
            while (t != "\"" && t != "'")
            {
                builder.Append(t);
                t = state.TakeToken();
            }

            return builder.ToString();
        }

        private Expression ParseTypeReferenceExpression(ParserState state)
        {
            if (state.PeekToken() == "\"" || state.PeekToken() == "'")
            {                
                ExpressionStringLiteralValue literal = new ExpressionStringLiteralValue();
                literal.Value = this.ParseStringLiteral(state);
                return literal;
            }
            else
            {
                if (state.PeekToken() == "{")
                {
                    state.TakeToken();
                    TsInterface inlineInterface = new TsInterface();
                    inlineInterface.Name = new TypeNameDeclaration()
                    {
                        Name = state.GetNextInlineTypeName()
                    };
                    inlineInterface.Members = this.ParseInterfaceMembers(state);
                    state.InlineInterfaces.Add(inlineInterface);

                    state.ProcessEmptyAndComments();
                    if (state.PeekToken() != "}")
                    {
                        state.RaiseParsingError("Unexpected token.", expectedTokens: "}");
                    }
                    state.TakeToken();

                    return new ExpressionTypeReference()
                    {
                        Reference = new TypeReference()
                        {
                            Name = new Identifier()
                            {
                                Parts = new List<string>() { inlineInterface.Name.Name }
                            }
                        }
                    };
                }
                else
                {
                    if (state.PeekToken() == "[")
                    {
                        state.TakeToken();
                        state.ProcessEmptyAndComments();
                        ExpressionTypeTupleConstraint tuple = new ExpressionTypeTupleConstraint();
                        tuple.Constraint = this.ParseList<Expression>(state, ParseTypeReferenceExpression);
                        if (state.PeekToken() != "]")
                        {
                            state.RaiseParsingError("Unexpected token.", expectedTokens: "]");
                        }

                        if (state.PeekToken() != "]")
                        {
                            state.RaiseParsingError("Unexpected token.", expectedTokens: "]");
                        }
                        state.TakeToken();
                        return tuple;
                    }
                    else
                    {
                        Expression reference = new ExpressionTypeReference() { Reference = this.ParseTypeReference(state) };
                        state.ProcessEmptyAndComments();
                        while (state.PeekToken() == "[" && state.PeekToken(1) == "\"")
                        {
                            state.TakeToken();
                            var membersConstraint = new ExpressionTypeMembersReference();
                            membersConstraint.TypeReference = reference;
                            membersConstraint.MemberNames = this.ParseList<string>(state, (s) =>
                            {
                                if (s.PeekToken() != "\"" && s.PeekToken() != "'")
                                {
                                    s.RaiseParsingError("Unexpected token.", expectedTokens: new[] { "\"", "'" });
                                }
                                s.TakeToken();
                                var res = s.TakeToken();
                                if (s.PeekToken() != "\"" && s.PeekToken() != "'")
                                {
                                    s.RaiseParsingError("Unexpected token.", expectedTokens: new[] { "\"", "'" });
                                }
                                s.TakeToken();
                                return res;
                            });
                            if (state.PeekToken() != "]")
                            {
                                state.RaiseParsingError("Unexpected token.", expectedTokens: "]");
                            }
                            state.TakeToken();
                            reference = membersConstraint;
                        }

                        return reference;
                    }
                }
            }
        }

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
                    result.Right = this.ParseTypeReferenceExpression(state);
                    return result;
                }
            }

            state.RaiseParsingError("Unknown binary operator", -1, next);
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
                result.TypeParameters = this.ParseList<Expression>(state, ParseTypeExpression);
                state.TakeToken();
            }

            if (state.PeekToken() == "[" && state.PeekToken(1) == "]")
            {
                state.TakeToken();
                state.TakeToken();
                result.IsArray = true;
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

        private void SkipBodiedDefinition(ParserState state)
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
