namespace Types;

public enum Type {
	INT,
	FLOAT,
	BOOL,
	STRING,
	ERROR,
}


public static class TypeHandler {
	public static Type GetDType(string type) {
		switch (type.ToLower()) {
			case "i": return Type.INT;
			case "int": return Type.INT;
			case "f": return Type.FLOAT;
			case "float": return Type.FLOAT;
			case "s": return Type.STRING;
			case "string": return Type.STRING;
			case "bool": return Type.BOOL;
			case "b": return Type.BOOL;
			default: return Type.ERROR;
		}
	}

	public static object GetDTypeValue(Type type, string[] input) {
		string value = string.Join("", input);
		switch (type) {
			case Type.INT: return int.Parse(value); 
			case Type.FLOAT: return float.Parse(value); 
			case Type.BOOL: return bool.Parse(value);
			case Type.STRING: return string.Join(" ", input).Trim('"');
			default: return new object();
		}
	}
} 