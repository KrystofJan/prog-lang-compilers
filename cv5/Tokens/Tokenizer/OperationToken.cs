namespace Tokenizer;

public enum OperatorTokenType {
	MULTIPLY,
	PLUS,
	DEVIDE,
	MINUS
}

public class OperationToken : IToken<OperatorTokenType> {
	public OperatorTokenType Value { get; set; }	
	public TokenType Type { get;}


	public OperationToken(OperatorTokenType value) {
		Type = TokenType.OP;
		Value = value;
	}
	
	public override string ToString() {
		return $"{Value.ToString()}";
	}
}