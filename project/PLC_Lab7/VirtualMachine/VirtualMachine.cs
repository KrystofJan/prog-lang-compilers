using System.IO.Pipes;
using Instructions;
using Type = Types.Type;

namespace VirtualMachine;

public class VirtualMachine {
	public InstructionStack InstructionStack { get; set; }
	private Stack<object> stack = new Stack<object>();
	Dictionary<string, object> memory = new Dictionary<string, object>();
	private Dictionary<int, int> labels = new Dictionary<int, int>();

	public VirtualMachine(string code) {
		List<string[]> tmp_code = code.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
			.Select(x => x.Split(" ")).ToList();
		InstructionStack = new InstructionStack(tmp_code);

		for (int i = 0; i < InstructionStack.Instructions.Count; ++i) {
			if (InstructionStack[i].InstructionType != InstructionTypes.LABEL) {
				continue;
			}
			labels[Convert.ToInt32(InstructionStack[i].Value)] = i - 1;
		}
	}

	public void Run() {		
		for (int i = 0; i < InstructionStack.Instructions.Count; ++i) {
			if (InstructionStack[i].InstructionType == InstructionTypes.PUSH) {
				stack.Push(InstructionStack[i].Value);
				continue;
			}
			if (InstructionStack[i].InstructionType == InstructionTypes.JMP) {
				i = labels[Convert.ToInt32(InstructionStack[i].Value)];
				continue;
			}
			if (InstructionStack[i].InstructionType == InstructionTypes.FJMP) {
				var value = stack.Pop();
				stack.Push(value);
				if (!Convert.ToBoolean(value)) {
					i = labels[Convert.ToInt32(InstructionStack[i].Value)];
				}
				continue;
			}
			if (InstructionStack[i].InstructionType == InstructionTypes.POP) {
				stack.Pop();
				continue;
			}
			if (InstructionStack[i].InstructionType == InstructionTypes.ITOF) {
				var value = stack.Pop();
				if (value is int a) {
					stack.Push((float)a);
				}
				continue;
			}
			if (InstructionStack[i].InstructionType == InstructionTypes.LOAD) {
				stack.Push(memory[InstructionStack[i].Value.ToString()]);
				continue;
			}
			if (InstructionStack[i].InstructionType == InstructionTypes.SAVE) {
				var value = stack.Pop();
				memory[InstructionStack[i].Value.ToString()] = value;
				continue;
			}
			if (InstructionStack[i].InstructionType == InstructionTypes.LABEL) {
				continue;
			}
			if (InstructionStack[i].InstructionType == InstructionTypes.PRINT) {
				int instCount = Convert.ToInt32(InstructionStack[i].Value);
				Stack<object> vals = new Stack<object>();
				for (int j = 0; j < instCount; ++j) {
					vals.Push(stack.Pop());
				}
				for (int j = 0; j < instCount; ++j) {
					Console.Write(vals.Pop().ToString());
				}
				Console.Write(Environment.NewLine);
				continue;
			}
			if (InstructionStack[i].InstructionType == InstructionTypes.READ) {
				string? input = Console.ReadLine();
				switch (InstructionStack[i].Type) {
					case Type.INT: {
						stack.Push(int.Parse(input ?? ""));
						break;
					}
					case Type.FLOAT: {
						stack.Push(float.Parse(input ?? ""));
						break;
					}
					case Type.BOOL: {
						stack.Push(bool.Parse(input ?? ""));
						break;
					}
					case Type.STRING: {
						stack.Push(input ?? "");
						break;
					}
					default: {
						ThrowError($"Wrong type {InstructionStack[i].Type}");
						continue;
					}
				}
				continue;
			}
			if (InstructionStack[i].InstructionType == InstructionTypes.UMINUS) {
				var value = stack.Pop();
				if (value is float val) {
					stack.Push(val * -1); 
					continue;
				}
				stack.Push((int)value * -1);
				continue;
			}
			if (InstructionStack[i].InstructionType == InstructionTypes.NOT) {
				var value = stack.Pop();
				stack.Push(!Convert.ToBoolean(value));
				continue;
			}
			
			var right = stack.Pop();
			var left = stack.Pop();
			
			switch (InstructionStack[i].InstructionType) {
				case InstructionTypes.ADD: {
					if (InstructionStack[i].Type == Type.FLOAT) {
						stack.Push((float)left + (float)right);
						break;
					}
					stack.Push((int)left + (int)right);
					break;
				}
				case InstructionTypes.SUB: {
					if (InstructionStack[i].Type == Type.FLOAT) {
						stack.Push((float)left - (float)right);
						break;
					}
					stack.Push((int)left - (int)right);
					break;
				}
				case InstructionTypes.CONCAT: {
					stack.Push((string)left + (string)right);
					break;
				}
				case InstructionTypes.MUL: {
					if (InstructionStack[i].Type == Type.FLOAT) {
						stack.Push((float)left * (float)right);
						break;
					}
					stack.Push((int)left * (int)right);
					break;
				}
				case InstructionTypes.DIV: {
					if (InstructionStack[i].Type == Type.FLOAT) {
						stack.Push((float)left / (float)right);
						break;
					}
					stack.Push((int)left / (int)right);
					break;
				}
				case InstructionTypes.MOD: {
					stack.Push((int)left % (int)right);
					break;
				}
				case InstructionTypes.AND: {
					stack.Push((bool)left && (bool)right);
					break;
				}				
				case InstructionTypes.OR: {
					stack.Push((bool)left || (bool)right);
					break;
				}				
				case InstructionTypes.EQ: {
					// TODO: Refactor
					if (left is float fLeft) {
						stack.Push(right.Equals(fLeft));
						break;
					}
					if (right is float fRight) {
						stack.Push(left.Equals(fRight));
						break;
					}
					if (left is string sLeft) {
						stack.Push(right.Equals(sLeft));
						break;
					}
					stack.Push(right.Equals(left));
					break;
				}
				case InstructionTypes.GT: {
					if (left is float fLeft){
						stack.Push(fLeft > (float)right);
						break;
					}
					if (right is float fRight){
						stack.Push((float) left > fRight);
						break;
					}
					stack.Push((int)left > (int)right);
					break;
				}
				case InstructionTypes.LT: {
					if (left is float fLeft){
						stack.Push(fLeft < (float)right);
						break;
					}
					if (right is float fRight){
						stack.Push((float) left < fRight);
						break;
					}
					stack.Push((int)left < (int)right);
					break;
				}
			}
		}
	}

	private void ThrowError(string msg) {
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine($"----- ERROR -----" +
		                  $"{Environment.NewLine}{msg}{Environment.NewLine}" +
		                  $"--- ERROR_END ---");
		Console.ResetColor();
	}
}