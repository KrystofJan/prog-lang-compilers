namespace Tokenizer;

public enum TokenType {
	OP,
	ID,
	NUM,
	DELIMITER,
	KEYWORD
}

public interface IToken {
	
}
public class IToken<T> : IToken{
	public TokenType Type { get;}
	public T Value { get; set; }
	public override string ToString() {
		return $"{Type.ToString()}: {Value.ToString()}";
	}
}
