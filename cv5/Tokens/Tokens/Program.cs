using System;
using Tokenizer;

namespace Tokens
{
	internal class Program
	{
		static void Main(string[] args) {
			string expression = "    -2 + (245 div 3);  // note\n2 mod 3 * hello";
			Lexer lex = new Lexer(expression);
			TokenList<IToken> tl = new TokenList<IToken>(lex.Parse());
			Console.WriteLine(tl.ToString());
		}
	}
}