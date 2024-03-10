using System.Collections.Generic;
using System.Text;
using Grammar;

namespace RuleSets;

public class FirstRuleSet : RuleSet {
	public Rule Rule { get; set; }
	public string Type { get; }
	public ISet<Symbol> SymbolSet { get; set; }

	public FirstRuleSet(Rule rule, ISet<Symbol> symbolSet) : base(rule, symbolSet, "First" ) {
		
	}
}