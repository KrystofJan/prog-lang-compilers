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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class PLC_Lab7_exprLexer : Lexer {
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, ID=19, INT=20, BOOL=21, FLOAT=22, STRING=23, WS=24, ASSIGN=25, 
		UN_MIN=26, NEG_OP=27, CMP_LT=28, CMP_MT=29, ADD_OP=30, MIN_OP=31, CONCAT_OP=32, 
		MUL_OP=33, DIV_OP=34, MOD_OP=35, LOG_OR=36, LOG_AND=37, EQ=38, NEQ=39;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "T__15", "T__16", 
		"T__17", "ID", "INT", "BOOL", "FLOAT", "STRING", "WS", "ASSIGN", "UN_MIN", 
		"NEG_OP", "CMP_LT", "CMP_MT", "ADD_OP", "MIN_OP", "CONCAT_OP", "MUL_OP", 
		"DIV_OP", "MOD_OP", "LOG_OR", "LOG_AND", "EQ", "NEQ"
	};


	public PLC_Lab7_exprLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, "';'", "','", "'int'", "'float'", "'bool'", "'string'", "'read'", 
		"'write'", "'{'", "'}'", "'if'", "'else'", "'while'", "'for'", "'('", 
		"')'", "'?'", "':'", null, null, null, null, null, null, "'='", null, 
		"'!'", "'<'", "'>'", "'+'", null, "'.'", "'*'", "'/'", "'%'", "'||'", 
		"'&&'", "'=='", "'!='"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, "ID", "INT", "BOOL", "FLOAT", 
		"STRING", "WS", "ASSIGN", "UN_MIN", "NEG_OP", "CMP_LT", "CMP_MT", "ADD_OP", 
		"MIN_OP", "CONCAT_OP", "MUL_OP", "DIV_OP", "MOD_OP", "LOG_OR", "LOG_AND", 
		"EQ", "NEQ"
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
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2)\xF0\b\x1\x4\x2"+
		"\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x4"+
		"\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4\x10"+
		"\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14\t\x14\x4\x15\t\x15"+
		"\x4\x16\t\x16\x4\x17\t\x17\x4\x18\t\x18\x4\x19\t\x19\x4\x1A\t\x1A\x4\x1B"+
		"\t\x1B\x4\x1C\t\x1C\x4\x1D\t\x1D\x4\x1E\t\x1E\x4\x1F\t\x1F\x4 \t \x4!"+
		"\t!\x4\"\t\"\x4#\t#\x4$\t$\x4%\t%\x4&\t&\x4\'\t\'\x4(\t(\x3\x2\x3\x2\x3"+
		"\x3\x3\x3\x3\x4\x3\x4\x3\x4\x3\x4\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5"+
		"\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\b"+
		"\x3\b\x3\b\x3\b\x3\b\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\n\x3\n\x3\v\x3\v"+
		"\x3\f\x3\f\x3\f\x3\r\x3\r\x3\r\x3\r\x3\r\x3\xE\x3\xE\x3\xE\x3\xE\x3\xE"+
		"\x3\xE\x3\xF\x3\xF\x3\xF\x3\xF\x3\x10\x3\x10\x3\x11\x3\x11\x3\x12\x3\x12"+
		"\x3\x13\x3\x13\x3\x14\x3\x14\a\x14\x97\n\x14\f\x14\xE\x14\x9A\v\x14\x3"+
		"\x15\x3\x15\a\x15\x9E\n\x15\f\x15\xE\x15\xA1\v\x15\x3\x15\x5\x15\xA4\n"+
		"\x15\x3\x16\x3\x16\x3\x16\x3\x16\x3\x16\x3\x16\x3\x16\x3\x16\x3\x16\x5"+
		"\x16\xAF\n\x16\x3\x17\x3\x17\a\x17\xB3\n\x17\f\x17\xE\x17\xB6\v\x17\x3"+
		"\x17\x3\x17\a\x17\xBA\n\x17\f\x17\xE\x17\xBD\v\x17\x3\x18\x3\x18\a\x18"+
		"\xC1\n\x18\f\x18\xE\x18\xC4\v\x18\x3\x18\x3\x18\x3\x19\x6\x19\xC9\n\x19"+
		"\r\x19\xE\x19\xCA\x3\x19\x3\x19\x3\x1A\x3\x1A\x3\x1B\x3\x1B\x3\x1C\x3"+
		"\x1C\x3\x1D\x3\x1D\x3\x1E\x3\x1E\x3\x1F\x3\x1F\x3 \x3 \x3!\x3!\x3\"\x3"+
		"\"\x3#\x3#\x3$\x3$\x3%\x3%\x3%\x3&\x3&\x3&\x3\'\x3\'\x3\'\x3(\x3(\x3("+
		"\x2\x2\x2)\x3\x2\x3\x5\x2\x4\a\x2\x5\t\x2\x6\v\x2\a\r\x2\b\xF\x2\t\x11"+
		"\x2\n\x13\x2\v\x15\x2\f\x17\x2\r\x19\x2\xE\x1B\x2\xF\x1D\x2\x10\x1F\x2"+
		"\x11!\x2\x12#\x2\x13%\x2\x14\'\x2\x15)\x2\x16+\x2\x17-\x2\x18/\x2\x19"+
		"\x31\x2\x1A\x33\x2\x1B\x35\x2\x1C\x37\x2\x1D\x39\x2\x1E;\x2\x1F=\x2 ?"+
		"\x2!\x41\x2\"\x43\x2#\x45\x2$G\x2%I\x2&K\x2\'M\x2(O\x2)\x3\x2\b\x4\x2"+
		"\x43\\\x63|\x6\x2\x32;\x43\\\x61\x61\x63|\x3\x2\x33;\x3\x2\x32;\t\x2\""+
		"#\'@\x42]__\x61\x61\x63}\x7F\x7F\x5\x2\v\f\xF\xF\"\"\xF7\x2\x3\x3\x2\x2"+
		"\x2\x2\x5\x3\x2\x2\x2\x2\a\x3\x2\x2\x2\x2\t\x3\x2\x2\x2\x2\v\x3\x2\x2"+
		"\x2\x2\r\x3\x2\x2\x2\x2\xF\x3\x2\x2\x2\x2\x11\x3\x2\x2\x2\x2\x13\x3\x2"+
		"\x2\x2\x2\x15\x3\x2\x2\x2\x2\x17\x3\x2\x2\x2\x2\x19\x3\x2\x2\x2\x2\x1B"+
		"\x3\x2\x2\x2\x2\x1D\x3\x2\x2\x2\x2\x1F\x3\x2\x2\x2\x2!\x3\x2\x2\x2\x2"+
		"#\x3\x2\x2\x2\x2%\x3\x2\x2\x2\x2\'\x3\x2\x2\x2\x2)\x3\x2\x2\x2\x2+\x3"+
		"\x2\x2\x2\x2-\x3\x2\x2\x2\x2/\x3\x2\x2\x2\x2\x31\x3\x2\x2\x2\x2\x33\x3"+
		"\x2\x2\x2\x2\x35\x3\x2\x2\x2\x2\x37\x3\x2\x2\x2\x2\x39\x3\x2\x2\x2\x2"+
		";\x3\x2\x2\x2\x2=\x3\x2\x2\x2\x2?\x3\x2\x2\x2\x2\x41\x3\x2\x2\x2\x2\x43"+
		"\x3\x2\x2\x2\x2\x45\x3\x2\x2\x2\x2G\x3\x2\x2\x2\x2I\x3\x2\x2\x2\x2K\x3"+
		"\x2\x2\x2\x2M\x3\x2\x2\x2\x2O\x3\x2\x2\x2\x3Q\x3\x2\x2\x2\x5S\x3\x2\x2"+
		"\x2\aU\x3\x2\x2\x2\tY\x3\x2\x2\x2\v_\x3\x2\x2\x2\r\x64\x3\x2\x2\x2\xF"+
		"k\x3\x2\x2\x2\x11p\x3\x2\x2\x2\x13v\x3\x2\x2\x2\x15x\x3\x2\x2\x2\x17z"+
		"\x3\x2\x2\x2\x19}\x3\x2\x2\x2\x1B\x82\x3\x2\x2\x2\x1D\x88\x3\x2\x2\x2"+
		"\x1F\x8C\x3\x2\x2\x2!\x8E\x3\x2\x2\x2#\x90\x3\x2\x2\x2%\x92\x3\x2\x2\x2"+
		"\'\x94\x3\x2\x2\x2)\xA3\x3\x2\x2\x2+\xAE\x3\x2\x2\x2-\xB0\x3\x2\x2\x2"+
		"/\xBE\x3\x2\x2\x2\x31\xC8\x3\x2\x2\x2\x33\xCE\x3\x2\x2\x2\x35\xD0\x3\x2"+
		"\x2\x2\x37\xD2\x3\x2\x2\x2\x39\xD4\x3\x2\x2\x2;\xD6\x3\x2\x2\x2=\xD8\x3"+
		"\x2\x2\x2?\xDA\x3\x2\x2\x2\x41\xDC\x3\x2\x2\x2\x43\xDE\x3\x2\x2\x2\x45"+
		"\xE0\x3\x2\x2\x2G\xE2\x3\x2\x2\x2I\xE4\x3\x2\x2\x2K\xE7\x3\x2\x2\x2M\xEA"+
		"\x3\x2\x2\x2O\xED\x3\x2\x2\x2QR\a=\x2\x2R\x4\x3\x2\x2\x2ST\a.\x2\x2T\x6"+
		"\x3\x2\x2\x2UV\ak\x2\x2VW\ap\x2\x2WX\av\x2\x2X\b\x3\x2\x2\x2YZ\ah\x2\x2"+
		"Z[\an\x2\x2[\\\aq\x2\x2\\]\a\x63\x2\x2]^\av\x2\x2^\n\x3\x2\x2\x2_`\a\x64"+
		"\x2\x2`\x61\aq\x2\x2\x61\x62\aq\x2\x2\x62\x63\an\x2\x2\x63\f\x3\x2\x2"+
		"\x2\x64\x65\au\x2\x2\x65\x66\av\x2\x2\x66g\at\x2\x2gh\ak\x2\x2hi\ap\x2"+
		"\x2ij\ai\x2\x2j\xE\x3\x2\x2\x2kl\at\x2\x2lm\ag\x2\x2mn\a\x63\x2\x2no\a"+
		"\x66\x2\x2o\x10\x3\x2\x2\x2pq\ay\x2\x2qr\at\x2\x2rs\ak\x2\x2st\av\x2\x2"+
		"tu\ag\x2\x2u\x12\x3\x2\x2\x2vw\a}\x2\x2w\x14\x3\x2\x2\x2xy\a\x7F\x2\x2"+
		"y\x16\x3\x2\x2\x2z{\ak\x2\x2{|\ah\x2\x2|\x18\x3\x2\x2\x2}~\ag\x2\x2~\x7F"+
		"\an\x2\x2\x7F\x80\au\x2\x2\x80\x81\ag\x2\x2\x81\x1A\x3\x2\x2\x2\x82\x83"+
		"\ay\x2\x2\x83\x84\aj\x2\x2\x84\x85\ak\x2\x2\x85\x86\an\x2\x2\x86\x87\a"+
		"g\x2\x2\x87\x1C\x3\x2\x2\x2\x88\x89\ah\x2\x2\x89\x8A\aq\x2\x2\x8A\x8B"+
		"\at\x2\x2\x8B\x1E\x3\x2\x2\x2\x8C\x8D\a*\x2\x2\x8D \x3\x2\x2\x2\x8E\x8F"+
		"\a+\x2\x2\x8F\"\x3\x2\x2\x2\x90\x91\a\x41\x2\x2\x91$\x3\x2\x2\x2\x92\x93"+
		"\a<\x2\x2\x93&\x3\x2\x2\x2\x94\x98\t\x2\x2\x2\x95\x97\t\x3\x2\x2\x96\x95"+
		"\x3\x2\x2\x2\x97\x9A\x3\x2\x2\x2\x98\x96\x3\x2\x2\x2\x98\x99\x3\x2\x2"+
		"\x2\x99(\x3\x2\x2\x2\x9A\x98\x3\x2\x2\x2\x9B\x9F\t\x4\x2\x2\x9C\x9E\t"+
		"\x5\x2\x2\x9D\x9C\x3\x2\x2\x2\x9E\xA1\x3\x2\x2\x2\x9F\x9D\x3\x2\x2\x2"+
		"\x9F\xA0\x3\x2\x2\x2\xA0\xA4\x3\x2\x2\x2\xA1\x9F\x3\x2\x2\x2\xA2\xA4\a"+
		"\x32\x2\x2\xA3\x9B\x3\x2\x2\x2\xA3\xA2\x3\x2\x2\x2\xA4*\x3\x2\x2\x2\xA5"+
		"\xA6\av\x2\x2\xA6\xA7\at\x2\x2\xA7\xA8\aw\x2\x2\xA8\xAF\ag\x2\x2\xA9\xAA"+
		"\ah\x2\x2\xAA\xAB\a\x63\x2\x2\xAB\xAC\an\x2\x2\xAC\xAD\au\x2\x2\xAD\xAF"+
		"\ag\x2\x2\xAE\xA5\x3\x2\x2\x2\xAE\xA9\x3\x2\x2\x2\xAF,\x3\x2\x2\x2\xB0"+
		"\xB4\t\x4\x2\x2\xB1\xB3\t\x5\x2\x2\xB2\xB1\x3\x2\x2\x2\xB3\xB6\x3\x2\x2"+
		"\x2\xB4\xB2\x3\x2\x2\x2\xB4\xB5\x3\x2\x2\x2\xB5\xB7\x3\x2\x2\x2\xB6\xB4"+
		"\x3\x2\x2\x2\xB7\xBB\a\x30\x2\x2\xB8\xBA\t\x5\x2\x2\xB9\xB8\x3\x2\x2\x2"+
		"\xBA\xBD\x3\x2\x2\x2\xBB\xB9\x3\x2\x2\x2\xBB\xBC\x3\x2\x2\x2\xBC.\x3\x2"+
		"\x2\x2\xBD\xBB\x3\x2\x2\x2\xBE\xC2\a$\x2\x2\xBF\xC1\t\x6\x2\x2\xC0\xBF"+
		"\x3\x2\x2\x2\xC1\xC4\x3\x2\x2\x2\xC2\xC0\x3\x2\x2\x2\xC2\xC3\x3\x2\x2"+
		"\x2\xC3\xC5\x3\x2\x2\x2\xC4\xC2\x3\x2\x2\x2\xC5\xC6\a$\x2\x2\xC6\x30\x3"+
		"\x2\x2\x2\xC7\xC9\t\a\x2\x2\xC8\xC7\x3\x2\x2\x2\xC9\xCA\x3\x2\x2\x2\xCA"+
		"\xC8\x3\x2\x2\x2\xCA\xCB\x3\x2\x2\x2\xCB\xCC\x3\x2\x2\x2\xCC\xCD\b\x19"+
		"\x2\x2\xCD\x32\x3\x2\x2\x2\xCE\xCF\a?\x2\x2\xCF\x34\x3\x2\x2\x2\xD0\xD1"+
		"\a/\x2\x2\xD1\x36\x3\x2\x2\x2\xD2\xD3\a#\x2\x2\xD3\x38\x3\x2\x2\x2\xD4"+
		"\xD5\a>\x2\x2\xD5:\x3\x2\x2\x2\xD6\xD7\a@\x2\x2\xD7<\x3\x2\x2\x2\xD8\xD9"+
		"\a-\x2\x2\xD9>\x3\x2\x2\x2\xDA\xDB\a/\x2\x2\xDB@\x3\x2\x2\x2\xDC\xDD\a"+
		"\x30\x2\x2\xDD\x42\x3\x2\x2\x2\xDE\xDF\a,\x2\x2\xDF\x44\x3\x2\x2\x2\xE0"+
		"\xE1\a\x31\x2\x2\xE1\x46\x3\x2\x2\x2\xE2\xE3\a\'\x2\x2\xE3H\x3\x2\x2\x2"+
		"\xE4\xE5\a~\x2\x2\xE5\xE6\a~\x2\x2\xE6J\x3\x2\x2\x2\xE7\xE8\a(\x2\x2\xE8"+
		"\xE9\a(\x2\x2\xE9L\x3\x2\x2\x2\xEA\xEB\a?\x2\x2\xEB\xEC\a?\x2\x2\xECN"+
		"\x3\x2\x2\x2\xED\xEE\a#\x2\x2\xEE\xEF\a?\x2\x2\xEFP\x3\x2\x2\x2\v\x2\x98"+
		"\x9F\xA3\xAE\xB4\xBB\xC2\xCA\x3\b\x2\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace PLC_Lab7
