using System.Collections.Generic;
using System.Text;
using Grammar;
namespace RuleSets;

public class FollowRuleSet{
	public Dictionary<Nonterminal, HashSet<Symbol>> Follow { get; } = new Dictionary<Nonterminal, HashSet<Symbol>>();
	
	public override string ToString() {
		StringBuilder sb = new StringBuilder();
		foreach (var follow in Follow) {
			sb.Append($"Follow[{follow.Key.Name}]:");
			
			foreach (var value in follow.Value) {
				sb.Append($"{value.Name} ");
			}
			sb.Append('\n');
		}
		return sb.ToString();
	}

	public FollowRuleSet(Dictionary<Nonterminal, HashSet<Symbol>> follow) {
		Follow = follow;
	}
}