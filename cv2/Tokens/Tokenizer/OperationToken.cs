namespace Tokenizer;

public enum OperatorTokenType {
	MULTIPLY,
	PLUS,
	DEVIDE,
	MINUS
}

public class OperationToken : ITokenValue {
	public OperatorTokenType Value { get; set; }	
	public TokenType Type { get;}


	public OperationToken(OperatorTokenType value) {
		Type = TokenType.OP;
		Value = value;
	}
	
	public T GetValue<T>() {
		return (T)(object)Value;
	}
	public override string ToString() {
		return $"{Value.ToString()}";
	}
}