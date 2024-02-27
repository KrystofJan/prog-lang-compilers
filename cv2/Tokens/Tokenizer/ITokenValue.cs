using System.Net.Http.Headers;

namespace Tokenizer;

public interface ITokenValue {
	public T GetValue<T>();
}