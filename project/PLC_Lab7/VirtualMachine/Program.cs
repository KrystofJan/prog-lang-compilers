using System;

namespace VirtualMachine {
	public class VM {
		public static void Run(string inputFilePath) {
			var input = File.ReadAllText(inputFilePath);
			VirtualMachine vm = new VirtualMachine(input);
			vm.Run();
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			var input = File.ReadAllText("input.vmc");
			VirtualMachine vm = new VirtualMachine(input);
			vm.Run();
		}
	}
}