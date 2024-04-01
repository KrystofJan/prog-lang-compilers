namespace Tokenizer;

public class NumberToken : IToken<int> {
	public TokenType Type { get; }
	public int Value { get; set; }

	public NumberToken(int value) {
		Type = TokenType.NUM;
		Value = value;
	}

	public override string ToString() {
		return $"{Type.ToString()}: {Value}";
	}
}