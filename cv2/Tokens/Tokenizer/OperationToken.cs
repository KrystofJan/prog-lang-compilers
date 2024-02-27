namespace Tokenizer;

public enum OperatorTokenType {
	MULTIPLY,
	PLUS,
	DEVIDE,
	MINUS
}

public class OperationToken : ITokenValue {
	public OperatorTokenType Value { get; set; }

	public OperationToken(OperatorTokenType value) {
		Value = value;
	}
	
	public T GetValue<T>() {
		return (T)(object)Value;
	}
}