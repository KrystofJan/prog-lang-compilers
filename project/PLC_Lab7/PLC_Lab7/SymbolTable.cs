using System.Collections.Generic;
using Antlr4.Runtime;

namespace PLC_Lab7;

public class SymbolTable {
	Dictionary<string, Variable> memory = new Dictionary<string, Variable>();

	public void Add(IToken variable, Type type) {
		var name = variable.Text.Trim();
		if (memory.ContainsKey(name)) {
			Errors.ReportError(variable, $"Variable {name} was already declared.");
		}
		else {
			if (type == Type.INT) memory.Add(name, new Variable(type, 0));
			else memory.Add(name, new Variable(type, (float) 0));
		}
	}

	public Variable this[IToken variable] {
		get {
			var name = variable.Text.Trim();
			if (memory.ContainsKey(name)) {
				return memory[name];
			}

			Errors.ReportError(variable, $"Variable {name} was NOT declared.");
			return new Variable(Type.ERROR, 0);
		}
		set {
			var name = variable.Text.Trim();
			memory[name] = value;
		}
	}
}