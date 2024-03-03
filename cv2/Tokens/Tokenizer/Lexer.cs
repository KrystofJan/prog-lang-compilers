using System.Text.RegularExpressions;
namespace Tokenizer;

public class Lexer {
	private string Expression { get; set; }

	private List<IToken> _tokens = new List<IToken>();

	public Lexer(string exp) {
		Expression = Regex.Replace(exp, @"[ \t]+", " ").Trim();
	}

	public List<IToken> Parse() {
		string[] expressionParts = Expression.Split(Environment.NewLine);
		for (int i = 0; i < expressionParts.Length; i++) {
			for (int j = 0; j < expressionParts[i].Length; j++) {
				switch (expressionParts[i][j]) {
					case ' ': {
						break;
					}
                	case '(': {
                		_tokens.Add(new DelimiterToken(
                			value: DelimiterTokenType.LPAR
			            ));
                		break;
                	}
                	case ')': {
                		_tokens.Add(new DelimiterToken(
                			value: DelimiterTokenType.RPAR
			            ));
                		break;
                	}
                	case ';': {
                		_tokens.Add(new DelimiterToken(
                			value: DelimiterTokenType.SEM));
                		break;
                	}
                	case '/': {
                		if (TryIgnoreComment(expressionParts[i], j)) {
			                j = expressionParts[i].Length;
			                break;
		                }
                		_tokens.Add(new OperationToken(
                			value: OperatorTokenType.DEVIDE
                		));
                		break;
                	}
                	case '*': {
                		_tokens.Add(new OperationToken(
                			value: OperatorTokenType.MULTIPLY
                		));
                		break;
                	}
                	case '+': {
                		_tokens.Add(new OperationToken(
                			value: OperatorTokenType.PLUS
                		));
                		break;
                	}
                	case '-': {
						_tokens.Add(new OperationToken(
							value: OperatorTokenType.MINUS
						));
                		break;
                	}
	                default: {
		                if (char.IsDigit(expressionParts[i][j])) {
			                _tokens.Add(GenerateNumberToken(expressionParts[i],ref j));
			                break;
		                }
		                CheckKeywords(expressionParts[i] ,ref j);
		                break;
	                }
                }
			}
		}
		return _tokens;
	}

	private bool TryIgnoreComment(string currentPart, int index) {
		if (currentPart[index + 1] != '/') {
			return false;
		}
		return true;
	}

	private IToken GenerateNumberToken(string currentPart, ref int index) {
		string value = "";
		while (char.IsDigit(currentPart[index])) {
			value += currentPart[index];
			if (index + 1 >= currentPart.Length) {
				break;
			}
			++index;
		}
		--index;

		int number;
		if (!Int32.TryParse(value, out number)) {
			throw new Exception($"Cannot convert {value} to integer!");
		}

		return new NumberToken(
			value: number
		);
	}

	private void CheckKeywords(string currentPart, ref int index) {
		int nextSpace = currentPart.Substring(index, currentPart.Length - index).IndexOf(' ');
		string keyword = "";
		Match match = Regex.Match(currentPart.Substring(index, currentPart.Length - index), @"^\S+");
		if (!match.Success) {
			return;
		}
		keyword = match.Value;
		
		switch (keyword) {
			case "div": {
				_tokens.Add(new KeywordToken(
					value: KeywordTokenValues.DIV
				));
				break;
			}
			case "mod": {
				_tokens.Add(new KeywordToken(
					value: KeywordTokenValues.MOD
				));
				break;
			}
			default: {
				_tokens.Add(new IdentifierToken(
					value: keyword
				));
				break;
			}
		}
		index += keyword.Length - 1;
	}
}