using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Grammar;
using RuleSets;
namespace Lab3;

public class LL1GrammarProcessor {

	public IGrammar Grammar;

	public Dictionary<Nonterminal, List<Symbol>> LL1UniqueSymbolDump { get; set; } = new Dictionary<Nonterminal, List<Symbol>>();
	
	public ISet<FirstRuleSet> First { get; set; }
	public FollowRuleSet Follow { get; set; }

	public EmptyTerminal Epsilon { get; set; }

	public Dictionary<Nonterminal, List<Symbol>> FirstDictionary { get; set; } = new Dictionary<Nonterminal, List<Symbol>>();
	public Dictionary<Nonterminal, List<Symbol>> FollowDictionary { get; set; } = new Dictionary<Nonterminal, List<Symbol>>();
	public bool isLL1 { get; set; }

	public LL1GrammarProcessor(IGrammar g, ISet<FirstRuleSet> first, FollowRuleSet follow, EmptyTerminal e) {
		First = first;
		Follow = follow;
		Grammar = g;
		Epsilon = e;
		
		foreach (Nonterminal nonTerminal in Grammar.Nonterminals) {
			List<Symbol> tmp = new List<Symbol>();
			List<ISet<Symbol>> NonTerminalsFirstSymbolSets = First.Where(x => x.Rule.LHS == nonTerminal)
																  .Select(x => x.SymbolSet)
																  .ToList();

			foreach (var FirstSet in NonTerminalsFirstSymbolSets) {
					tmp.AddRange(FirstSet);
			}
			FirstDictionary.Add(nonTerminal, tmp);
			LL1UniqueSymbolDump.Add(nonTerminal, tmp);

			List<Symbol> NonTerminalsFollowSymbolSets = Follow.Follow[nonTerminal].ToList();
			FollowDictionary.Add(nonTerminal, NonTerminalsFollowSymbolSets);

		}
		checkLL1();

	}

	private void checkLL1() {
		// first
		ChangeEpsilonForFollow();
		
		foreach (var symbol in LL1UniqueSymbolDump) {
			if (ContainsADuplicate(symbol.Value)) {
				Console.WriteLine($"{symbol.Key} contains a duplicate!");
				isLL1 = false;
				return;
			}
		}
		isLL1 = true;
	}

	private void ChangeEpsilonForFollow() {
		foreach (var nonTerminal in Grammar.Nonterminals) {

			if (LL1UniqueSymbolDump[nonTerminal].Contains(Epsilon)) {
				LL1UniqueSymbolDump[nonTerminal].Remove(Epsilon);
				LL1UniqueSymbolDump[nonTerminal].AddRange(FollowDictionary[nonTerminal]);
			}
		}
	}

	private bool ContainsADuplicate(List<Symbol> listOfSymbols) {
		return listOfSymbols.Count == listOfSymbols.Distinct().Count();
	}
}