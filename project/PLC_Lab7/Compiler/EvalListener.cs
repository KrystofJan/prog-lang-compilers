using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace Compiler;

public class EvalListener : PatterBaseListener {
	// public ParseTreeProperty<Type> values = new ParseTreeProperty<Type>();

	public SymbolTable SymbolTable = new SymbolTable();

	// public override void ExitDecleration([NotNull] PLC_Lab7_exprParser.DeclerationContext context) {
	// 	Type t;
	// 	switch (context.dtype().GetText().ToLower()) {
	// 		case "int": {
	// 			t = Type.INT;
	// 			break;
	// 		}
	// 		case "float": {
	// 			t = Type.FLOAT;
	// 			break;
	// 		}
	// 		case "bool": {
	// 			t = Type.BOOL;
	// 			break;
	// 		}
	// 		case "string": {
	// 			t = Type.STRING;
	// 			break;
	// 		}
	// 		default: {
	// 			t = Type.ERROR;
	// 			break;
	// 		}
	// 	}
	//
	// 	foreach (var terminalNode in context.ID()) {
	// 		SymbolTable.Add(terminalNode.Symbol, t);
	// 	}
	// }
}
