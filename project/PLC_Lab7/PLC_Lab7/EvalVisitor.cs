using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLC_Lab7
{
    public class EvalVisitor : PLC_Lab7_exprBaseVisitor<int>
    {
        // public override int VisitInt([NotNull] PLC_Lab7_exprParser.IntContext context)
        // {
        //     return Convert.ToInt32(context.INT().GetText(), 10);
        // }
        // public override int VisitHexa([NotNull] PLC_Lab7_exprParser.HexaContext context)
        // {
        //     return Convert.ToInt32(context.HEXA().GetText(), 16);
        // }
        // public override int VisitOct([NotNull] PLC_Lab7_exprParser.OctContext context)
        // {
        //     return Convert.ToInt32(context.OCT().GetText(), 8);
        // }
        // public override int VisitPar([NotNull] PLC_Lab7_exprParser.ParContext context)
        // {
        //     return Visit(context.expr());
        // }
        // public override int VisitAdd([NotNull] PLC_Lab7_exprParser.AddContext context)
        // {
        //     var left = Visit(context.expr()[0]);
        //     var right = Visit(context.expr()[1]);
        //     if (context.op.Text.Equals("+"))
        //     {
        //         return left + right;
        //     }
        //     else
        //     {
        //         return left - right;
        //     }
        // }
        // public override int VisitMul([NotNull] PLC_Lab7_exprParser.MulContext context)
        // {
        //     var left = Visit(context.expr()[0]);
        //     var right = Visit(context.expr()[1]);
        //     if (context.op.Text.Equals("*"))
        //     {
        //         return left * right;
        //     }
        //     else
        //     {
        //         return left / right;
        //     }
        // }
        // public override int VisitProg([NotNull] PLC_Lab7_exprParser.ProgContext context)
        // {
        //     foreach (var expr in context.expr())
        //     {
        //         Console.WriteLine(Visit(expr));
        //     }
        //     return 0;
        // }
    }
}
