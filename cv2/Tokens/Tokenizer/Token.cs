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

	public Token(ITokenValue val) {
		Type = val.Type;
		_value = val;
	}

	public override string ToString() {
		return _value.ToString();
	}
}
