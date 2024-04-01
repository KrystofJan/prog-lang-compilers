using System;
using Grammar;
using System.Collections.Generic;
using System.Linq;
using RuleSets;

namespace Lab3;

public class GrammarOps {
	private IGrammar g;

	public Dictionary<Nonterminal, HashSet<Symbol>> FollowDictionary { get; } = new Dictionary<Nonterminal, HashSet<Symbol>>();
	private Dictionary<Nonterminal, HashSet<Symbol>> FirstsDictionary { get; } = new Dictionary<Nonterminal, HashSet<Symbol>>();

	public ISet<FirstRuleSet> First { get; } = new HashSet<FirstRuleSet>();
	public FollowRuleSet Follow { get; }
	
	private ISet<Nonterminal> EmptyNonterminals { get; } = new HashSet<Nonterminal>();
	private ISet<Rule> EmptyRules { get; } = new HashSet<Rule>();
	public int CurrentFollowNonTerminal { get; set; }
	private ISet<Rule> VisitedRules { get; } = new HashSet<Rule>();
	private ISet<Nonterminal> VisitedFollows { get; } = new HashSet<Nonterminal>();
	private ISet<Symbol> FirstDump { get; } = new HashSet<Symbol>();
	private EmptyTerminal Epsilon { get; set; }
	
	public GrammarOps(IGrammar g, EmptyTerminal e) {
		this.g = g;
		Epsilon = e;
		CurrentFollowNonTerminal = 0;
		
		foreach (var rule in g.Rules) {
			if (!FollowDictionary.ContainsKey(rule.LHS)) {
				FollowDictionary.Add(rule.LHS, new HashSet<Symbol>());
				FirstsDictionary.Add(rule.LHS, new HashSet<Symbol>());
			}
		}
		FollowDictionary[FollowDictionary.Keys.First()].Add(Epsilon);
		
		ComputeFirst();

		foreach (FirstRuleSet first in First) {
			foreach (Symbol symbol in first.SymbolSet) {
				FirstsDictionary[first.Rule.LHS].Add(symbol);
			}
		}

		foreach (Nonterminal key in FollowDictionary.Keys) {
			ComputeFollow(g.Rules, key);
			VisitedFollows.Clear();
		}
		Follow = new FollowRuleSet(FollowDictionary);
	}

	private void ComputeEmpty() {
		foreach (var rule in g.Rules) {
			if (rule.RHS.Count == 0) {
				EmptyNonterminals.Add(rule.LHS);
				EmptyRules.Add(rule);
			}
		}

		int count;
		do {
			count = EmptyNonterminals.Count;
			foreach (var rule in g.Rules) {
				if (rule.RHS.All(x => x is Nonterminal && EmptyNonterminals.Contains(x))) {
					EmptyNonterminals.Add(rule.LHS);
					EmptyRules.Add(rule);
					VisitedRules.Add(rule);
				}
			}
		} while (count != EmptyNonterminals.Count);
	}
	private void ComputeFirstTerminal() {
		foreach (var rule in g.Rules) { 
			FirstDump.Clear();

			if (EmptyRules.Contains(rule)) {
				FirstDump.Add(Epsilon);
				First.Add(new FirstRuleSet(
					rule: rule,
					symbolSet: new HashSet<Symbol>(FirstDump)
				));
				continue;
			}
			
			if (rule.RHS[0] is Terminal) {
				First.Add(new FirstRuleSet(
					rule: rule,
					symbolSet: new HashSet<Symbol> { rule.RHS[0] }
				));
				continue;
			}
			
			Nonterminal tmp = (Nonterminal)rule.RHS[0];
			ComputeHiddenTerminal(tmp.Rules);
			
			if (FirstDump.Count == 0 || EmptyNonterminals.Contains(rule.LHS) ) {
				FirstDump.Add(Epsilon);
			}
			
			First.Add(new FirstRuleSet(
				rule: rule,
				symbolSet: new HashSet<Symbol>(FirstDump)
			));
		}
	}
	private void ComputeHiddenTerminal(List<Rule> rules) {
		foreach (Rule rule in rules) {
			if (VisitedRules.Contains(rule)) {
				continue;
			}
			if (rule.RHS[0] is Terminal) {
				FirstDump.Add(rule.RHS[0]);
				VisitedRules.Add(rule);
				continue;
			}
			
			Nonterminal tmp = (Nonterminal)rule.RHS[0];
			ComputeHiddenTerminal(tmp.Rules);
			VisitedRules.Add(rule);
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
		VisitedFollows.Add(currentSymbol);
		foreach (var rule in rules) {
			if (!rule.RHS.Contains(currentSymbol)) {
				continue;
			}
			// zjistim pokud je tam dalsi neterminal / terminal
			int currentSymbolIndex = rule.RHS.IndexOf(currentSymbol);
			if (currentSymbolIndex + 1 >= rule.RHS.Count) {
				// alfa is null
				ComputeFollow(g.Rules, rule.LHS);
				foreach (var symbol in FollowDictionary[rule.LHS]) {
					FollowDictionary[currentSymbol].Add(symbol);
				}
				
				continue;
			}
			if (rule.RHS[currentSymbolIndex + 1] is Terminal) {
				// alfa is terminal
				FollowDictionary[currentSymbol].Add(rule.RHS[currentSymbolIndex + 1]);
				continue;
			}
			// alfa is a nonterminal
			Nonterminal alfa = (Nonterminal)rule.RHS[currentSymbolIndex + 1];

			foreach (Symbol symbol in FirstsDictionary[alfa]) {
				FollowDictionary[currentSymbol].Add(symbol);
			}
		}
	}
}