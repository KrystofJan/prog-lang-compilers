using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Antlr4Lang1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "../../../input.txt";
            var inputFile = new StreamReader(fileName);
            AntlrInputStream input = new AntlrInputStream(inputFile);
            PLC_Lab7_exprLexer lexer = new PLC_Lab7_exprLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            PLC_Lab7_exprParser parser = new PLC_Lab7_exprParser(tokens);
            IParseTree tree = parser.prog();
            
            
            
        }
    }
}
