using Types;
namespace Compiler;

public class Error : Variable {

	public Error(object value) : base(Type.ERROR, value) {
	}
}