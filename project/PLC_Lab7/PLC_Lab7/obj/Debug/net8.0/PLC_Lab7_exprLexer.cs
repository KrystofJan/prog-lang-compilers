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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class PLC_Lab7_exprLexer : Lexer {
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, ID=16, INT=17, 
		BOOL=18, FLOAT=19, STRING=20, WS=21, ASSIGN=22, UN_MIN=23, NEG_OP=24, 
		BIN_AR_MUL=25, BIN_AR_ADD=26, LOG_OR=27, LOG_AND=28, CMP=29, REL=30;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "ID", "INT", "BOOL", 
		"FLOAT", "STRING", "WS", "ASSIGN", "UN_MIN", "NEG_OP", "BIN_AR_MUL", "BIN_AR_ADD", 
		"LOG_OR", "LOG_AND", "CMP", "REL"
	};


	public PLC_Lab7_exprLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, "';'", "','", "'int'", "'float'", "'bool'", "'string'", "'read'", 
		"'write'", "'{'", "'}'", "'if'", "'else'", "'('", "')'", "'while'", null, 
		null, null, null, null, null, "'='", "'-'", "'!'", null, null, "'||'", 
		"'&&'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, "ID", "INT", "BOOL", "FLOAT", "STRING", "WS", 
		"ASSIGN", "UN_MIN", "NEG_OP", "BIN_AR_MUL", "BIN_AR_ADD", "LOG_OR", "LOG_AND", 
		"CMP", "REL"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[System.Obsolete("Use Vocabulary instead.")]
	public static readonly string[] tokenNames = GenerateTokenNames(DefaultVocabulary, _SymbolicNames.Length);

	private static string[] GenerateTokenNames(IVocabulary vocabulary, int length) {
		string[] tokenNames = new string[length];
		for (int i = 0; i < tokenNames.Length; i++) {
			tokenNames[i] = vocabulary.GetLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = vocabulary.GetSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}

		return tokenNames;
	}

	[System.Obsolete("Use IRecognizer.Vocabulary instead.")]
	public override string[] TokenNames
	{
		get
		{
			return tokenNames;
		}
	}

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "PLC_Lab7_expr.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2 \xCC\b\x1\x4\x2"+
		"\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x4"+
		"\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4\x10"+
		"\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14\t\x14\x4\x15\t\x15"+
		"\x4\x16\t\x16\x4\x17\t\x17\x4\x18\t\x18\x4\x19\t\x19\x4\x1A\t\x1A\x4\x1B"+
		"\t\x1B\x4\x1C\t\x1C\x4\x1D\t\x1D\x4\x1E\t\x1E\x4\x1F\t\x1F\x3\x2\x3\x2"+
		"\x3\x3\x3\x3\x3\x4\x3\x4\x3\x4\x3\x4\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3"+
		"\x5\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3"+
		"\b\x3\b\x3\b\x3\b\x3\b\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\n\x3\n\x3\v\x3"+
		"\v\x3\f\x3\f\x3\f\x3\r\x3\r\x3\r\x3\r\x3\r\x3\xE\x3\xE\x3\xF\x3\xF\x3"+
		"\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x11\x3\x11\a\x11}\n\x11\f\x11"+
		"\xE\x11\x80\v\x11\x3\x12\x3\x12\a\x12\x84\n\x12\f\x12\xE\x12\x87\v\x12"+
		"\x3\x12\x5\x12\x8A\n\x12\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3"+
		"\x13\x3\x13\x3\x13\x5\x13\x95\n\x13\x3\x14\x3\x14\a\x14\x99\n\x14\f\x14"+
		"\xE\x14\x9C\v\x14\x3\x14\x3\x14\a\x14\xA0\n\x14\f\x14\xE\x14\xA3\v\x14"+
		"\x3\x15\x3\x15\a\x15\xA7\n\x15\f\x15\xE\x15\xAA\v\x15\x3\x15\x3\x15\x3"+
		"\x16\x6\x16\xAF\n\x16\r\x16\xE\x16\xB0\x3\x16\x3\x16\x3\x17\x3\x17\x3"+
		"\x18\x3\x18\x3\x19\x3\x19\x3\x1A\x3\x1A\x3\x1B\x3\x1B\x3\x1C\x3\x1C\x3"+
		"\x1C\x3\x1D\x3\x1D\x3\x1D\x3\x1E\x3\x1E\x3\x1E\x3\x1E\x5\x1E\xC9\n\x1E"+
		"\x3\x1F\x3\x1F\x2\x2\x2 \x3\x2\x3\x5\x2\x4\a\x2\x5\t\x2\x6\v\x2\a\r\x2"+
		"\b\xF\x2\t\x11\x2\n\x13\x2\v\x15\x2\f\x17\x2\r\x19\x2\xE\x1B\x2\xF\x1D"+
		"\x2\x10\x1F\x2\x11!\x2\x12#\x2\x13%\x2\x14\'\x2\x15)\x2\x16+\x2\x17-\x2"+
		"\x18/\x2\x19\x31\x2\x1A\x33\x2\x1B\x35\x2\x1C\x37\x2\x1D\x39\x2\x1E;\x2"+
		"\x1F=\x2 \x3\x2\v\x4\x2\x43\\\x63|\x6\x2\x32;\x43\\\x61\x61\x63|\x3\x2"+
		"\x33;\x3\x2\x32;\t\x2\"#\'@\x42]__\x61\x61\x63}\x7F\x7F\x5\x2\v\f\xF\xF"+
		"\"\"\x5\x2\'\',,\x31\x31\x4\x2--/\x30\x4\x2>>@@\xD4\x2\x3\x3\x2\x2\x2"+
		"\x2\x5\x3\x2\x2\x2\x2\a\x3\x2\x2\x2\x2\t\x3\x2\x2\x2\x2\v\x3\x2\x2\x2"+
		"\x2\r\x3\x2\x2\x2\x2\xF\x3\x2\x2\x2\x2\x11\x3\x2\x2\x2\x2\x13\x3\x2\x2"+
		"\x2\x2\x15\x3\x2\x2\x2\x2\x17\x3\x2\x2\x2\x2\x19\x3\x2\x2\x2\x2\x1B\x3"+
		"\x2\x2\x2\x2\x1D\x3\x2\x2\x2\x2\x1F\x3\x2\x2\x2\x2!\x3\x2\x2\x2\x2#\x3"+
		"\x2\x2\x2\x2%\x3\x2\x2\x2\x2\'\x3\x2\x2\x2\x2)\x3\x2\x2\x2\x2+\x3\x2\x2"+
		"\x2\x2-\x3\x2\x2\x2\x2/\x3\x2\x2\x2\x2\x31\x3\x2\x2\x2\x2\x33\x3\x2\x2"+
		"\x2\x2\x35\x3\x2\x2\x2\x2\x37\x3\x2\x2\x2\x2\x39\x3\x2\x2\x2\x2;\x3\x2"+
		"\x2\x2\x2=\x3\x2\x2\x2\x3?\x3\x2\x2\x2\x5\x41\x3\x2\x2\x2\a\x43\x3\x2"+
		"\x2\x2\tG\x3\x2\x2\x2\vM\x3\x2\x2\x2\rR\x3\x2\x2\x2\xFY\x3\x2\x2\x2\x11"+
		"^\x3\x2\x2\x2\x13\x64\x3\x2\x2\x2\x15\x66\x3\x2\x2\x2\x17h\x3\x2\x2\x2"+
		"\x19k\x3\x2\x2\x2\x1Bp\x3\x2\x2\x2\x1Dr\x3\x2\x2\x2\x1Ft\x3\x2\x2\x2!"+
		"z\x3\x2\x2\x2#\x89\x3\x2\x2\x2%\x94\x3\x2\x2\x2\'\x96\x3\x2\x2\x2)\xA4"+
		"\x3\x2\x2\x2+\xAE\x3\x2\x2\x2-\xB4\x3\x2\x2\x2/\xB6\x3\x2\x2\x2\x31\xB8"+
		"\x3\x2\x2\x2\x33\xBA\x3\x2\x2\x2\x35\xBC\x3\x2\x2\x2\x37\xBE\x3\x2\x2"+
		"\x2\x39\xC1\x3\x2\x2\x2;\xC8\x3\x2\x2\x2=\xCA\x3\x2\x2\x2?@\a=\x2\x2@"+
		"\x4\x3\x2\x2\x2\x41\x42\a.\x2\x2\x42\x6\x3\x2\x2\x2\x43\x44\ak\x2\x2\x44"+
		"\x45\ap\x2\x2\x45\x46\av\x2\x2\x46\b\x3\x2\x2\x2GH\ah\x2\x2HI\an\x2\x2"+
		"IJ\aq\x2\x2JK\a\x63\x2\x2KL\av\x2\x2L\n\x3\x2\x2\x2MN\a\x64\x2\x2NO\a"+
		"q\x2\x2OP\aq\x2\x2PQ\an\x2\x2Q\f\x3\x2\x2\x2RS\au\x2\x2ST\av\x2\x2TU\a"+
		"t\x2\x2UV\ak\x2\x2VW\ap\x2\x2WX\ai\x2\x2X\xE\x3\x2\x2\x2YZ\at\x2\x2Z["+
		"\ag\x2\x2[\\\a\x63\x2\x2\\]\a\x66\x2\x2]\x10\x3\x2\x2\x2^_\ay\x2\x2_`"+
		"\at\x2\x2`\x61\ak\x2\x2\x61\x62\av\x2\x2\x62\x63\ag\x2\x2\x63\x12\x3\x2"+
		"\x2\x2\x64\x65\a}\x2\x2\x65\x14\x3\x2\x2\x2\x66g\a\x7F\x2\x2g\x16\x3\x2"+
		"\x2\x2hi\ak\x2\x2ij\ah\x2\x2j\x18\x3\x2\x2\x2kl\ag\x2\x2lm\an\x2\x2mn"+
		"\au\x2\x2no\ag\x2\x2o\x1A\x3\x2\x2\x2pq\a*\x2\x2q\x1C\x3\x2\x2\x2rs\a"+
		"+\x2\x2s\x1E\x3\x2\x2\x2tu\ay\x2\x2uv\aj\x2\x2vw\ak\x2\x2wx\an\x2\x2x"+
		"y\ag\x2\x2y \x3\x2\x2\x2z~\t\x2\x2\x2{}\t\x3\x2\x2|{\x3\x2\x2\x2}\x80"+
		"\x3\x2\x2\x2~|\x3\x2\x2\x2~\x7F\x3\x2\x2\x2\x7F\"\x3\x2\x2\x2\x80~\x3"+
		"\x2\x2\x2\x81\x85\t\x4\x2\x2\x82\x84\t\x5\x2\x2\x83\x82\x3\x2\x2\x2\x84"+
		"\x87\x3\x2\x2\x2\x85\x83\x3\x2\x2\x2\x85\x86\x3\x2\x2\x2\x86\x8A\x3\x2"+
		"\x2\x2\x87\x85\x3\x2\x2\x2\x88\x8A\a\x32\x2\x2\x89\x81\x3\x2\x2\x2\x89"+
		"\x88\x3\x2\x2\x2\x8A$\x3\x2\x2\x2\x8B\x8C\av\x2\x2\x8C\x8D\at\x2\x2\x8D"+
		"\x8E\aw\x2\x2\x8E\x95\ag\x2\x2\x8F\x90\ah\x2\x2\x90\x91\a\x63\x2\x2\x91"+
		"\x92\an\x2\x2\x92\x93\au\x2\x2\x93\x95\ag\x2\x2\x94\x8B\x3\x2\x2\x2\x94"+
		"\x8F\x3\x2\x2\x2\x95&\x3\x2\x2\x2\x96\x9A\t\x4\x2\x2\x97\x99\t\x5\x2\x2"+
		"\x98\x97\x3\x2\x2\x2\x99\x9C\x3\x2\x2\x2\x9A\x98\x3\x2\x2\x2\x9A\x9B\x3"+
		"\x2\x2\x2\x9B\x9D\x3\x2\x2\x2\x9C\x9A\x3\x2\x2\x2\x9D\xA1\a\x30\x2\x2"+
		"\x9E\xA0\t\x5\x2\x2\x9F\x9E\x3\x2\x2\x2\xA0\xA3\x3\x2\x2\x2\xA1\x9F\x3"+
		"\x2\x2\x2\xA1\xA2\x3\x2\x2\x2\xA2(\x3\x2\x2\x2\xA3\xA1\x3\x2\x2\x2\xA4"+
		"\xA8\a$\x2\x2\xA5\xA7\t\x6\x2\x2\xA6\xA5\x3\x2\x2\x2\xA7\xAA\x3\x2\x2"+
		"\x2\xA8\xA6\x3\x2\x2\x2\xA8\xA9\x3\x2\x2\x2\xA9\xAB\x3\x2\x2\x2\xAA\xA8"+
		"\x3\x2\x2\x2\xAB\xAC\a$\x2\x2\xAC*\x3\x2\x2\x2\xAD\xAF\t\a\x2\x2\xAE\xAD"+
		"\x3\x2\x2\x2\xAF\xB0\x3\x2\x2\x2\xB0\xAE\x3\x2\x2\x2\xB0\xB1\x3\x2\x2"+
		"\x2\xB1\xB2\x3\x2\x2\x2\xB2\xB3\b\x16\x2\x2\xB3,\x3\x2\x2\x2\xB4\xB5\a"+
		"?\x2\x2\xB5.\x3\x2\x2\x2\xB6\xB7\a/\x2\x2\xB7\x30\x3\x2\x2\x2\xB8\xB9"+
		"\a#\x2\x2\xB9\x32\x3\x2\x2\x2\xBA\xBB\t\b\x2\x2\xBB\x34\x3\x2\x2\x2\xBC"+
		"\xBD\t\t\x2\x2\xBD\x36\x3\x2\x2\x2\xBE\xBF\a~\x2\x2\xBF\xC0\a~\x2\x2\xC0"+
		"\x38\x3\x2\x2\x2\xC1\xC2\a(\x2\x2\xC2\xC3\a(\x2\x2\xC3:\x3\x2\x2\x2\xC4"+
		"\xC5\a?\x2\x2\xC5\xC9\a?\x2\x2\xC6\xC7\a#\x2\x2\xC7\xC9\a?\x2\x2\xC8\xC4"+
		"\x3\x2\x2\x2\xC8\xC6\x3\x2\x2\x2\xC9<\x3\x2\x2\x2\xCA\xCB\t\n\x2\x2\xCB"+
		">\x3\x2\x2\x2\f\x2~\x85\x89\x94\x9A\xA1\xA8\xB0\xC8\x3\b\x2\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace PLC_Lab7
