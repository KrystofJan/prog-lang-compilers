using System.Collections.Generic;
using System.Text;
using Grammar;
namespace RuleSets;

public class FollowRuleSet : RuleSet{

	public Rule Rule { get; set; }
	private string Type { get; }
	public ISet<Symbol> SymbolSet { get; set; }

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
		sb.Append("\n");
		
		return sb.ToString();
	}

	public FollowRuleSet(Rule rule, ISet<Symbol> symbolSet) : base(rule, symbolSet, "Follow" ) {
	}
}