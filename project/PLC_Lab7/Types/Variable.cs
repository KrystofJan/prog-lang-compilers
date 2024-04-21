using System.Runtime.InteropServices.JavaScript;

namespace Types;

public interface IVariable {
	public Type Type { get; set; }
	public object Value { get; set; }
}

public class Variable : IVariable {
	public Type Type { get; set; }
	public object Value { get; set; }

	public Variable(Type type, object value) {
		Type = type;
		Value = value;
	}
}