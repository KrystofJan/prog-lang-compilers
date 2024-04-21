using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Atn;
using Types;
using Type = Types.Type;

namespace Instructions;

public class Instruction {
	public Type? Type { get; set; }
	public object? Value { get; set; }
	public string InstructionType { get; set; }
}

public class InstructionStack {
	public List<Instruction> Instructions { get; set; } = new List<Instruction>();

	public Instruction this[int i] {
		get {
			return Instructions[i];
		}
		set {
			Instructions[i] = value;
		}
	}
	
	public InstructionStack(InstructionStack instructionStack) {
		Instructions.AddRange(instructionStack.Instructions);
	}
	
	public InstructionStack(Instruction instruction) {
		Instructions.Add(instruction);
	}

	public InstructionStack() {
	}
	public InstructionStack(List<string[]> code) {
		
		foreach (string[] inst in code) {
			if (inst[0].ToLower() == "push") {
				Type t = TypeHandler.GetDType(inst[1]);
				Push(new Instruction {
					InstructionType = InstructionTypes.PUSH,
					Type = t,
					Value = TypeHandler.GetDTypeValue(t, inst.Skip(2).ToArray())
				});
				continue;
			}
			if (inst[0].ToLower() == "jmp") {
				Push(new Instruction {
					InstructionType = InstructionTypes.JMP,
					Value =  TypeHandler.GetDTypeValue(Type.INT, inst.Skip(1).ToArray())
				});
			}
			if (inst[0].ToLower() == "fjmp") {
				Push(new Instruction {
					InstructionType = InstructionTypes.FJMP,
					Value = TypeHandler.GetDTypeValue(Type.INT, inst.Skip(1).ToArray())
				});
				continue;
			}
			if (inst[0].ToLower() == "pop") {
				Push(new Instruction {
					InstructionType = InstructionTypes.POP
				});
			}
			if (inst[0].ToLower() == "itof") {
				Push(new Instruction {
					InstructionType = InstructionTypes.ITOF
				});
			}
			if (inst[0].ToLower() == "load") {
				Push(new Instruction {
					InstructionType = InstructionTypes.LOAD,
					Value =  TypeHandler.GetDTypeValue(Type.STRING, inst.Skip(1).ToArray())
				});
			}
			if (inst[0].ToLower() == "save") {
				Push(new Instruction {
					InstructionType = InstructionTypes.SAVE,
					Value =  TypeHandler.GetDTypeValue(Type.STRING, inst.Skip(1).ToArray())
				});
			}
			if (inst[0].ToLower() == "label") {
				Push(new Instruction {
					InstructionType = InstructionTypes.LABEL,
					Value =  TypeHandler.GetDTypeValue(Type.INT, inst.Skip(1).ToArray())
				});
			}
			if (inst[0].ToLower() == "print") {
				Push(new Instruction {
					InstructionType = InstructionTypes.PRINT,
					Value =  TypeHandler.GetDTypeValue(Type.INT, inst.Skip(1).ToArray())
				});
			}
			if (inst[0].ToLower() == "read") {
				Push(new Instruction {
					InstructionType = InstructionTypes.READ,
					Type =  TypeHandler.GetDType(inst[1])
				});
			}
			if (inst[0].ToLower() == "add") {
				Push(new Instruction {
					InstructionType = InstructionTypes.ADD,
					Type = TypeHandler.GetDType(inst[1])
				});
			}
			if (inst[0].ToLower() == "sub") {
				Push(new Instruction {
					InstructionType = InstructionTypes.SUB,
					Type = TypeHandler.GetDType(inst[1])
				});
			}
			if (inst[0].ToLower() == "concat") {
				Push(new Instruction {
					InstructionType = InstructionTypes.CONCAT,
					Type = TypeHandler.GetDType(inst[1])
				});
			}
			if (inst[0].ToLower() == "mul") {
				Push(new Instruction {
					InstructionType = InstructionTypes.MUL,
					Type = TypeHandler.GetDType(inst[1])
				});
			}
			if (inst[0].ToLower() == "div") {
				Push(new Instruction {
					InstructionType = InstructionTypes.DIV,
					Type = TypeHandler.GetDType(inst[1])
				});
			}
			if (inst[0].ToLower() == "mod") {
				Push(new Instruction {
					InstructionType = InstructionTypes.MOD,
					Type = TypeHandler.GetDType(inst[1])
				});
			}
			if (inst[0].ToLower() == "uminus") {
				Push(new Instruction {
					InstructionType = InstructionTypes.UMINUS
				});
			}
			if (inst[0].ToLower() == "and") {
				Push(new Instruction {
					InstructionType = InstructionTypes.AND
				});
			}
			if (inst[0].ToLower() == "or") {
				Push(new Instruction {
					InstructionType = InstructionTypes.OR
				});
			}
			if (inst[0].ToLower() == "eq") {
				Push(new Instruction {
					InstructionType = InstructionTypes.EQ
				});
			}
			if (inst[0].ToLower() == "not") {
				Push(new Instruction {
					InstructionType = InstructionTypes.NOT
				});
			}
			if (inst[0].ToLower() == "gt") {
				Push(new Instruction {
					InstructionType = InstructionTypes.GT
				});
			}
			if (inst[0].ToLower() == "lt") {
				Push(new Instruction {
					InstructionType = InstructionTypes.LT
				});
			}
		}
	}
	
	public void Push(Instruction instruction) {
		Instructions.Add(instruction);
	}

	public void Push(InstructionStack instructionStack) {
		Instructions.AddRange(instructionStack.Instructions);
	}

	public Instruction Pop() {
		Instruction result = Instructions[Instructions.Count];
		Instructions.RemoveAt(Instructions.Count);
		return result;
	}
	
	public Instruction Peek() {
		return Instructions[Instructions.Count];
	}

	public override string ToString() {
		StringBuilder sb = new StringBuilder();
		foreach (var instruction in Instructions) {
			string iType = instruction.InstructionType;
			string dType = instruction.Type == null? "" : instruction.Type.ToString();
			string value = instruction.Value == null? "": instruction.Value.ToString();

			sb.AppendLine($"{iType.ToLower()}{(dType == "" ? dType : " " + dType[0])  }{(value == "" ? "" : " " + value)}");
		}

		return sb.ToString();
	}
}