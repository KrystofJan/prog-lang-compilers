namespace Tokenizer;

public class NumberToken : ITokenValue {
	public int Value { get; set; }
	
	public T GetValue<T>() {
		return (T)(object)Value;
	}
}