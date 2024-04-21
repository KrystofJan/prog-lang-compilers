using Antlr4.Runtime.Misc;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;
using Instructions;
using Types;
using Type = Types.Type;

namespace Compiler;

public class EvalVisitor : PatterBaseVisitor<(Type type, InstructionStack instStack)> {
	private SymbolTable SymbolTable { get; set; }

	private Dictionary<Type, object> TypeBaseValues = new Dictionary<Type, object>() {
		{Type.INT, 0},
		{Type.BOOL, false},
		{Type.STRING, "\"\""},
		{Type.FLOAT, float.Parse("0.0")}
	};

	public EvalVisitor(SymbolTable symbolTable) {
		SymbolTable = symbolTable;
	}

	private int _counter = -1;

	private int Counter() {
		return ++_counter;
	}

	public override (Type type, InstructionStack instStack) VisitIntegerVal(
		[NotNull] PatterParser.IntegerValContext context) {
		return (
			Type.INT,
			new InstructionStack(
				new Instruction {
					InstructionType = InstructionTypes.PUSH,
					Type = Type.INT,
					Value = int.Parse(context.INT().GetText())
				}
			)
		);
	}

	public override (Type type, InstructionStack instStack) VisitFloatVal(
		[NotNull] PatterParser.FloatValContext context) {
		return (Type.FLOAT, new InstructionStack(
			new Instruction {
				InstructionType = InstructionTypes.PUSH,
				Type = Type.FLOAT,
				Value = float.Parse(context.FLOAT().GetText())
			}
		));
	}

	public override (Type type, InstructionStack instStack) VisitStringVal(
		[NotNull] PatterParser.StringValContext context) {
		return (Type.STRING, new InstructionStack(
			new Instruction {
				InstructionType = InstructionTypes.PUSH,
				Type = Type.STRING,
				Value = context.STRING().GetText()
			}
		));
	}

	public override (Type type, InstructionStack instStack) VisitBooleanVal(
		[NotNull] PatterParser.BooleanValContext context) {
		return (Type.BOOL, new InstructionStack(
			new Instruction {
				InstructionType = InstructionTypes.PUSH,
				Type = Type.BOOL,
				Value = context.BOOL().Symbol.Text == "true"
			}
		));
	}

	public override (Type type, InstructionStack instStack) VisitIdentity(
		[NotNull] PatterParser.IdentityContext context) {
		var sym = context.ID().Symbol;

		if (sym.Text == "true") {
			return (Type.BOOL, new InstructionStack(
				new Instruction {
					InstructionType = InstructionTypes.PUSH,
					Type = Type.BOOL,
					Value = true
				}
			));
		}

		if (sym.Text == "false") {
			return (Type.BOOL, new InstructionStack(
				new Instruction {
					InstructionType = InstructionTypes.PUSH,
					Type = Type.BOOL,
					Value = false
				}
			));
		}

		var tmp = SymbolTable[context.ID().Symbol];
		return (tmp.Type, new InstructionStack(
			new Instruction {
				InstructionType = InstructionTypes.LOAD,
				Value = context.ID().Symbol.Text
			}
		));
	}

	public override (Type type, InstructionStack instStack) VisitExprAss(
		[NotNull] PatterParser.ExprAssContext context) {
		var lhs = SymbolTable[context.ID().Symbol];
		var rhs = Visit(context.expr());
		InstructionStack instructionStack = new InstructionStack(rhs.instStack);

		if (lhs.Type != rhs.type) {
			if (lhs.Type == Type.FLOAT && rhs.type == Type.INT) {
				instructionStack.Push(new Instruction {
					InstructionType = InstructionTypes.ITOF
				});
				instructionStack.Push(new Instruction {
					InstructionType = InstructionTypes.SAVE,
					Value = context.ID().GetText()
				});
				instructionStack.Push(new Instruction {
					InstructionType = InstructionTypes.LOAD,
					Value = context.ID().GetText()
				});
				return (Type.FLOAT, instructionStack);
			}

			Errors.ReportError(context.Start,
				$"Right side has different type than {rhs.ToString()}. Left side is {lhs.Type.ToString()}. Right side is {rhs.type.ToString()}.");
			return (Type.ERROR, new InstructionStack());
		}
		
		instructionStack.Push(new Instruction {
			InstructionType = InstructionTypes.SAVE,
			Value = context.ID().GetText()
		});
		instructionStack.Push(new Instruction {
			InstructionType = InstructionTypes.LOAD,
			Value = context.ID().GetText()
		});
		
		return (lhs.Type, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitExprAdd(
		[NotNull] PatterParser.ExprAddContext context) {
		var lhs = Visit(context.expr()[0]);
		var rhs = Visit(context.expr()[1]);

		if (context.op.Type == PatterParser.CONCAT_OP) {
			if (lhs.type != Type.STRING && rhs.type != Type.STRING) {
				Errors.ReportError(context.Start,
					$"Both concatenation operands should be of type string. Left: {lhs.type.ToString()}. Right: {rhs.type.ToString()} ");
				return (Type.ERROR, new InstructionStack());
			}

			InstructionStack instructionStack = new InstructionStack(lhs.instStack);
			instructionStack.Push(rhs.instStack);
			instructionStack.Push(new Instruction {
				InstructionType = InstructionTypes.CONCAT,
				Type = Type.STRING
			});
			return (Type.STRING, instructionStack);
		}

		if (context.op.Type == PatterParser.ADD_OP || context.op.Type == PatterParser.MIN_OP) {
			InstructionStack instructionStack = new InstructionStack(lhs.instStack);
			if (lhs.type == rhs.type) {
				if (lhs.type == Type.INT || lhs.type == Type.FLOAT) {
					instructionStack.Push(rhs.instStack);
					instructionStack.Push(new Instruction {
						InstructionType = (context.op.Type == PatterParser.ADD_OP)
							? InstructionTypes.ADD
							: InstructionTypes.SUB,
						Type = lhs.type
					});
					return (lhs.type, instructionStack);
				}
				Errors.ReportError(context.Start,
					$"Unparsable types. Left: {lhs.type.ToString()}. Right: {rhs.type.ToString()} ");
				return (Type.ERROR, new InstructionStack());
			}

			if (lhs.type == Type.INT && rhs.type == Type.FLOAT) {
				instructionStack.Push(new Instruction {
					InstructionType = InstructionTypes.ITOF
				});
				instructionStack.Push(rhs.instStack);
				instructionStack.Push(new Instruction {
					InstructionType = (context.op.Type == PatterParser.ADD_OP)
						? InstructionTypes.ADD
						: InstructionTypes.SUB,
					Type = rhs.type
				});
				return (rhs.type, instructionStack);
			}

			if (lhs.type == Type.FLOAT && rhs.type == Type.INT) {
				instructionStack.Push(rhs.instStack);
				instructionStack.Push(new Instruction {
					InstructionType = InstructionTypes.ITOF
				});
				instructionStack.Push(new Instruction {
					InstructionType = (context.op.Type == PatterParser.ADD_OP)
						? InstructionTypes.ADD
						: InstructionTypes.SUB,
					Type = lhs.type
				});
				return (rhs.type, instructionStack);
			}

			Errors.ReportError(context.Start,
				$"Both + or - operators should be either INT or FLOAT type. Left is: {lhs.type}. Right is: {rhs.type}");
			return new(Type.ERROR, new InstructionStack());
		}

		Errors.ReportError(context.Start, $"Actually impossible lol");
		return new(Type.ERROR, new InstructionStack());
	}

	public override (Type type, InstructionStack instStack) VisitPrimaryWrapped(
		[NotNull] PatterParser.PrimaryWrappedContext context) {
		return Visit(context.expr());
	}

	public override (Type type, InstructionStack instStack) VisitPrimaryValues(
		[NotNull] PatterParser.PrimaryValuesContext context) {
		return Visit(context.values());
	}

	public override (Type type, InstructionStack instStack) VisitExprPrimary(
		[NotNull] PatterParser.ExprPrimaryContext context) {
		var primary = Visit(context.primary());
		InstructionStack instructionStack = new InstructionStack(primary.instStack);
		foreach (var expr in context.expr()) {
			var expression = Visit(expr);
			instructionStack.Push(expression.instStack);
		}

		return (primary.type, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitUnaryNeg(
		[NotNull] PatterParser.UnaryNegContext context) {
		var expr = Visit(context.expr());
		if (expr.type != Type.BOOL) {
			Errors.ReportError(context.Start,
				$"Negation can only be used in Boolean type expression is of type {expr.type.ToString()}.");
			return (Type.ERROR, new InstructionStack());
		}

		InstructionStack instructionStack = new InstructionStack();
		instructionStack.Push(expr.instStack);
		instructionStack.Push(new Instruction {
			InstructionType = InstructionTypes.NOT
		});
		return (expr.type, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitUnaryMin(
		[NotNull] PatterParser.UnaryMinContext context) {
		var expr = Visit(context.expr());
		if (expr.type != Type.INT && expr.type != Type.FLOAT) {
			Errors.ReportError(context.Start,
			 	$"Unary minus has to be assigned to int or float values. expression is of type  {expr.type.ToString()} ");
			return (Type.ERROR, new InstructionStack());
		}
        // TODO: Investigate -> Dont know why, but when I have a wrapped expression unary minus has more priority
        // than Minus
		InstructionStack instructionStack = new InstructionStack();
		instructionStack.Push(expr.instStack);
		instructionStack.Push(new Instruction {
			InstructionType = InstructionTypes.UMINUS
		});
		return (expr.type, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitExprRl(
		[NotNull] PatterParser.ExprRlContext context) {
		var lhs = Visit(context.expr()[0]);
		var rhs = Visit(context.expr()[1]);

		if (context.op.Type == PatterParser.CMP_GT || context.op.Type == PatterParser.CMP_LT) {
			InstructionStack instructionStack = new InstructionStack(lhs.instStack);
			if (lhs.type == rhs.type) {
				if (lhs.type == Type.INT || lhs.type == Type.FLOAT) {
					instructionStack.Push(rhs.instStack);
					instructionStack.Push(new Instruction {
						InstructionType = (context.op.Type == PatterParser.CMP_GT)
							? InstructionTypes.GT
							: InstructionTypes.LT
					});
					return (Type.BOOL, instructionStack);
				}
				Errors.ReportError(context.Start,
					$"Unparsable type in rl expression. Left: {lhs.type.ToString()}. Right: {rhs.type.ToString()} ");
				return (Type.ERROR, new InstructionStack());
			}

			if (lhs.type == Type.INT && rhs.type == Type.FLOAT) {
				instructionStack.Push(new Instruction {
					InstructionType = InstructionTypes.ITOF
				});
				instructionStack.Push(rhs.instStack);
				instructionStack.Push(new Instruction {
					InstructionType = (context.op.Type == PatterParser.CMP_GT)
						? InstructionTypes.GT
						: InstructionTypes.LT
				});
				return (rhs.type, instructionStack);
			}

			if (lhs.type == Type.FLOAT && rhs.type == Type.INT) {
				instructionStack.Push(rhs.instStack);
				instructionStack.Push(new Instruction {
					InstructionType = InstructionTypes.ITOF
				});
				instructionStack.Push(new Instruction {
					InstructionType = (context.op.Type == PatterParser.CMP_GT)
						? InstructionTypes.GT
						: InstructionTypes.LT
				});
				return (rhs.type, instructionStack);
			}

			Errors.ReportError(context.Start,
				$"Both + or - operators should be either INT or FLOAT type. Left is: {lhs.type}. Right is: {rhs.type}");
			return new(Type.ERROR, new InstructionStack());
		}

		Errors.ReportError(context.Start, $"Actually impossible lol");
		return new(Type.ERROR, new InstructionStack());
	}

	public override (Type type, InstructionStack instStack) VisitScoped(
		[NotNull] PatterParser.ScopedContext context) {
		return Visit(context.statwrap());
	}

	public override (Type type, InstructionStack instStack) VisitStatwrap(
		[NotNull] PatterParser.StatwrapContext context) {
		InstructionStack instructionStack = new InstructionStack();
		var stats = context.stat();
		for (int i = 0; i < stats.Length; ++i) {
			var currentStat = Visit(stats[i]);
			instructionStack.Push(currentStat.instStack);
		}

		return (Type.ERROR, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitExp(
		[NotNull] PatterParser.ExpContext context) {
		var expr = Visit(context.expr());
		InstructionStack instructionStack = new InstructionStack(expr.instStack);
		instructionStack.Push(new Instruction {
			InstructionType = InstructionTypes.POP
		});

		return (expr.type, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitIf(
		[NotNull] PatterParser.IfContext context) {
		var cond = Visit(context.expr());
		if (cond.type != Type.BOOL) {
			Errors.ReportError(context.Start,
				$"If statement condition has to be of type Bool but is {cond.type.ToString()}.");
			Errors.ReportError(context.Start,
				$"COndition in if statement has to return type Bool bu returns {cond.type}");
			return (Type.ERROR, new InstructionStack());
		}

		var stats = context.stat();
		var ifScope = Visit(stats[0]);
		var elseScope = Visit(stats[0]);
		if (stats.Length > 1) {
			elseScope = Visit(stats[1]);
		}


		int false_branch = Counter();
		int true_branch = Counter();
			
		// investigate
		InstructionStack instructionStack = new InstructionStack(cond.instStack);
		instructionStack.Push(new Instruction {
			InstructionType = InstructionTypes.FJMP,
			Value = false_branch
		});
		instructionStack.Push(ifScope.instStack);

		instructionStack.Push(new Instruction {
			InstructionType = InstructionTypes.JMP,
			Value = true_branch
		});

		instructionStack.Push(new Instruction {
			InstructionType = InstructionTypes.LABEL,
			Value = false_branch
		});

		if (stats.Length > 1) {
			instructionStack.Push(elseScope.instStack);
		}
		instructionStack.Push(new Instruction {
			InstructionType = InstructionTypes.LABEL,
			Value = true_branch
		});

		return (Type.ERROR, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitProg(
		[NotNull] PatterParser.ProgContext context) {
		InstructionStack instructionStack = new InstructionStack();
		foreach (var stat in context.stat()) {
			var statCont = Visit(stat);
			instructionStack.Push(statCont.instStack);
		}

		return (Type.ERROR, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitWhile(
		[NotNull] PatterParser.WhileContext context) {
		var cond = Visit(context.expr());
		var cyc = Visit(context.stat());

		int cmpBranch = Counter();
		int continueBranch = Counter();
		InstructionStack instructionStack = new InstructionStack();
		instructionStack.Push(new Instruction {
			InstructionType = InstructionTypes.LABEL,
			Value = cmpBranch
		});
		instructionStack.Push(cond.instStack);
		instructionStack.Push(new Instruction {
			InstructionType = InstructionTypes.FJMP,
			Value = continueBranch
		});
		instructionStack.Push(cyc.instStack);
		instructionStack.Push(new Instruction {
			InstructionType = InstructionTypes.JMP,
			Value = cmpBranch
		});
		instructionStack.Push(new Instruction {
			InstructionType = InstructionTypes.LABEL,
			Value = continueBranch
		});

		return (Type.ERROR, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitExprCmp(
		[NotNull] PatterParser.ExprCmpContext context) {
		var lhs = Visit(context.expr()[0]);
		var rhs = Visit(context.expr()[1]);

		if (context.op.Type == PatterParser.EQ || context.op.Type == PatterParser.NEQ) {
			InstructionStack instructionStack = new InstructionStack(lhs.instStack);
			if (lhs.type == rhs.type) {
				instructionStack.Push(rhs.instStack);
				instructionStack.Push(new Instruction {
					InstructionType = InstructionTypes.EQ
				});
				if (context.op.Type == PatterParser.NEQ) {
					instructionStack.Push(new Instruction {
						InstructionType = InstructionTypes.NOT
					});
				}
				return (Type.BOOL, instructionStack);
			}

			Errors.ReportError(context.Start,
				$"Both + or - operators should be either INT or FLOAT type. Left is: {lhs.type}. Right is: {rhs.type}");
			return new(Type.ERROR, new InstructionStack());
		}

		Errors.ReportError(context.Start, $"Actually impossible lol");
		return new(Type.ERROR, new InstructionStack());
	}

	public override (Type type, InstructionStack instStack) VisitExprMul(
		[NotNull] PatterParser.ExprMulContext context) {
		var lhs = Visit(context.expr()[0]);
		var rhs = Visit(context.expr()[1]);
		InstructionStack instructionStack = new InstructionStack(lhs.instStack);

		if (context.op.Type == PatterParser.MOD_OP) {
			if (lhs.type != rhs.type) {
				Errors.ReportError(context.Start,
					$"Modulo has to have both types be the same. Left is: {lhs.type} and the right is: {rhs.type}");
				return new(Type.ERROR, new InstructionStack());
			}

			if (lhs.type != Type.INT || rhs.type != Type.INT) {
				Errors.ReportError(context.Start,
					$"Modulo operators should be INT type. Left is: {lhs.type}. Right is: {rhs.type}");
				return new(Type.ERROR, new InstructionStack());
			}

			instructionStack.Push(rhs.instStack);
			instructionStack.Push(new Instruction {
				InstructionType = InstructionTypes.MOD,
				Type = lhs.type
			});
			return (lhs.type, instructionStack);
		}

		if (context.op.Type == PatterParser.MUL_OP || context.op.Type == PatterParser.DIV_OP) {
			if (lhs.type == rhs.type) {
				if (lhs.type == Type.INT || lhs.type == Type.FLOAT) {
					instructionStack.Push(rhs.instStack);
					instructionStack.Push(new Instruction {
						InstructionType = (context.op.Type == PatterParser.MUL_OP)
							? InstructionTypes.MUL
							: InstructionTypes.DIV,
						Type = lhs.type
					});
					return (lhs.type, instructionStack);
				}
			}

			if (lhs.type == Type.INT && rhs.type == Type.FLOAT) {
				instructionStack.Push(new Instruction {
					InstructionType = InstructionTypes.ITOF
				});
				instructionStack.Push(rhs.instStack);
				instructionStack.Push(new Instruction {
					InstructionType = (context.op.Type == PatterParser.MUL_OP)
						? InstructionTypes.MUL
						: InstructionTypes.DIV,
					Type = rhs.type
				});
				return (rhs.type, instructionStack);
			}

			if (lhs.type == Type.FLOAT && rhs.type == Type.INT) {
				instructionStack.Push(rhs.instStack);
				instructionStack.Push(new Instruction {
					InstructionType = InstructionTypes.ITOF
				});
				instructionStack.Push(new Instruction {
					InstructionType = (context.op.Type == PatterParser.MUL_OP)
						? InstructionTypes.MUL
						: InstructionTypes.DIV,
					Type = lhs.type
				});
				return (lhs.type, instructionStack);
			}

			Errors.ReportError(context.Start,
				$"Both * or / operators should be either INT or FLOAT type. Left is: {lhs.type}. Right is: {rhs.type}");
			return (Type.ERROR, new InstructionStack());
		}

		Errors.ReportError(context.Start, $"Literally impossible lol");
		return (Type.ERROR, new InstructionStack());
	}

	public override (Type type, InstructionStack instStack) VisitExprAnd(
		[NotNull] PatterParser.ExprAndContext context) {
		var lhs = Visit(context.expr()[0]);
		var rhs = Visit(context.expr()[1]);

		if (lhs.type != Type.BOOL || rhs.type != Type.BOOL) {
			Errors.ReportError(context.Start,
				$"Both sides of && operator have to be of type Bool. Left is: {lhs.type}. Right is: {rhs.type}");
			return (Type.ERROR, new InstructionStack());
		}

		InstructionStack instructionStack = new InstructionStack(lhs.instStack);
		instructionStack.Push(rhs.instStack);
		instructionStack.Push(new Instruction {
			InstructionType = InstructionTypes.AND
		});
		return (Type.BOOL, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitExprOr(
		[NotNull] PatterParser.ExprOrContext context) {
		var lhs = Visit(context.expr()[0]);
		var rhs = Visit(context.expr()[1]);

		if (lhs.type != Type.BOOL || rhs.type != Type.BOOL) {
			Errors.ReportError(context.Start,
				$"Both sides of && operator have to be of type Bool. Left is: {lhs.type}. Right is: {rhs.type}");
			return (Type.ERROR, new InstructionStack());
		}

		InstructionStack instructionStack = new InstructionStack(lhs.instStack);
		instructionStack.Push(rhs.instStack);
		instructionStack.Push(new Instruction {
			InstructionType = InstructionTypes.OR
		});

		return (Type.BOOL, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitExprTernar(
		[NotNull] PatterParser.ExprTernarContext context) {
		var cond = Visit(context.cond);
		var truthy = Visit(context.tb);
		var falsy = Visit(context.fb);
		InstructionStack instructionStack = new InstructionStack(cond.instStack);

		if (cond.type != Type.BOOL) {
			Errors.ReportError(context.Start, $"Condition must be boolean: {cond.type}");
			return (Type.ERROR, new InstructionStack());
		}

		instructionStack.Push(truthy.instStack);

		if (truthy.type != falsy.type) {
			if (truthy.type == Type.FLOAT) {
				instructionStack.Push(falsy.instStack);
				instructionStack.Push(new Instruction {
					InstructionType = InstructionTypes.ITOF
				});
				instructionStack.Push(new Instruction {
					InstructionType = (context.op.Type == PatterParser.MUL_OP)
						? InstructionTypes.MUL
						: InstructionTypes.DIV
				});
				return (truthy.type, instructionStack);
			}

			if (falsy.type == Type.FLOAT) {
				instructionStack.Push(falsy.instStack);
				instructionStack.Push(new Instruction {
					InstructionType = InstructionTypes.ITOF
				});
				instructionStack.Push(new Instruction {
					InstructionType = (context.op.Type == PatterParser.MUL_OP)
						? InstructionTypes.MUL
						: InstructionTypes.DIV
				});
				return (truthy.type, instructionStack);
			}

			Errors.ReportError(context.Start,
				$"Ternary branches have to match type! true branch: {truthy.type} false branch: {falsy.type}");
			return (Type.ERROR, new InstructionStack());
		}

		Errors.ReportError(context.Start,
			$"Ternary branches have to match type! true branch: {truthy.type} false branch: {falsy.type}");
		return (Type.ERROR, new InstructionStack());
	}

	public override (Type type, InstructionStack instStack) VisitDecleration(
		[NotNull] PatterParser.DeclerationContext context) {
		var dtype = Visit(context.dtype());
		InstructionStack instructionStack = new InstructionStack();
		foreach (var id in context.ID()) {
			SymbolTable.Add(id.Symbol, dtype.type);
			instructionStack.Push(new Instruction {
				InstructionType = InstructionTypes.PUSH,
				Type = dtype.type,
				Value = TypeBaseValues[dtype.type]
			});
			instructionStack.Push(new Instruction {
				InstructionType = InstructionTypes.SAVE,
				Value = id.Symbol.Text
			});
		}

		return (Type.ERROR, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitIntDtype(
		[NotNull] PatterParser.IntDtypeContext context) {
		return (Type.INT, new InstructionStack());
	}
	
	public override (Type type, InstructionStack instStack) VisitStrDtype([NotNull] PatterParser.StrDtypeContext context) {
		return (Type.STRING, new InstructionStack());
	}
	
	public override (Type type, InstructionStack instStack) VisitFltDtype([NotNull] PatterParser.FltDtypeContext context) {
		return (Type.FLOAT, new InstructionStack());
	}

	public override (Type type, InstructionStack instStack) VisitBolDtype(
		[NotNull] PatterParser.BolDtypeContext context) {
		return (Type.BOOL, new InstructionStack());
	}

	public override (Type type, InstructionStack instStack) VisitSem([NotNull] PatterParser.SemContext context) {
		return (Type.ERROR, new InstructionStack());
	}

	public override (Type type, InstructionStack instStack)VisitDecl(
		[NotNull] PatterParser.DeclContext context) {
		return Visit(context.decleration());
	}

	public override (Type type, InstructionStack instStack) VisitRd(
		[NotNull] PatterParser.RdContext context) {
		return Visit(context.read());
	}

	public override (Type type, InstructionStack instStack)VisitRead(
		[NotNull] PatterParser.ReadContext context) {
		var ids = context.ID();
		InstructionStack instructionStack = new InstructionStack();
		foreach (var id in ids) {
			var tmp = SymbolTable[id.Symbol];
			instructionStack.Push(new Instruction {
				InstructionType = InstructionTypes.READ,
				Value = tmp.Type.ToString()
			});
			instructionStack.Push(new Instruction {
				InstructionType = InstructionTypes.SAVE,
				Value = id.Symbol.Text
			});
		}

		return (Type.ERROR, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitWr(
		[NotNull] PatterParser.WrContext context) {
		return Visit(context.write());
	}

	public override (Type type, InstructionStack instStack) VisitWrite(
		[NotNull] PatterParser.WriteContext context) {
		var exprs = context.expr();
		InstructionStack instructionStack = new InstructionStack();

		foreach (var expr in exprs) {
			var tmp = Visit(expr);
			instructionStack.Push(tmp.instStack);
		}

		instructionStack.Push(new Instruction {
			InstructionType = InstructionTypes.PRINT,
			Value = exprs.Length
		});
		return (Type.ERROR, instructionStack);
	}
}
