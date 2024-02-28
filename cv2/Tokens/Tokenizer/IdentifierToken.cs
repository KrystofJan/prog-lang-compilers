namespace Tokenizer;

public class IdentifierToken : ITokenValue {

	public TokenType Type { get; }
	public string Value { get; }

	public IdentifierToken(string val) {
		Type = TokenType.ID;
		Value = val;
	} 
	
	public T GetValue<T>() {
		return (T)(object)Value;
	}
	
	public override string ToString() {
		return $"{Type.ToString()}: {Value}";
	}
	
}