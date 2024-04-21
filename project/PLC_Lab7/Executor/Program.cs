using System;
using Compiler;
using VirtualMachine;

namespace Executor;

internal class Program {
	static void Main(string[] args) {
		Compiler.Compiler.Compile("../../../main.pat", "../../../esketit.vmc");
		VM.Run("../../../esketit.vmc");
	}
}