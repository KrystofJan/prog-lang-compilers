using System;
using System.Collections.Generic;

namespace TokenBuilder
{
    public class Tokenizer {
        private string Expression { get; set; }

        public Tokenizer(string expression) {
            Expression = expression.Replace(" ", "");
        }

        public List<Token> ParseExpression() {

            List<Token> tokens = new List<Token>();
            for (int i = 0; i < Expression.Length; i++) {
                if (char.IsDigit(Expression[i])) {
                    tokens.Add(GenerateDigitToken(ref i));
                }
                
                switch (Expression[i]) {
                    case '*': {
                        tokens.Add(new Token{
                            Type =  TokenType.MULTIPLY,
                            Value = null
                        });
                        break;
                    }
                    case '/': {
                        tokens.Add(new Token {
                            Type = TokenType.DEVIDE,
                            Value = null
                        });
                        break;
                    }
                    case '+': {
                        tokens.Add(new Token {
                            Type = TokenType.PLUS,
                            Value = null
                        });
                        break;
                    }
                    case '-': {
                        tokens.Add(new Token {
                            Type = TokenType.MINUS,
                            Value = null
                        });
                        break;
                    }
                    case '(': {
                        tokens.Add(new Token {
                            Type = TokenType.LPAR,
                            Value = null
                        });
                        break;
                    }
                    case ')': {
                        tokens.Add(new Token {
                            Type = TokenType.RPAR,
                            Value = null
                        });
                        break;
                    }
                }
            }

            return tokens;
        }

        private Token GenerateDigitToken(ref int index) {
            string value = "";
            while (char.IsDigit(Expression[index])) {
                value += Expression[index];
                if (index + 1 >= Expression.Length) {
                    break;
                }
                index++;
            }

            int real_value;
            if (!Int32.TryParse(value, out real_value)) {
                throw new Exception($"Cannot convert {value} to integer!");
            }

            return new Token {
                Type = TokenType.NUM,
                Value = real_value
            };
        }
    }
}