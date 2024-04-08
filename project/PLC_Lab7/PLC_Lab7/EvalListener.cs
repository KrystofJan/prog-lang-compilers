using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLC_Lab7
{
    public class EvalListener : PLC_Lab7_exprBaseListener
    {
        // public ParseTreeProperty<Type> values = new ParseTreeProperty<Type>();

        public SymbolTable SymbolTable = new SymbolTable();
        
        public override void ExitTypes([NotNull] PLC_Lab7_exprParser.TypesContext context) {
            Type t;
            switch (context.dtype().GetText().ToLower()) {
                case "int": {
                    t = Type.INT;
                    break;
                }
                case "float": {
                    t = Type.FLOAT;
                    break;
                }
                case "bool": {
                    t = Type.BOOL;
                    break;
                }
                case "string": {
                    t = Type.STRING;
                    break;
                }
                default: {
                    t = Type.ERROR;
                    break;
                }
            }
            
            foreach (var terminalNode in context.ID()) {
                SymbolTable.Add(terminalNode.Symbol, t);
            }
        }
    }
}
