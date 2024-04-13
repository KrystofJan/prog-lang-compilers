﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Atn;

namespace PLC_Lab7;

public class Instruction {
	public Type? Type { get; set; }
	public object? Value { get; set; }
	public string InstructionType { get; set; }

	// public Instruction(string instructionType, Type type, object value) {
	// 	InstructionType = instructionType;
	// 	Value = value;
	// 	Type = type;
	// }
	//
	// public Instruction(string instructionType, Type type) {
	// 	InstructionType = instructionType;
	// 	Type = type;
	// 	Value = null;
	// }
	//
	// public Instruction(string instructionType) {
	// 	InstructionType = instructionType;
	// 	Value = null;
	// 	Type = null;
	// }
}

public class InstructionStack {
	public List<Instruction> Instructions { get; set; } = new List<Instruction>();
	
	public InstructionStack(InstructionStack instructionStack) {
		Instructions.AddRange(instructionStack.Instructions);
	}
	
	public InstructionStack(Instruction instruction) {
		Instructions.Add(instruction);
	}

	public InstructionStack() {
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
			string dType = instruction.Type.ToString();
			string value = instruction.Value.ToString();

			sb.AppendLine($"{iType}{" " + dType}{" " + value}");
		}

		return sb.ToString();
	}
}