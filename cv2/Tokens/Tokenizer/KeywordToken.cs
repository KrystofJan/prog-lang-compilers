namespace Tokenizer;

public enum KeywordTokenValues {
	MOD,
	DIV
}

public class KeywordToken : IToken<KeywordTokenValues> {
	public KeywordTokenValues Value { get; set; }
	public TokenType Type { get; }
	
	public KeywordToken(KeywordTokenValues value) {
		Type = TokenType.KEYWORD;
		Value = value;
	}
	
	public override string ToString() {
		return $"{Value.ToString()}";
	}
}