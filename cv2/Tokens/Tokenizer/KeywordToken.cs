namespace Tokenizer;

public enum KeywordTokenValues {
	MOD,
	DIV
}

public class KeywordToken : ITokenValue{
	public KeywordTokenValues Value { get; set; }
	public TokenType Type { get; }
	
	public KeywordToken(KeywordTokenValues value) {
		Type = TokenType.KEYWORD;
		Value = value;
	}
	
	public T GetValue<T>() {
		return (T)(object)Value;
	}
	
	public override string ToString() {
		return $"{Value.ToString()}";
	}
}