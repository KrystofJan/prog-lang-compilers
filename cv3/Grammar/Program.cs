using Grammar;
using System;
using System.Collections.Generic;
using RuleSets;
using System.IO;

namespace Lab3
{

	class Program
	{
		static void Main(string[] args) {

			// FirstRuleSet f = new FirstRuleSet(
			// 	new Rule(new Nonterminal("k")), 
			// 	new HashSet<Symbol>() {
			// 		new Terminal("asd")
			// 	}
			// );
			//
			// Console.WriteLine(f.ToString());

			try
			{
				StreamReader r = new StreamReader(new FileStream("G1.TXT", FileMode.Open));
			
				GrammarReader inp = new GrammarReader(r);
				var grammar = inp.Read();
				grammar.dump();
			
				GrammarOps gr = new GrammarOps(grammar);
			
				// First step, computes nonterminals that can be rewritten as empty word
				// foreach (Nonterminal nt in gr.EmptyNonterminals)
				// {
				// 	Console.Write(nt.Name + " ");
				// }
				foreach (var term in gr.First) {
					Console.WriteLine(term.ToString());
				}
			}
			catch (GrammarException e)
			{
				Console.WriteLine($"{e.LineNumber}: Error -  {e.Message}");
			}
			catch (IOException e)
			{
				Console.WriteLine(e);
			}
		}
	}
}