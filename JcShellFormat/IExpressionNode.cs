namespace Watsug.JcShellFormat
{
    public interface IExpressionNode : IEvaluate
    {
        IExpressionNode Parent { get; }

        IExpressionNode Push(char c);
        IExpressionNode Push(IExpressionNode exprNode);
    }
}