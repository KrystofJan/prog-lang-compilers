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
			return new Variable(Type.BOOL, context.BOOL().GetText());
		}

		public override Variable VisitIdentity([NotNull] PLC_Lab7_exprParser.IdentityContext context) {
			return SymbolTable[context.ID().Symbol];
		}

		public override Variable VisitAssignment([NotNull] PLC_Lab7_exprParser.AssignmentContext context) {
			Variable lhs = SymbolTable[context.ID().Symbol];
			Variable rhs = Visit(context.expr());
			if (rhs.Type != lhs.Type) {
				Errors.ReportError(context.Start, $"Right side has different type than {context.ID().GetText()}. Left side is {lhs.Type.ToString()}. Right side is {rhs.Type.ToString()}.");
				return new Error(0);
			}
			return lhs;
		}

		public override Variable VisitMathAdd([NotNull] PLC_Lab7_exprParser.MathAddContext context) {
			Variable lhs = Visit(context.values());
			Variable rhs = Visit(context.expr());

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

		public override Variable VisitMathMul([NotNull] PLC_Lab7_exprParser.MathMulContext context) {
			Variable lhs = Visit(context.values());
			Variable rhs = Visit(context.expr());

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
				if (lhs.Type == Type.INT && rhs.Type == Type.FLOAT)
				{
					return rhs;
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
		
	}
}