namespace Tokenizer;

public enum DelimiterTokenType {
	LPAR,
	RPAR,
	SEM
}

public class DelimiterToken : ITokenValue{
	public TokenType Type { get;}
	// public Type ValueType { get => typeof(DelimiterTokenType); }
	public DelimiterTokenType Value { get; set; }

	public DelimiterToken(DelimiterTokenType value) {
		Type = TokenType.DELIMITER;
		Value = value;
	}

	// public ValueType GetValue() {
	// 	return Value;
	// }
	public T GetValue<T>() {
		return (T)(object)Value;
	}

	public override string ToString() {
		return Value.ToString();
	}
}
