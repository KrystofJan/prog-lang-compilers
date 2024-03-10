using Grammar;
using System.Collections.Generic;
using System.Linq;
using RuleSets;

namespace Lab3;

public class GrammarOps {
	private IGrammar g;

	public ISet<Nonterminal> EmptyNonterminals { get; } = new HashSet<Nonterminal>();
	public ISet<Rule> VisitedRules { get; } = new HashSet<Rule>();
	public ISet<FirstRuleSet> First { get; } = new HashSet<FirstRuleSet>();
	public ISet<Symbol> SetOfFirstNonterminals { get; } = new HashSet<Symbol>();

	public GrammarOps(IGrammar g) {
		this.g = g;

		compute_first();
	}

	private void compute_empty() {
		foreach (var rule in g.Rules) {
			if (rule.RHS.Count == 0) {
				EmptyNonterminals.Add(rule.LHS);
				// VisitedRules.Add(rule);
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

	private void compute_first_terminal() {
		foreach (var rule in g.Rules) {
			VisitedRules.Clear();
			SetOfFirstNonterminals.Clear();
			
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
					compute_hidden_terminal(tmp.Rules);
				}
			}
			if (SetOfFirstNonterminals.Count == 0 || EmptyNonterminals.Contains(rule.LHS) ) {
				SetOfFirstNonterminals.Add(new EmptyTerminal());
			}
			ISet<Symbol> tmpp = new HashSet<Symbol>(SetOfFirstNonterminals);
			First.Add(new FirstRuleSet(
				rule: rule,
				symbolSet: tmpp
			));
		}
	}

	private void compute_hidden_terminal(List<Rule> rules) {
		foreach (Rule rule in rules) {
			if (VisitedRules.Contains(rule)) {
				continue;
			}
			foreach (var rightSide in rule.RHS) {
				if (rightSide is Terminal) {
					SetOfFirstNonterminals.Add(rightSide);
					VisitedRules.Add(rule);
					continue;
				}

				Nonterminal tmp = (Nonterminal)rightSide;
				compute_hidden_terminal(tmp.Rules);
				VisitedRules.Add(rule);
			}
		}
	}

	public void compute_first() {
		compute_empty();
		compute_first_terminal();
	}
}