using System.Collections.Generic;
using System.Text;
using Grammar;

namespace RuleSets;

public class FirstRuleSet : RuleSet {
	public FirstRuleSet(Rule rule, ISet<Symbol> symbolSet) : base(rule, symbolSet, "First" ){
	}
}