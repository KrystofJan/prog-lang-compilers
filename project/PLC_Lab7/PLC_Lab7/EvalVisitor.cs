using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;

namespace PLC_Lab7 {
	public class EvalVisitor : PLC_Lab7_exprBaseVisitor<Variable> {
		private SymbolTable SymbolTable { get; set; }

		public EvalVisitor(SymbolTable symbolTable) {
			SymbolTable = symbolTable;
		}

		// public override Variable VisitExprWithValue([NotNull] PLC_Lab7_exprParser.ExprWithValueContext context) {
		// 	var left = context.values().GetText();
		//
		// 	if (context.operation() == null) {
		// 		return new Variable(left);
		// 	}
		//
		// 	context.operation().@operator().GetText();
		// 	// rerer
		// 	return VisitChildren(context);
		// }
	}
}