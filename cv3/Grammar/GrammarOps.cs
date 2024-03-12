using System;
using Grammar;
using System.Collections.Generic;
using System.Linq;
using RuleSets;

namespace Lab3;

public class GrammarOps {
	private IGrammar g;
	private EmptyTerminal Epsilon = new EmptyTerminal(); // change to singleton 
	private ISet<Nonterminal> EmptyNonterminals { get; } = new HashSet<Nonterminal>();
	private ISet<Rule> VisitedRules { get; } = new HashSet<Rule>();
	private ISet<Nonterminal> VisitedFollows { get; } = new HashSet<Nonterminal>();
	public ISet<FirstRuleSet> First { get; } = new HashSet<FirstRuleSet>();
	public Dictionary<Nonterminal, HashSet<Symbol>> Follow { get; } = new Dictionary<Nonterminal, HashSet<Symbol>>();
	public Dictionary<Nonterminal, HashSet<Symbol>> FirstsDictionary { get; } = new Dictionary<Nonterminal, HashSet<Symbol>>();
	private ISet<Symbol> FirstDump { get; } = new HashSet<Symbol>();
	
	
	public GrammarOps(IGrammar g) {
		this.g = g;
		
		foreach (var rule in g.Rules) {
			if (!Follow.ContainsKey(rule.LHS)) {
				Follow.Add(rule.LHS, new HashSet<Symbol>());
				FirstsDictionary.Add(rule.LHS, new HashSet<Symbol>());
			}
		}
		Follow[Follow.Keys.First()].Add(Epsilon);
		ComputeFirst();

		foreach (FirstRuleSet first in First) {
			foreach (Symbol symbol in first.SymbolSet) {
				FirstsDictionary[first.Rule.LHS].Add(symbol);
			}
		}
		foreach (Nonterminal key in Follow.Keys) {
			ComputeFollow(g.Rules, key);
			VisitedFollows.Clear();
		}
	}

	private void ComputeEmpty() {
		foreach (var rule in g.Rules) {
			if (rule.RHS.Count == 0) {
				EmptyNonterminals.Add(rule.LHS);
			}
		}

		int count;
		do {
			count = EmptyNonterminals.Count;
			foreach (var rule in g.Rules) {
				if (rule.RHS.All(x => x is Nonterminal && EmptyNonterminals.Contains(x))) {
					EmptyNonterminals.Add(rule.LHS);
					VisitedRules.Add(rule);
				}
			}
		} while (count != EmptyNonterminals.Count);
	}
	private void ComputeFirstTerminal() {
		foreach (var rule in g.Rules) {
			VisitedRules.Clear();
			FirstDump.Clear();

			if ((!EmptyNonterminals.Contains(rule.LHS) || rule.RHS.Count > 0) && rule.RHS[0] is Terminal) {
				VisitedRules.Add(rule);
				First.Add(new FirstRuleSet(
					rule: rule,
					symbolSet: new HashSet<Symbol> { rule.RHS[0] }
				));
				continue;
			}

			foreach (var rightSide in rule.RHS) {
				if (rightSide is Nonterminal) {
					Nonterminal tmp = (Nonterminal)rightSide;
					ComputeHiddenTerminal(tmp.Rules);
				}
			}

			if (FirstDump.Count == 0 || EmptyNonterminals.Contains(rule.LHS) ) {
				FirstDump.Add(Epsilon);
			}

			ISet<Symbol> tmpp = new HashSet<Symbol>(FirstDump);
			First.Add(new FirstRuleSet(
				rule: rule,
				symbolSet: tmpp
			));
		}
	}
	private void ComputeHiddenTerminal(List<Rule> rules) {
		foreach (Rule rule in rules) {
			if (VisitedRules.Contains(rule)) {
				continue;
			}
			foreach (var rightSide in rule.RHS) {
				if (rightSide is Terminal) {
					FirstDump.Add(rightSide);
					VisitedRules.Add(rule);
					continue;
				}

				Nonterminal tmp = (Nonterminal)rightSide;
				ComputeHiddenTerminal(tmp.Rules);
				VisitedRules.Add(rule);
			}
		}
	}
	
	public void ComputeFirst() {
		ComputeEmpty();
		ComputeFirstTerminal();
	}

	public void ComputeFollow(IList<Rule> rules, Nonterminal currentSymbol) {
		if (VisitedFollows.Contains(currentSymbol)) {
			return;
		}

		foreach (var rule in rules) {
			if (!rule.RHS.Contains(currentSymbol)) {
				continue;
			}
			// zjistim pokud je tam dalsi neterminal / terminal
			int currentSymbolIndex = rule.RHS.IndexOf(currentSymbol);
			if (currentSymbolIndex + 1 >= rule.RHS.Count) {
				// alfa is null
				ComputeFollow(g.Rules, rule.LHS);
				foreach (var symbol in Follow[rule.LHS]) {
					Follow[currentSymbol].Add(symbol);
				}
				continue;
			}
			if (rule.RHS[currentSymbolIndex + 1] is Terminal) {
				// alfa is terminal
				Follow[currentSymbol].Add(rule.RHS[currentSymbolIndex + 1]);
				continue;
			}
			// alfa is a nonterminal
			Nonterminal alfa = (Nonterminal)rule.RHS[currentSymbolIndex + 1];

			foreach (Symbol symbol in FirstsDictionary[alfa]) {
				Follow[currentSymbol].Add(symbol);
			}
		}

		VisitedFollows.Add(currentSymbol);
	}
}