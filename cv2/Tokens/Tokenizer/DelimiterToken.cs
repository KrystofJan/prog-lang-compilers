namespace Tokenizer;

public enum DelimiterTokenType {
	LPAR,
	RPAR,
	SEM
}

public class DelimiterToken : ITokenValue{
	public DelimiterTokenType Value { get; set; }
	

	public DelimiterToken(DelimiterTokenType value) {
		Value = value;
	}

	public T GetValue<T>() {
		return (T)(object)Value;
	}
}
