﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/zahry/Downloads/plc_lab/PLC_Lab7_solution/PLC_Lab7/PLC_Lab7/PLC_Lab7_expr.g4 by ANTLR 4.6.6

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
	/// Enter a parse tree produced by the <c>mul</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMul([NotNull] PLC_Lab7_exprParser.MulContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>mul</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMul([NotNull] PLC_Lab7_exprParser.MulContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>add</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAdd([NotNull] PLC_Lab7_exprParser.AddContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>add</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAdd([NotNull] PLC_Lab7_exprParser.AddContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>int</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInt([NotNull] PLC_Lab7_exprParser.IntContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>int</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInt([NotNull] PLC_Lab7_exprParser.IntContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>oct</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOct([NotNull] PLC_Lab7_exprParser.OctContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>oct</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOct([NotNull] PLC_Lab7_exprParser.OctContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>hexa</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterHexa([NotNull] PLC_Lab7_exprParser.HexaContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>hexa</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitHexa([NotNull] PLC_Lab7_exprParser.HexaContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>par</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPar([NotNull] PLC_Lab7_exprParser.ParContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>par</c>
	/// labeled alternative in <see cref="PLC_Lab7_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPar([NotNull] PLC_Lab7_exprParser.ParContext context);

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
	/// Enter a parse tree produced by <see cref="PLC_Lab7_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpr([NotNull] PLC_Lab7_exprParser.ExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PLC_Lab7_exprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpr([NotNull] PLC_Lab7_exprParser.ExprContext context);
}
} // namespace PLC_Lab7
