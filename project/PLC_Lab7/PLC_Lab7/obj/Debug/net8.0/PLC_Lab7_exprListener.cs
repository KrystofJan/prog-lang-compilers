﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\zahry\pjp\project\PLC_Lab7\PLC_Lab7\PLC_Lab7_expr.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace PLC_Lab7 {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="PLC_Lab7_exprParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface IPLC_Lab7_exprListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.prog"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProg([NotNull] PLC_Lab7_exprParser.ProgContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.prog"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProg([NotNull] PLC_Lab7_exprParser.ProgContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStat([NotNull] PLC_Lab7_exprParser.StatContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStat([NotNull] PLC_Lab7_exprParser.StatContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.types"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTypes([NotNull] PLC_Lab7_exprParser.TypesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.types"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTypes([NotNull] PLC_Lab7_exprParser.TypesContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.dtype"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDtype([NotNull] PLC_Lab7_exprParser.DtypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.dtype"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDtype([NotNull] PLC_Lab7_exprParser.DtypeContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.read"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRead([NotNull] PLC_Lab7_exprParser.ReadContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.read"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRead([NotNull] PLC_Lab7_exprParser.ReadContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.write"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWrite([NotNull] PLC_Lab7_exprParser.WriteContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.write"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWrite([NotNull] PLC_Lab7_exprParser.WriteContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.statwrap"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatwrap([NotNull] PLC_Lab7_exprParser.StatwrapContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.statwrap"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatwrap([NotNull] PLC_Lab7_exprParser.StatwrapContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.if"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIf([NotNull] PLC_Lab7_exprParser.IfContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.if"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIf([NotNull] PLC_Lab7_exprParser.IfContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.cond"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCond([NotNull] PLC_Lab7_exprParser.CondContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.cond"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCond([NotNull] PLC_Lab7_exprParser.CondContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.while"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhile([NotNull] PLC_Lab7_exprParser.WhileContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.while"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhile([NotNull] PLC_Lab7_exprParser.WhileContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.for"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFor([NotNull] PLC_Lab7_exprParser.ForContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.for"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFor([NotNull] PLC_Lab7_exprParser.ForContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpr([NotNull] PLC_Lab7_exprParser.ExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpr([NotNull] PLC_Lab7_exprParser.ExprContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.unary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnary([NotNull] PLC_Lab7_exprParser.UnaryContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.unary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnary([NotNull] PLC_Lab7_exprParser.UnaryContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignment([NotNull] PLC_Lab7_exprParser.AssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignment([NotNull] PLC_Lab7_exprParser.AssignmentContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.values"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterValues([NotNull] PLC_Lab7_exprParser.ValuesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.values"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitValues([NotNull] PLC_Lab7_exprParser.ValuesContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.operation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperation([NotNull] PLC_Lab7_exprParser.OperationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.operation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperation([NotNull] PLC_Lab7_exprParser.OperationContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.operator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperator([NotNull] PLC_Lab7_exprParser.OperatorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.operator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperator([NotNull] PLC_Lab7_exprParser.OperatorContext context);
}
} // namespace PLC_Lab7
