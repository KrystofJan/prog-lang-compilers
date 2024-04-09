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
	/// Enter a parse tree produced by the <c>assExpr</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssExpr([NotNull] PLC_Lab7_exprParser.AssExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>assExpr</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssExpr([NotNull] PLC_Lab7_exprParser.AssExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>assTail</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssTail([NotNull] PLC_Lab7_exprParser.AssTailContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>assTail</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssTail([NotNull] PLC_Lab7_exprParser.AssTailContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>mathTern</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.ternary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMathTern([NotNull] PLC_Lab7_exprParser.MathTernContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>mathTern</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.ternary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMathTern([NotNull] PLC_Lab7_exprParser.MathTernContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>tailTern</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.ternary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTailTern([NotNull] PLC_Lab7_exprParser.TailTernContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>tailTern</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.ternary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTailTern([NotNull] PLC_Lab7_exprParser.TailTernContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>orExpr</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathOr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOrExpr([NotNull] PLC_Lab7_exprParser.OrExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>orExpr</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathOr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOrExpr([NotNull] PLC_Lab7_exprParser.OrExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>tailOr</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathOr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTailOr([NotNull] PLC_Lab7_exprParser.TailOrContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>tailOr</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathOr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTailOr([NotNull] PLC_Lab7_exprParser.TailOrContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>andExpr</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathAnd"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAndExpr([NotNull] PLC_Lab7_exprParser.AndExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>andExpr</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathAnd"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAndExpr([NotNull] PLC_Lab7_exprParser.AndExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>tailAnd</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathAnd"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTailAnd([NotNull] PLC_Lab7_exprParser.TailAndContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>tailAnd</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathAnd"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTailAnd([NotNull] PLC_Lab7_exprParser.TailAndContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>identity</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentity([NotNull] PLC_Lab7_exprParser.IdentityContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>identity</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentity([NotNull] PLC_Lab7_exprParser.IdentityContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>integerVal</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIntegerVal([NotNull] PLC_Lab7_exprParser.IntegerValContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>integerVal</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIntegerVal([NotNull] PLC_Lab7_exprParser.IntegerValContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>floatVal</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFloatVal([NotNull] PLC_Lab7_exprParser.FloatValContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>floatVal</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFloatVal([NotNull] PLC_Lab7_exprParser.FloatValContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>booleanVal</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBooleanVal([NotNull] PLC_Lab7_exprParser.BooleanValContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>booleanVal</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBooleanVal([NotNull] PLC_Lab7_exprParser.BooleanValContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>stringVal</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStringVal([NotNull] PLC_Lab7_exprParser.StringValContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>stringVal</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStringVal([NotNull] PLC_Lab7_exprParser.StringValContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>addExpr</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathAdd"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddExpr([NotNull] PLC_Lab7_exprParser.AddExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>addExpr</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathAdd"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddExpr([NotNull] PLC_Lab7_exprParser.AddExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>tailAdd</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathAdd"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTailAdd([NotNull] PLC_Lab7_exprParser.TailAddContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>tailAdd</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathAdd"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTailAdd([NotNull] PLC_Lab7_exprParser.TailAddContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>mulExpr</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathMul"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMulExpr([NotNull] PLC_Lab7_exprParser.MulExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>mulExpr</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathMul"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMulExpr([NotNull] PLC_Lab7_exprParser.MulExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>tailMul</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathMul"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTailMul([NotNull] PLC_Lab7_exprParser.TailMulContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>tailMul</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathMul"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTailMul([NotNull] PLC_Lab7_exprParser.TailMulContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>cmpExpr</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathCmp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCmpExpr([NotNull] PLC_Lab7_exprParser.CmpExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>cmpExpr</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathCmp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCmpExpr([NotNull] PLC_Lab7_exprParser.CmpExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>cmpTail</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathCmp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCmpTail([NotNull] PLC_Lab7_exprParser.CmpTailContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>cmpTail</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.mathCmp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCmpTail([NotNull] PLC_Lab7_exprParser.CmpTailContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>mathValue</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.tail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMathValue([NotNull] PLC_Lab7_exprParser.MathValueContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>mathValue</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.tail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMathValue([NotNull] PLC_Lab7_exprParser.MathValueContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>exprWrap</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.tail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExprWrap([NotNull] PLC_Lab7_exprParser.ExprWrapContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>exprWrap</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.tail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExprWrap([NotNull] PLC_Lab7_exprParser.ExprWrapContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>unar</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.tail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnar([NotNull] PLC_Lab7_exprParser.UnarContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>unar</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.tail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnar([NotNull] PLC_Lab7_exprParser.UnarContext context);

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
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.assignmentTail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignmentTail([NotNull] PLC_Lab7_exprParser.AssignmentTailContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.assignmentTail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignmentTail([NotNull] PLC_Lab7_exprParser.AssignmentTailContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.ternary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTernary([NotNull] PLC_Lab7_exprParser.TernaryContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.ternary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTernary([NotNull] PLC_Lab7_exprParser.TernaryContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.ternaryTail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTernaryTail([NotNull] PLC_Lab7_exprParser.TernaryTailContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.ternaryTail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTernaryTail([NotNull] PLC_Lab7_exprParser.TernaryTailContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.mathOr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMathOr([NotNull] PLC_Lab7_exprParser.MathOrContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.mathOr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMathOr([NotNull] PLC_Lab7_exprParser.MathOrContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.orTail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOrTail([NotNull] PLC_Lab7_exprParser.OrTailContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.orTail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOrTail([NotNull] PLC_Lab7_exprParser.OrTailContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.mathAnd"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMathAnd([NotNull] PLC_Lab7_exprParser.MathAndContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.mathAnd"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMathAnd([NotNull] PLC_Lab7_exprParser.MathAndContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.andTail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAndTail([NotNull] PLC_Lab7_exprParser.AndTailContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.andTail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAndTail([NotNull] PLC_Lab7_exprParser.AndTailContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>values</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.assignmentassignmentternaryternarymathOrmathOrmathAndmathAndvaluesvaluesvaluesvaluesvaluesmathAddmathAddmathMulmathMulmathCmpmathCmptailtailtail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterValues([NotNull] PLC_Lab7_exprParser.ValuesContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>values</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.assignmentassignmentternaryternarymathOrmathOrmathAndmathAndvaluesvaluesvaluesvaluesvaluesmathAddmathAddmathMulmathMulmathCmpmathCmptailtailtail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitValues([NotNull] PLC_Lab7_exprParser.ValuesContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.mathAdd"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMathAdd([NotNull] PLC_Lab7_exprParser.MathAddContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.mathAdd"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMathAdd([NotNull] PLC_Lab7_exprParser.MathAddContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.addTail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddTail([NotNull] PLC_Lab7_exprParser.AddTailContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.addTail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddTail([NotNull] PLC_Lab7_exprParser.AddTailContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.mathMul"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMathMul([NotNull] PLC_Lab7_exprParser.MathMulContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.mathMul"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMathMul([NotNull] PLC_Lab7_exprParser.MathMulContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.mulTail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMulTail([NotNull] PLC_Lab7_exprParser.MulTailContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.mulTail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMulTail([NotNull] PLC_Lab7_exprParser.MulTailContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.mathCmp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMathCmp([NotNull] PLC_Lab7_exprParser.MathCmpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.mathCmp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMathCmp([NotNull] PLC_Lab7_exprParser.MathCmpContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.compTail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompTail([NotNull] PLC_Lab7_exprParser.CompTailContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.compTail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompTail([NotNull] PLC_Lab7_exprParser.CompTailContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.mathRel"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMathRel([NotNull] PLC_Lab7_exprParser.MathRelContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.mathRel"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMathRel([NotNull] PLC_Lab7_exprParser.MathRelContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.relTail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRelTail([NotNull] PLC_Lab7_exprParser.RelTailContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.relTail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRelTail([NotNull] PLC_Lab7_exprParser.RelTailContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.tail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTail([NotNull] PLC_Lab7_exprParser.TailContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.tail"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTail([NotNull] PLC_Lab7_exprParser.TailContext context);
}
} // namespace PLC_Lab7
