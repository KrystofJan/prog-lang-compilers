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
        ParseTreeProperty<Type> values = new ParseTreeProperty<Type>();

        public override void ExitInt([NotNull] PLC_Lab7_exprParser.IntContext context)
        {
            values.Put(context, Convert.ToInt32(context.INT().GetText(),10));
        }
        public override void ExitHexa([NotNull] PLC_Lab7_exprParser.HexaContext context)
        {
            values.Put(context, Convert.ToInt32(context.HEXA().GetText(), 16));
        }
        
        public override void ExitOct([NotNull] PLC_Lab7_exprParser.OctContext context)
        {
            values.Put(context, Convert.ToInt32(context.OCT().GetText(), 8));
        }
        public override void ExitPar([NotNull] PLC_Lab7_exprParser.ParContext context)
        {
            values.Put(context, values.Get(context.expr()));
        }
        public override void ExitAdd([NotNull] PLC_Lab7_exprParser.AddContext context)
        {
            var left = values.Get(context.expr()[0]);
            var right = values.Get(context.expr()[1]);
            if (context.op.Text.Equals("+"))
            {
                values.Put(context, left + right);
            }else
            {
                values.Put(context, left - right);
            }   
        }
        public override void ExitMul([NotNull] PLC_Lab7_exprParser.MulContext context)
        {
            var left = values.Get(context.expr()[0]);
            var right = values.Get(context.expr()[1]);
            if (context.op.Text.Equals("*"))
            {
                values.Put(context, left * right);
            }
            else
            {
                values.Put(context, left / right);
            }
        }
        public override void ExitProg([NotNull] PLC_Lab7_exprParser.ProgContext context)
        {
            foreach(var expr in context.expr())
            {
                Console.WriteLine(values.Get(expr));
            }
        }
    }
}
