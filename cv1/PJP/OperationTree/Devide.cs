namespace OperationTree
{
    public class Devide : INode
    {
        public INode NodeLeft { get; set; }
        public INode NodeRight { get; set; }
        public int Calculate() {
            int leftValue = NodeLeft.Calculate();
            int rightValue = NodeRight.Calculate();

            return leftValue / rightValue;
        }
    }
}