using System.Net.Http.Headers;

namespace Tokenizer;

public interface ITokenValue {
	public TokenType Type { get;}
	
	public T GetValue<T>();
}