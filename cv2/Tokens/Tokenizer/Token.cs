namespace Tokenizer;

public enum TokenType {
	OP,
	ID,
	NUM,
	DELIMITER,
	KEYWORD
}

public class Token<T> {
	public TokenType Type { get; }
	private ITokenValue _value;
	public T Value { get => _value.GetValue<T>(); }

	public Token(TokenType type, ITokenValue val) {
		Type = type;
		_value = val;
	}
}
