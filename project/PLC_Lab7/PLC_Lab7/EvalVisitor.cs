﻿using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;

namespace PLC_Lab7 {
	public class EvalVisitor : PLC_Lab7_exprBaseVisitor<Variable> {
		private SymbolTable SymbolTable { get; set; }

		public EvalVisitor(SymbolTable symbolTable) {
			SymbolTable = symbolTable;
		}

		private Variable parseToFloat(Variable val) {
			val.Type = Type.FLOAT;
			val.Value = float.Parse(val.Value.ToString());
			return val;
		}
		public override Variable VisitIntegerVal([NotNull] PLC_Lab7_exprParser.IntegerValContext context) {
			return new Variable(Type.INT, int.Parse(context.INT().GetText()));
		}
		
		public override Variable VisitFloatVal([NotNull] PLC_Lab7_exprParser.FloatValContext context) {
			return new Variable(Type.FLOAT, float.Parse(context.FLOAT().GetText()));
		}
				
		public override Variable VisitStringVal([NotNull] PLC_Lab7_exprParser.StringValContext context) {
			return new Variable(Type.STRING, context.STRING().GetText());
		}
		
		public override Variable VisitBooleanVal([NotNull] PLC_Lab7_exprParser.BooleanValContext context) {
			return new Variable(Type.BOOL, context.BOOL().Symbol.Text == "true" );
		}

		public override Variable VisitIdentity([NotNull] PLC_Lab7_exprParser.IdentityContext context) {
			var sym = context.ID().Symbol;
			
			if (sym.Text == "true") {
				return new Variable(Type.BOOL, true);
			}
			
			if (sym.Text == "false") {
				return new Variable(Type.BOOL, false);
			}
			return SymbolTable[context.ID().Symbol];
		}

		public override Variable VisitExprAss([NotNull] PLC_Lab7_exprParser.ExprAssContext context) {
			Variable lhs = Visit(context.expr()[0]);
			Variable rhs = Visit(context.expr()[1]);

			if (lhs.Type == Type.FLOAT && rhs.Type == Type.INT)
			{
				return lhs;
			}

			if (rhs.Type != lhs.Type) {
				Errors.ReportError(context.Start, $"Right side has different type than {rhs.Type.ToString()}. Left side is {lhs.Type.ToString()}. Right side is {rhs.Type.ToString()}.");
				return new Error(0);
			}
			return lhs;
		}

		public override Variable VisitExprAdd([NotNull] PLC_Lab7_exprParser.ExprAddContext context) {
			Variable lhs = Visit(context.expr()[0]);
			Variable rhs = Visit(context.expr()[1]);

			if (context.op.Type == PLC_Lab7_exprParser.CONCAT_OP) {
				if (lhs.Type != Type.STRING && rhs.Type != Type.STRING) {
					Errors.ReportError(context.Start, $"Both concatenation operands should be of type string. Left: {lhs.Type.ToString()}. Right: {rhs.Type.ToString()} ");
					return new Error(0);
				}
				return new Variable(Type.STRING, true);
			}
			if (context.op.Type == PLC_Lab7_exprParser.ADD_OP || context.op.Type == PLC_Lab7_exprParser.MIN_OP) {
				if (lhs.Type == rhs.Type) {
					if (lhs.Type == Type.INT)
					{
						return lhs;
					}
					if (lhs.Type == Type.FLOAT)
					{
						return lhs;
					}
				}

				if (lhs.Type == Type.INT && rhs.Type == Type.FLOAT) {
					return rhs;
				}
				if (lhs.Type == Type.FLOAT && rhs.Type == Type.INT) {
					return lhs;
				}

				Errors.ReportError(context.Start, $"Both + or - operators should be either INT or FLOAT type. Left is: {lhs.Type}. Right is: {rhs.Type}");
				return new Error(0);
			}
			Errors.ReportError(context.Start, $"Actually impossible lol");
			return new Error(0);
		}

		public override Variable VisitExprMul([NotNull] PLC_Lab7_exprParser.ExprMulContext context) {
			Variable lhs = Visit(context.expr()[0]);
			Variable rhs = Visit(context.expr()[1]);

			if (context.op.Type == PLC_Lab7_exprParser.MOD_OP) {
				if (lhs.Type != rhs.Type) {
					Errors.ReportError(context.Start, $"Modulo has to have both types be the same. Left is: {lhs.Type} and the right is: {rhs.Type}");
					return new Error(0);
				}
				if (lhs.Type != Type.INT || rhs.Type != Type.INT) {
					Errors.ReportError(context.Start, $"Modulo operators should be INT type. Left is: {lhs.Type}. Right is: {rhs.Type}");
					return new Error(0);
				}
				return lhs;
			}
			if (context.op.Type == PLC_Lab7_exprParser.MUL_OP || context.op.Type == PLC_Lab7_exprParser.DIV_OP) {
				if (lhs.Type == rhs.Type) {
					if (lhs.Type == Type.INT)
					{
						return lhs;
					}
					if (lhs.Type == Type.FLOAT)
					{
						return lhs;
					}
				}
				if (lhs.Type == Type.INT && rhs.Type == Type.FLOAT) {
					return parseToFloat(lhs);
				}
				if (lhs.Type == Type.FLOAT && rhs.Type == Type.INT)
				{
					return lhs;
				}
				Errors.ReportError(context.Start, $"Both * or / operators should be either INT or FLOAT type. Left is: {lhs.Type}. Right is: {rhs.Type}");
				return new Error(0);
			}
			Errors.ReportError(context.Start, $"Literally impossible lol");
			return new Error(0);
		}

		public override Variable VisitExprAnd([NotNull] PLC_Lab7_exprParser.ExprAndContext context) {
			Variable lhs = Visit(context.expr()[0]);
			Variable rhs = Visit(context.expr()[1]);

			if (lhs.Type != Type.BOOL || rhs.Type != Type.BOOL) {
				Errors.ReportError(context.Start, $"Both sides of && operator have to be of type Bool. Left is: {lhs.Type}. Right is: {rhs.Type}");
				return new Error(0);
			}

			return lhs;
		}
		
		public override Variable VisitExprOr([NotNull] PLC_Lab7_exprParser.ExprOrContext context) {
			Variable lhs = Visit(context.expr()[0]);
			Variable rhs = Visit(context.expr()[1]);

			if (lhs.Type != Type.BOOL || rhs.Type != Type.BOOL) {
				Errors.ReportError(context.Start, $"Both sides of && operator have to be of type Bool. Left is: {lhs.Type}. Right is: {rhs.Type}");
				return new Error(0);
			}

			return lhs;
		}

		public override Variable VisitExprTernar([NotNull] PLC_Lab7_exprParser.ExprTernarContext context) {
			Variable cond = Visit(context.cond);
			Variable truthy = Visit(context.tb);
			Variable falsy = Visit(context.fb);

			if (cond.Type != Type.BOOL) {
				Errors.ReportError(context.Start, $"COndition must be boolean: {cond.Type}" );
				return new Error(0);
			}
			if (truthy.Type != falsy.Type) {
				if (truthy.Type == Type.FLOAT) {
					// pretypovat	
					falsy = parseToFloat(falsy);
				}
				else if (falsy.Type == Type.FLOAT) {
					truthy = parseToFloat(truthy);
				}
				else {
					Errors.ReportError(context.Start, $"Ternary branches have to match type! true branch: {truthy.Type} false branch: {falsy.Type}" );
					return new Error(0);
				}
			}
			return (cond.Value == (object) true) ? truthy : falsy;
		}

		// public override Variable VisitUnary([NotNull] PLC_Lab7_exprParser.UnaryContext context) {
		// 	Variable expr = Visit(context.());
		// 	if (expr.Type != Type.INT && expr.Type == Type.FLOAT) {
		// 		Errors.ReportError(context.Start, $"Unary has to be of type int or float and is {expr.Type}");
		// 		return new Error(0);
		// 	}
		//
		// 	return expr;
		// }
	}
}