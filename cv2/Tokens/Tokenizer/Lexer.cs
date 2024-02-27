using System.Text.RegularExpressions;
namespace Tokenizer;

public class Lexer {
	private string Expression { get; set; }

	private string Cu { get; set; }

	private List<Token<ITokenValue>> _tokens = new List<Token<ITokenValue>>();

	public Lexer(string exp) {
		Expression = Regex.Replace(exp, @"[ \t]+", " ").Trim();
	}

	public void Parse() {
		string[] expressionParts = Expression.Split(Environment.NewLine);
		for (int i = 0; i < Expression.Length; i++) {
			switch (Expression[i]) {
				case '(': {
					_tokens.Add(new Token<ITokenValue>(
						type: TokenType.DELIMITER,
						val: new DelimiterToken(DelimiterTokenType.LPAR)));
					break;
				}
				case ')': {
					_tokens.Add(new Token<ITokenValue>(
						type: TokenType.DELIMITER,
						val: new DelimiterToken(DelimiterTokenType.RPAR)));
					break;
				}
				case ';': {
					_tokens.Add(new Token<ITokenValue>(
						type: TokenType.DELIMITER,
						val: new DelimiterToken(DelimiterTokenType.SEM)));
					break;
				}
				case '/': {
					if (TryIgnoreComment(ref i)) {
						// move to new line lol :)
					}
					_tokens.Add(new Token<ITokenValue>(
						type: TokenType.OP,
						val: new OperationToken(OperatorTokenType.DEVIDE)
						));
					break;
				}
				case '*': {
					_tokens.Add(new Token<ITokenValue>(
						type: TokenType.OP,
						val: new OperationToken(OperatorTokenType.MULTIPLY)
					));
					break;
				}
				case '+': {
					_tokens.Add(new Token<ITokenValue>(
						type: TokenType.OP,
						val: new OperationToken(OperatorTokenType.PLUS)
					));
					break;
				}
				case '-': {
					_tokens.Add(new Token<ITokenValue>(
						type: TokenType.OP,
						val: new OperationToken(OperatorTokenType.MINUS)
					));
					break;
				}
			}
		}
	}

	private bool TryIgnoreComment(ref int i) {
		if (Expression[i + 1] != '/') {
			return false;
		}

		++i;
		return true;
	}
	
}