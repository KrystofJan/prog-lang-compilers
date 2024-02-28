namespace Tokenizer;

public class NumberToken : ITokenValue {
	public int Value { get; set; }
	public TokenType Type { get; }


	public NumberToken(int value) {
		Type = TokenType.NUM;
		Value = value;
	}
	
	public T GetValue<T>() {
		return (T)(object)Value;
	}
	
	public override string ToString() {
		return $"{Type.ToString()}: {Value}";
	}
}