namespace Tokenizer;

public class IdentifierToken : IToken<string> {

	public TokenType Type { get; }
	public string Value { get; }

	public IdentifierToken(string value) {
		Type = TokenType.ID;
		Value = value;
	}
	
	public override string ToString() {
		return $"{Type.ToString()}: {Value}";
	}
	
}