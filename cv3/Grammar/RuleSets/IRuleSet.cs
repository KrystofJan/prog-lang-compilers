using System.Collections.Generic;
using Grammar;
namespace RuleSets;

public class IRuleSet {
	public Rule Rule { get; set; }

	protected string Type { get; }

	public ISet<Symbol> SymbolSet { get; set; }
}