namespace OperationTree {
	public class Number : INode{
		public int Value { get; set; }
		public int Calculate() {
			return Value;
		}
	}
}