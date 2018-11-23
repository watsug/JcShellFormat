namespace Watsug.JcShellFormat
{
    public interface IExpressionNode : IEvaluate
    {
        IExpressionNode Push(char c);
        IExpressionNode Push(IExpressionNode exprNode);
    }
}