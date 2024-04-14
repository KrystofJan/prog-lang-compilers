﻿using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;

namespace PLC_Lab7;

public class EvalVisitor : PLC_Lab7_exprBaseVisitor<(Type type, InstructionStack instStack)> {
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

	private int _counter = 0;

	private int Counter() {
		return ++_counter;
	}

	public override (Type type, InstructionStack instStack) VisitIntegerVal(
		[NotNull] PLC_Lab7_exprParser.IntegerValContext context) {
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
		[NotNull] PLC_Lab7_exprParser.FloatValContext context) {
		return (Type.FLOAT, new InstructionStack(
			new Instruction {
				InstructionType = InstructionTypes.PUSH,
				Type = Type.FLOAT,
				Value = float.Parse(context.FLOAT().GetText())
			}
		));
	}

	public override (Type type, InstructionStack instStack) VisitStringVal(
		[NotNull] PLC_Lab7_exprParser.StringValContext context) {
		return (Type.STRING, new InstructionStack(
			new Instruction {
				InstructionType = InstructionTypes.PUSH,
				Type = Type.STRING,
				Value = context.STRING().GetText()
			}
		));
	}

	public override (Type type, InstructionStack instStack) VisitBooleanVal(
		[NotNull] PLC_Lab7_exprParser.BooleanValContext context) {
		return (Type.BOOL, new InstructionStack(
			new Instruction {
				InstructionType = InstructionTypes.PUSH,
				Type = Type.BOOL,
				Value = context.BOOL().Symbol.Text == "true"
			}
		));
	}

	public override (Type type, InstructionStack instStack) VisitIdentity(
		[NotNull] PLC_Lab7_exprParser.IdentityContext context) {
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
		[NotNull] PLC_Lab7_exprParser.ExprAssContext context) {
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

		return (lhs.Type, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitExprAdd(
		[NotNull] PLC_Lab7_exprParser.ExprAddContext context) {
		var lhs = Visit(context.expr()[0]);
		var rhs = Visit(context.expr()[1]);

		if (context.op.Type == PLC_Lab7_exprParser.CONCAT_OP) {
			if (lhs.type != Type.STRING && rhs.type != Type.STRING) {
				Errors.ReportError(context.Start,
					$"Both concatenation operands should be of type string. Left: {lhs.type.ToString()}. Right: {rhs.type.ToString()} ");
				return (Type.ERROR, new InstructionStack());
			}

			InstructionStack instructionStack = new InstructionStack(lhs.instStack);
			instructionStack.Push(rhs.instStack);
			instructionStack.Push(new Instruction {
				InstructionType = InstructionTypes.CONCAT
			});
			return (Type.STRING, instructionStack);
		}

		if (context.op.Type == PLC_Lab7_exprParser.ADD_OP || context.op.Type == PLC_Lab7_exprParser.MIN_OP) {
			InstructionStack instructionStack = new InstructionStack(lhs.instStack);
			if (lhs.type == rhs.type) {
				if (lhs.type == Type.INT || lhs.type == Type.FLOAT) {
					instructionStack.Push(rhs.instStack);
					instructionStack.Push(new Instruction {
						InstructionType = (context.op.Type == PLC_Lab7_exprParser.ADD_OP)
							? InstructionTypes.ADD
							: InstructionTypes.SUB
					});
					return (lhs.type, instructionStack);
				}

				Errors.ReportError(context.Start,
					$"ThisSomeBuiishit");
				return (Type.ERROR, new InstructionStack());
			}

			if (lhs.type == Type.INT && rhs.type == Type.FLOAT) {
				instructionStack.Push(new Instruction {
					InstructionType = InstructionTypes.ITOF
				});
				instructionStack.Push(rhs.instStack);
				instructionStack.Push(new Instruction {
					InstructionType = (context.op.Type == PLC_Lab7_exprParser.ADD_OP)
						? InstructionTypes.ADD
						: InstructionTypes.SUB
				});
				return (rhs.type, instructionStack);
			}

			if (lhs.type == Type.FLOAT && rhs.type == Type.INT) {
				instructionStack.Push(rhs.instStack);
				instructionStack.Push(new Instruction {
					InstructionType = InstructionTypes.ITOF
				});
				instructionStack.Push(new Instruction {
					InstructionType = (context.op.Type == PLC_Lab7_exprParser.ADD_OP)
						? InstructionTypes.ADD
						: InstructionTypes.SUB
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
		[NotNull] PLC_Lab7_exprParser.PrimaryWrappedContext context) {
		return Visit(context.expr());
	}

	public override (Type type, InstructionStack instStack) VisitPrimaryValues(
		[NotNull] PLC_Lab7_exprParser.PrimaryValuesContext context) {
		return Visit(context.values());
	}

	public override (Type type, InstructionStack instStack) VisitExprPrimary(
		[NotNull] PLC_Lab7_exprParser.ExprPrimaryContext context) {
		var primary = Visit(context.primary());
		InstructionStack instructionStack = new InstructionStack(primary.instStack);
		foreach (var expr in context.expr()) {
			var expression = Visit(expr);
			instructionStack.Push(expression.instStack);
		}

		return (primary.type, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitUnaryNeg(
		[NotNull] PLC_Lab7_exprParser.UnaryNegContext context) {
		var expr = Visit(context.expr());
		if (expr.type != Type.BOOL) {
			// error
			return (Type.ERROR, new InstructionStack());
		}

		InstructionStack instructionStack = new InstructionStack();
		instructionStack.Push(new Instruction {
			InstructionType = InstructionTypes.NOT
		});
		instructionStack.Push(expr.instStack);
		return (expr.type, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitUnaryMin(
		[NotNull] PLC_Lab7_exprParser.UnaryMinContext context) {
		var expr = Visit(context.expr());
		if (expr.type != Type.INT || expr.type != Type.FLOAT) {
			// error
			return (Type.ERROR, new InstructionStack());
		}

		InstructionStack instructionStack = new InstructionStack();
		instructionStack.Push(new Instruction {
			InstructionType = InstructionTypes.UMINUS
		});
		instructionStack.Push(expr.instStack);
		return (expr.type, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitExprRl(
		[NotNull] PLC_Lab7_exprParser.ExprRlContext context) {
		var lhs = Visit(context.expr()[0]);
		var rhs = Visit(context.expr()[1]);

		if (context.op.Type == PLC_Lab7_exprParser.CMP_GT || context.op.Type == PLC_Lab7_exprParser.CMP_LT) {
			InstructionStack instructionStack = new InstructionStack(lhs.instStack);
			if (lhs.type == rhs.type) {
				if (lhs.type == Type.INT || lhs.type == Type.FLOAT) {
					instructionStack.Push(rhs.instStack);
					instructionStack.Push(new Instruction {
						InstructionType = (context.op.Type == PLC_Lab7_exprParser.CMP_GT)
							? InstructionTypes.GT
							: InstructionTypes.LT
					});
					return (Type.BOOL, instructionStack);
				}

				return (Type.ERROR, new InstructionStack());
			}

			if (lhs.type == Type.INT && rhs.type == Type.FLOAT) {
				instructionStack.Push(new Instruction {
					InstructionType = InstructionTypes.ITOF
				});
				instructionStack.Push(rhs.instStack);
				instructionStack.Push(new Instruction {
					InstructionType = (context.op.Type == PLC_Lab7_exprParser.CMP_GT)
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
					InstructionType = (context.op.Type == PLC_Lab7_exprParser.CMP_GT)
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
		[NotNull] PLC_Lab7_exprParser.ScopedContext context) {
		return Visit(context.statwrap());
	}

	public override (Type type, InstructionStack instStack) VisitStatwrap(
		[NotNull] PLC_Lab7_exprParser.StatwrapContext context) {
		InstructionStack instructionStack = new InstructionStack();
		var stats = context.stat();
		for (int i = 0; i < stats.Length; ++i) {
			var currentStat = Visit(stats[i]);
			instructionStack.Push(currentStat.instStack);
		}

		return (Type.ERROR, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitExp(
		[NotNull] PLC_Lab7_exprParser.ExpContext context) {
		return Visit(context.expr());
	}

	public override (Type type, InstructionStack instStack) VisitIf(
		[NotNull] PLC_Lab7_exprParser.IfContext context) {
		var cond = Visit(context.expr());
		if (cond.type != Type.BOOL) {
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
			instructionStack.Push(new Instruction {
				InstructionType = InstructionTypes.LABEL,
				Value = true_branch
			});
		}

		return (Type.ERROR, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitProg(
		[NotNull] PLC_Lab7_exprParser.ProgContext context) {
		InstructionStack instructionStack = new InstructionStack();
		foreach (var stat in context.stat()) {
			var statCont = Visit(stat);
			instructionStack.Push(statCont.instStack);
		}

		return (Type.ERROR, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitWhile(
		[NotNull] PLC_Lab7_exprParser.WhileContext context) {
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
		[NotNull] PLC_Lab7_exprParser.ExprCmpContext context) {
		var lhs = Visit(context.expr()[0]);
		var rhs = Visit(context.expr()[1]);

		if (context.op.Type == PLC_Lab7_exprParser.EQ || context.op.Type == PLC_Lab7_exprParser.NEQ) {
			InstructionStack instructionStack = new InstructionStack(lhs.instStack);
			if (lhs.type == rhs.type) {
				instructionStack.Push(rhs.instStack);
				if (context.op.Type == PLC_Lab7_exprParser.NEQ) {
					instructionStack.Push(new Instruction {
						InstructionType = InstructionTypes.NOT
					});
				}

				instructionStack.Push(new Instruction {
					InstructionType = InstructionTypes.EQ
				});
				return (lhs.type, instructionStack);
			}

			Errors.ReportError(context.Start,
				$"Both + or - operators should be either INT or FLOAT type. Left is: {lhs.type}. Right is: {rhs.type}");
			return new(Type.ERROR, new InstructionStack());
		}

		Errors.ReportError(context.Start, $"Actually impossible lol");
		return new(Type.ERROR, new InstructionStack());
	}

	public override (Type type, InstructionStack instStack) VisitExprMul(
		[NotNull] PLC_Lab7_exprParser.ExprMulContext context) {
		var lhs = Visit(context.expr()[0]);
		var rhs = Visit(context.expr()[1]);
		InstructionStack instructionStack = new InstructionStack(rhs.instStack);

		if (context.op.Type == PLC_Lab7_exprParser.MOD_OP) {
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

			instructionStack.Push(lhs.instStack);
			instructionStack.Push(new Instruction {
				InstructionType = InstructionTypes.MOD
			});
			return (lhs.type, instructionStack);
		}

		if (context.op.Type == PLC_Lab7_exprParser.MUL_OP || context.op.Type == PLC_Lab7_exprParser.DIV_OP) {
			if (lhs.type == rhs.type) {
				if (lhs.type == Type.INT || lhs.type == Type.FLOAT) {
					instructionStack.Push(rhs.instStack);
					instructionStack.Push(new Instruction {
						InstructionType = (context.op.Type == PLC_Lab7_exprParser.MUL_OP)
							? InstructionTypes.MUL
							: InstructionTypes.DIV
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
					InstructionType = (context.op.Type == PLC_Lab7_exprParser.MUL_OP)
						? InstructionTypes.MUL
						: InstructionTypes.DIV
				});
				return (rhs.type, instructionStack);
			}

			if (lhs.type == Type.FLOAT && rhs.type == Type.INT) {
				instructionStack.Push(rhs.instStack);
				instructionStack.Push(new Instruction {
					InstructionType = InstructionTypes.ITOF
				});
				instructionStack.Push(new Instruction {
					InstructionType = (context.op.Type == PLC_Lab7_exprParser.MUL_OP)
						? InstructionTypes.MUL
						: InstructionTypes.DIV
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
		[NotNull] PLC_Lab7_exprParser.ExprAndContext context) {
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
		[NotNull] PLC_Lab7_exprParser.ExprOrContext context) {
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
		[NotNull] PLC_Lab7_exprParser.ExprTernarContext context) {
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
					InstructionType = (context.op.Type == PLC_Lab7_exprParser.MUL_OP)
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
					InstructionType = (context.op.Type == PLC_Lab7_exprParser.MUL_OP)
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
		[NotNull] PLC_Lab7_exprParser.DeclerationContext context) {
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

		var tmp = SymbolTable[context.ID()[0].Symbol];
		return (tmp.Type, instructionStack);
	}

	public override (Type type, InstructionStack instStack) VisitIntDtype(
		[NotNull] PLC_Lab7_exprParser.IntDtypeContext context) {
		return (Type.INT, new InstructionStack());
	}

	public override (Type type, InstructionStack instStack) VisitIfstat(
		[NotNull] PLC_Lab7_exprParser.IfstatContext context) {
		return Visit(context.@if());
	}

	public override (Type type, InstructionStack instStack) VisitWhilecyc(
		[NotNull] PLC_Lab7_exprParser.WhilecycContext context) {
		return Visit(context.@while());
	}

	public override (Type type, InstructionStack instStack) VisitStrDtype(
		[NotNull] PLC_Lab7_exprParser.StrDtypeContext context) {
		return (Type.STRING, new InstructionStack());
	}

	public override (Type type, InstructionStack instStack) VisitFltDtype(
		[NotNull] PLC_Lab7_exprParser.FltDtypeContext context) {
		return (Type.FLOAT, new InstructionStack());
	}

	public override (Type type, InstructionStack instStack) VisitBolDtype(
		[NotNull] PLC_Lab7_exprParser.BolDtypeContext context) {
		return (Type.BOOL, new InstructionStack());
	}

	public override (Type type, InstructionStack instStack) VisitSem([NotNull] PLC_Lab7_exprParser.SemContext context) {
		return (Type.ERROR, new InstructionStack());
	}

	public override (Type type, InstructionStack instStack)VisitDecl(
		[NotNull] PLC_Lab7_exprParser.DeclContext context) {
		return Visit(context.decleration());
	}

	public override (Type type, InstructionStack instStack) VisitRd(
		[NotNull] PLC_Lab7_exprParser.RdContext context) {
		return Visit(context.read());
	}

	public override (Type type, InstructionStack instStack)VisitRead(
		[NotNull] PLC_Lab7_exprParser.ReadContext context) {
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
		[NotNull] PLC_Lab7_exprParser.WrContext context) {
		return Visit(context.write());
	}

	public override (Type type, InstructionStack instStack) VisitWrite(
		[NotNull] PLC_Lab7_exprParser.WriteContext context) {
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