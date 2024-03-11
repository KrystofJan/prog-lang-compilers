using System.Collections.Generic;
using System.Text;
using Grammar;
namespace RuleSets;

public abstract class RuleSet {

	public Rule Rule { get; set; }

	protected string Type { get; }

	public ISet<Symbol> SymbolSet { get; set; }


	public RuleSet(Rule rule, ISet<Symbol> symbolSet, string type) {
		Rule = rule;
		SymbolSet = symbolSet;
		Type = type;
	}
	
	public override string ToString() {
		StringBuilder sb = new StringBuilder();
		sb.Append($"{Type}[{Rule.LHS.Name}:");
		foreach (Symbol symbol in Rule.RHS) {
			sb.Append($"{symbol.Name} ");
		}
		sb.Append("] = ");
		
		foreach (Symbol symbol in SymbolSet) {
			sb.Append($"{symbol.Name} ");
		}
		
		return sb.ToString();
	}
}

// TODO: follow
