﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/zahry/school/pjp/project/PLC_Lab7/PLC_Lab7/PLC_Lab7_expr.g4 by ANTLR 4.6.6

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
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IPLC_Lab7_exprListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class PLC_Lab7_exprBaseListener : IPLC_Lab7_exprListener {
	/// <summary>
	/// Enter a parse tree produced by the <c>math</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMath([NotNull] PLC_Lab7_exprParser.MathContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>math</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMath([NotNull] PLC_Lab7_exprParser.MathContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>ass</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAss([NotNull] PLC_Lab7_exprParser.AssContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>ass</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAss([NotNull] PLC_Lab7_exprParser.AssContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>unar</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterUnar([NotNull] PLC_Lab7_exprParser.UnarContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>unar</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitUnar([NotNull] PLC_Lab7_exprParser.UnarContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>exprWrap</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExprWrap([NotNull] PLC_Lab7_exprParser.ExprWrapContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>exprWrap</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExprWrap([NotNull] PLC_Lab7_exprParser.ExprWrapContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>identity</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIdentity([NotNull] PLC_Lab7_exprParser.IdentityContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>identity</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIdentity([NotNull] PLC_Lab7_exprParser.IdentityContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>integerVal</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIntegerVal([NotNull] PLC_Lab7_exprParser.IntegerValContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>integerVal</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIntegerVal([NotNull] PLC_Lab7_exprParser.IntegerValContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>floatVal</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFloatVal([NotNull] PLC_Lab7_exprParser.FloatValContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>floatVal</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFloatVal([NotNull] PLC_Lab7_exprParser.FloatValContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>booleanVal</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBooleanVal([NotNull] PLC_Lab7_exprParser.BooleanValContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>booleanVal</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBooleanVal([NotNull] PLC_Lab7_exprParser.BooleanValContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>stringVal</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStringVal([NotNull] PLC_Lab7_exprParser.StringValContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>stringVal</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.values"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStringVal([NotNull] PLC_Lab7_exprParser.StringValContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.prog"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterProg([NotNull] PLC_Lab7_exprParser.ProgContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.prog"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitProg([NotNull] PLC_Lab7_exprParser.ProgContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.stat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStat([NotNull] PLC_Lab7_exprParser.StatContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.stat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStat([NotNull] PLC_Lab7_exprParser.StatContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.types"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTypes([NotNull] PLC_Lab7_exprParser.TypesContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.types"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTypes([NotNull] PLC_Lab7_exprParser.TypesContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.dtype"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDtype([NotNull] PLC_Lab7_exprParser.DtypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.dtype"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDtype([NotNull] PLC_Lab7_exprParser.DtypeContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.read"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRead([NotNull] PLC_Lab7_exprParser.ReadContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.read"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRead([NotNull] PLC_Lab7_exprParser.ReadContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.write"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterWrite([NotNull] PLC_Lab7_exprParser.WriteContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.write"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitWrite([NotNull] PLC_Lab7_exprParser.WriteContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.statwrap"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStatwrap([NotNull] PLC_Lab7_exprParser.StatwrapContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.statwrap"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStatwrap([NotNull] PLC_Lab7_exprParser.StatwrapContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.if"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIf([NotNull] PLC_Lab7_exprParser.IfContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.if"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIf([NotNull] PLC_Lab7_exprParser.IfContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.cond"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCond([NotNull] PLC_Lab7_exprParser.CondContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.cond"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCond([NotNull] PLC_Lab7_exprParser.CondContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.while"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterWhile([NotNull] PLC_Lab7_exprParser.WhileContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.while"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitWhile([NotNull] PLC_Lab7_exprParser.WhileContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.for"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFor([NotNull] PLC_Lab7_exprParser.ForContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.for"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFor([NotNull] PLC_Lab7_exprParser.ForContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExpr([NotNull] PLC_Lab7_exprParser.ExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExpr([NotNull] PLC_Lab7_exprParser.ExprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.unary"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterUnary([NotNull] PLC_Lab7_exprParser.UnaryContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.unary"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitUnary([NotNull] PLC_Lab7_exprParser.UnaryContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.assignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssignment([NotNull] PLC_Lab7_exprParser.AssignmentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.assignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssignment([NotNull] PLC_Lab7_exprParser.AssignmentContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>values</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.exprexprexprexprvaluesvaluesvaluesvaluesvalues"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterValues([NotNull] PLC_Lab7_exprParser.ValuesContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>values</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.exprexprexprexprvaluesvaluesvaluesvaluesvalues"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitValues([NotNull] PLC_Lab7_exprParser.ValuesContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.operation"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterOperation([NotNull] PLC_Lab7_exprParser.OperationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.operation"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitOperation([NotNull] PLC_Lab7_exprParser.OperationContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.operator"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterOperator([NotNull] PLC_Lab7_exprParser.OperatorContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.operator"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitOperator([NotNull] PLC_Lab7_exprParser.OperatorContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
} // namespace PLC_Lab7
