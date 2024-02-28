using System.Collections;
using System.Text;
namespace Tokenizer;

public class TokenList<Token> : IEnumerable<Token> {
	public List<Token> Data;

	public TokenList(List<Token> data) {
		Data = data;
	}
	public IEnumerator<Token> GetEnumerator() {
		return new TokenListEnumerator<Token>(Data);
	}

	IEnumerator IEnumerable.GetEnumerator() {
		return GetEnumerator();
	}

	public override string ToString() {
		StringBuilder sb = new StringBuilder();
		foreach (Token item in Data) {
			sb.AppendLine(item.ToString());
		}
		return sb.ToString();
	}
}

public class TokenListEnumerator<T> : IEnumerator<T> {
	private List<T> Data { get; set; }
	private int _currentIndex = -1;

	public TokenListEnumerator(List<T> data) {
		Data = data;
	}
	
	public void Dispose() {
		// TODO release managed resources here
	}

	public bool MoveNext() {
		_currentIndex++;
		return _currentIndex < Data.Count;
	}

	public void Reset() {
		_currentIndex = -1;
	}

	public T Current { get => Data[_currentIndex]; }

	object IEnumerator.Current
	{
		get => Current;
	}
}