using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using Instructions;
using Types;
using Type = Types.Type;

namespace Compiler {

	public class Compiler {
		
		public static void Compile(string inputFilePath, string outputFilePath) {
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
			var fileName = inputFilePath;
			var inputFile = new StreamReader(fileName);
			AntlrInputStream input = new AntlrInputStream(inputFile);
			PatterLexer lexer = new PatterLexer(input);
			CommonTokenStream tokens = new CommonTokenStream(lexer);
			PatterParser parser = new PatterParser(tokens);

			parser.AddErrorListener(new VerboseListener());

			IParseTree tree = parser.prog();

			if (parser.NumberOfSyntaxErrors == 0) {
				ParseTreeWalker walker = new ParseTreeWalker();
				EvalListener el = new EvalListener();
				walker.Walk(el, tree);

				EvalVisitor visitor = new EvalVisitor(el.SymbolTable);
				(Type type, InstructionStack instStack) myTyple = visitor.Visit(tree);
				Errors.PrintAndClearErrors();

				File.WriteAllText(outputFilePath, myTyple.instStack.ToString());
			}
		}
	}
	public class Program {



		public static void Main(string[] args) {
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
			var fileName = "input.pat";
			Console.WriteLine("Parsing: " + fileName);
			var inputFile = new StreamReader(fileName);
			AntlrInputStream input = new AntlrInputStream(inputFile);
			PatterLexer lexer = new PatterLexer(input);
			CommonTokenStream tokens = new CommonTokenStream(lexer);
			PatterParser parser = new PatterParser(tokens);

			parser.AddErrorListener(new VerboseListener());

			IParseTree tree = parser.prog();

			if (parser.NumberOfSyntaxErrors == 0) {
				Console.WriteLine(tree.ToStringTree(parser));
				ParseTreeWalker walker = new ParseTreeWalker();
				EvalListener el = new EvalListener();
				walker.Walk(el, tree);

				EvalVisitor visitor = new EvalVisitor(el.SymbolTable);
				(Type type, InstructionStack instStack) myTyple = visitor.Visit(tree);
				Errors.PrintAndClearErrors();


				Console.Write(myTyple.instStack.ToString());

				File.WriteAllText("output.vmc", myTyple.instStack.ToString());
			}
		}
	}
}