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
			try
			{
				StreamReader r = new StreamReader(new FileStream("G1.TXT", FileMode.Open));
				EmptyTerminal Epsilon = new EmptyTerminal(); 

				GrammarReader inp = new GrammarReader(r);
				var grammar = inp.Read();
				grammar.dump();
			
				GrammarOps gr = new GrammarOps(grammar, Epsilon);

				foreach (var term in gr.First) {
					Console.WriteLine(term.ToString());
				}
				
				Console.WriteLine(gr.Follow.ToString());
				
				LL1GrammarProcessor ll1GrammarProcessor = new LL1GrammarProcessor(grammar, gr.First, gr.Follow, Epsilon);
				string not = ll1GrammarProcessor.isLL1 ? "" : " not";
				Console.WriteLine("It it" + not +" LL1 grammar");
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