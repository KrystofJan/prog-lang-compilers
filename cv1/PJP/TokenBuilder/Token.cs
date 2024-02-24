namespace TokenBuilder
{
    public enum TokenType {
        NUM,
        PLUS,
        MINUS,
        MULTIPLY,
        DEVIDE,
        LPAR,
        RPAR
    }
    public class Token
    {
        public TokenType Type { get; set; }
        public int? Value { get; set; }
    }
}